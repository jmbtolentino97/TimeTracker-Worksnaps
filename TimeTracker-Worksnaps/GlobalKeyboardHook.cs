using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TimeTracker_Worksnaps
{
    internal class GlobalKeyboardHook : IDisposable
    {
        // Windows API constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        // Delegate for the hook callback
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Handle for the hook
        private IntPtr hookId = IntPtr.Zero;

        // The hook callback delegate instance
        private HookProc hookCallback;

        public event EventHandler<KeyEventArgs> KeyUp;
        public event EventHandler<KeyEventArgs> KeyDown;

        public bool IsCtrlPressed { get; private set; } = false;
        public bool IsAltPressed { get; private set; } = false;
        public bool IsShiftPressed { get; private set; } = false;

        public GlobalKeyboardHook()
        {
            hookCallback = HookCallback;
            hookId = SetHook(hookCallback);
        }

        private IntPtr SetHook(HookProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    if (key == Keys.LControlKey || key == Keys.RControlKey) IsCtrlPressed = true;
                    if (key == Keys.LMenu || key == Keys.RMenu) IsAltPressed = true;
                    if (key == Keys.LShiftKey || key == Keys.RShiftKey) IsShiftPressed = true;

                    KeyDown?.Invoke(this, new KeyEventArgs(key));
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    KeyUp?.Invoke(this, new KeyEventArgs(key));

                    if (key == Keys.LControlKey || key == Keys.RControlKey) IsCtrlPressed = false;
                    if (key == Keys.LMenu || key == Keys.RMenu) IsAltPressed = false;
                    if (key == Keys.LShiftKey || key == Keys.RShiftKey) IsShiftPressed = false;
                }
            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(hookId);
        }

        // Windows API imports
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}