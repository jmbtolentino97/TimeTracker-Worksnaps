using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TimeTracker_Worksnaps
{
    public partial class Form1 : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook = new GlobalKeyboardHook();
        private bool _isFetching = false;

        public Form1()
        {
            InitializeComponent();
            _globalKeyboardHook.KeyUp += GlobalKeyboardHook_KeyUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            this.Left = workingArea.Right - this.Width - 0;
            this.Top = workingArea.Bottom - this.Height - 0;

            backgroundWorker1.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                LoadTimeStatus();
                Thread.Sleep((int)TimeSpan.FromMinutes(5).TotalMilliseconds);
            }
        }

        private void LoadTimeStatus()
        {
            if (_isFetching) return;

            _isFetching = true;
            Invoke((MethodInvoker)delegate
            {
                lblTotalTime.Text = "fetching...";
            });
            var timeEntries = GetTimeEntries();
            var activeTimeEntries = timeEntries.Where(timeEntry => timeEntry.ActivityLevel > 0).ToList();
            TimeSpan totalTime = TimeSpan.FromMinutes(activeTimeEntries.Count * 10);
            var remainingMinutes = totalTime.TotalMinutes < 450 ? 450 - totalTime.TotalMinutes : 0;
            var expectedOut = DateTime.Now.AddMinutes(remainingMinutes).RoundUpToNext10Minutes();
            Invoke((MethodInvoker)delegate
            {
                lblTotalTime.Text = $"{totalTime.Hours}(hrs) {totalTime.Minutes} (mins)";
                lblExpectedOut.Text = expectedOut.ToString("hh:mm tt");
                lblLastCapture.Text = timeEntries.LastOrDefault()?.LoggedTimestamp.ToLocalTime().ToString("hh:mm tt");
                lblLastFetched.Text = DateTime.Now.ToString("hh:mm tt");
            });
            _isFetching = false;
        }

        private List<TimeEntry> GetTimeEntries()
        {
            List<TimeEntry> result = new List<TimeEntry>();
            using (HttpClient client = new HttpClient())
            {
                var fromTimestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).GetTimestamp();
                var toTimestamp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59).GetTimestamp();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(Configuration.GetApiKey()))
                );
                var response = client.GetAsync($"https://api.worksnaps.com/api/projects/{Configuration.GetProjectId()}/time_entries.xml?user_ids={Configuration.GetUserId()}&from_timestamp={fromTimestamp}&to_timestamp={toTimestamp}").Result.Content.ReadAsStringAsync().Result;

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(response);
                var rootDocument = xmlDocument.GetElementsByTagName("time_entries")[0];
                foreach (XmlElement timeEntry in rootDocument.SelectNodes("time_entry"))
                {
                    result.Add(new TimeEntry()
                    {
                        ActivityLevel = Convert.ToInt32(timeEntry.SelectSingleNode("activity_level").InnerText.ToString()),
                        LoggedTimestamp = Convert.ToInt64(timeEntry.SelectSingleNode("logged_timestamp").InnerText.ToString())
                    });
                }
            }

            return result;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Opacity = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _globalKeyboardHook.Dispose();
        }

        private void GlobalKeyboardHook_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && _globalKeyboardHook.IsCtrlPressed && _globalKeyboardHook.IsAltPressed)
            {
                if (_globalKeyboardHook.IsShiftPressed)
                {
                    Close();
                }
                else
                {
                    if (Opacity > 0)
                    {
                        Opacity = 0;
                    }
                    else
                    {
                        Opacity = 100;
                    }
                }
            }

            if (e.KeyCode == Keys.R && _globalKeyboardHook.IsCtrlPressed && _globalKeyboardHook.IsAltPressed)
            {
                LoadTimeStatus();
            }
        }
    }
}
