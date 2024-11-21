namespace TimeTracker_Worksnaps
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            lblTotalTime = new Label();
            lblExpectedOut = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button1 = new Button();
            lblLastCapture = new Label();
            label4 = new Label();
            lblLastFetched = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(39, 7);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 0;
            label1.Text = "Total Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(21, 35);
            label2.Name = "label2";
            label2.Size = new Size(101, 21);
            label2.TabIndex = 1;
            label2.Text = "Expected out:";
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Font = new Font("Segoe UI", 12F);
            lblTotalTime.Location = new Point(128, 7);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(116, 21);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "0 hr(s) 0 min(s)";
            // 
            // lblExpectedOut
            // 
            lblExpectedOut.AutoSize = true;
            lblExpectedOut.Font = new Font("Segoe UI", 12F);
            lblExpectedOut.Location = new Point(128, 35);
            lblExpectedOut.Name = "lblExpectedOut";
            lblExpectedOut.Size = new Size(28, 21);
            lblExpectedOut.TabIndex = 3;
            lblExpectedOut.Text = "---";
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(262, -1);
            button1.Name = "button1";
            button1.Size = new Size(35, 23);
            button1.TabIndex = 4;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += Button1_Click;
            // 
            // lblLastCapture
            // 
            lblLastCapture.AutoSize = true;
            lblLastCapture.Font = new Font("Segoe UI", 12F);
            lblLastCapture.Location = new Point(128, 63);
            lblLastCapture.Name = "lblLastCapture";
            lblLastCapture.Size = new Size(28, 21);
            lblLastCapture.TabIndex = 6;
            lblLastCapture.Text = "---";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(22, 63);
            label4.Name = "label4";
            label4.Size = new Size(100, 21);
            label4.TabIndex = 5;
            label4.Text = "Last Capture:";
            // 
            // lblLastFetched
            // 
            lblLastFetched.AutoSize = true;
            lblLastFetched.Font = new Font("Segoe UI", 12F);
            lblLastFetched.Location = new Point(129, 91);
            lblLastFetched.Name = "lblLastFetched";
            lblLastFetched.Size = new Size(28, 21);
            lblLastFetched.TabIndex = 10;
            lblLastFetched.Text = "---";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(23, 91);
            label5.Name = "label5";
            label5.Size = new Size(99, 21);
            label5.TabIndex = 9;
            label5.Text = "Last Fetched:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 125);
            Controls.Add(lblLastFetched);
            Controls.Add(label5);
            Controls.Add(lblLastCapture);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(lblExpectedOut);
            Controls.Add(lblTotalTime);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            TopMost = true;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblTotalTime;
        private Label lblExpectedOut;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button button1;
        private Label lblLastCapture;
        private Label label4;
        private Label lblLastFetched;
        private Label label5;
    }
}
