namespace DriveLogGUI
{
    partial class overviewTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.todaysNotePanel = new System.Windows.Forms.Panel();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.progressBarPanel = new System.Windows.Forms.Panel();
            this.miscPanel = new System.Windows.Forms.Panel();
            this.welcomeUserLabel = new System.Windows.Forms.Label();
            this.todaysNoteTextbox = new System.Windows.Forms.TextBox();
            this.todaysNoteLabel = new System.Windows.Forms.Label();
            this.todaysNoteUnderline = new System.Windows.Forms.Panel();
            this.calenderLabel = new System.Windows.Forms.Label();
            this.progressUnderline = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.theoreticalLabel = new System.Windows.Forms.Label();
            this.practicalLabel = new System.Windows.Forms.Label();
            this.practicalProgressFill = new System.Windows.Forms.Panel();
            this.theoreticalProgressFill = new System.Windows.Forms.Panel();
            this.theoreticalStatus = new System.Windows.Forms.Label();
            this.practicalStatus = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.headerPanel.SuspendLayout();
            this.todaysNotePanel.SuspendLayout();
            this.calendarPanel.SuspendLayout();
            this.progressBarPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.welcomeUserLabel);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(873, 56);
            this.headerPanel.TabIndex = 0;
            // 
            // todaysNotePanel
            // 
            this.todaysNotePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.todaysNotePanel.Controls.Add(this.todaysNoteUnderline);
            this.todaysNotePanel.Controls.Add(this.todaysNoteLabel);
            this.todaysNotePanel.Controls.Add(this.todaysNoteTextbox);
            this.todaysNotePanel.Location = new System.Drawing.Point(12, 74);
            this.todaysNotePanel.Name = "todaysNotePanel";
            this.todaysNotePanel.Size = new System.Drawing.Size(454, 180);
            this.todaysNotePanel.TabIndex = 1;
            this.todaysNotePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.todaysNotePanel_Paint);
            // 
            // calendarPanel
            // 
            this.calendarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.calendarPanel.Controls.Add(this.monthCalendar1);
            this.calendarPanel.Controls.Add(this.panel1);
            this.calendarPanel.Controls.Add(this.calenderLabel);
            this.calendarPanel.Location = new System.Drawing.Point(472, 74);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(413, 336);
            this.calendarPanel.TabIndex = 2;
            // 
            // progressBarPanel
            // 
            this.progressBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.progressBarPanel.Controls.Add(this.practicalStatus);
            this.progressBarPanel.Controls.Add(this.theoreticalStatus);
            this.progressBarPanel.Controls.Add(this.practicalLabel);
            this.progressBarPanel.Controls.Add(this.theoreticalLabel);
            this.progressBarPanel.Controls.Add(this.panel3);
            this.progressBarPanel.Controls.Add(this.panel2);
            this.progressBarPanel.Controls.Add(this.progressLabel);
            this.progressBarPanel.Controls.Add(this.progressUnderline);
            this.progressBarPanel.Location = new System.Drawing.Point(12, 258);
            this.progressBarPanel.Name = "progressBarPanel";
            this.progressBarPanel.Size = new System.Drawing.Size(454, 152);
            this.progressBarPanel.TabIndex = 3;
            this.progressBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.progressBarPanel_Paint);
            // 
            // miscPanel
            // 
            this.miscPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.miscPanel.Location = new System.Drawing.Point(12, 416);
            this.miscPanel.Name = "miscPanel";
            this.miscPanel.Size = new System.Drawing.Size(873, 103);
            this.miscPanel.TabIndex = 4;
            // 
            // welcomeUserLabel
            // 
            this.welcomeUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeUserLabel.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.welcomeUserLabel.Location = new System.Drawing.Point(12, 6);
            this.welcomeUserLabel.Name = "welcomeUserLabel";
            this.welcomeUserLabel.Size = new System.Drawing.Size(234, 44);
            this.welcomeUserLabel.TabIndex = 0;
            this.welcomeUserLabel.Text = "Welcome Bob!";
            // 
            // todaysNoteTextbox
            // 
            this.todaysNoteTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.todaysNoteTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.todaysNoteTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
            this.todaysNoteTextbox.Location = new System.Drawing.Point(22, 29);
            this.todaysNoteTextbox.Multiline = true;
            this.todaysNoteTextbox.Name = "todaysNoteTextbox";
            this.todaysNoteTextbox.Size = new System.Drawing.Size(420, 136);
            this.todaysNoteTextbox.TabIndex = 0;
            this.todaysNoteTextbox.Text = "There will be free cake today";
            // 
            // todaysNoteLabel
            // 
            this.todaysNoteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.todaysNoteLabel.Location = new System.Drawing.Point(19, 6);
            this.todaysNoteLabel.Name = "todaysNoteLabel";
            this.todaysNoteLabel.Size = new System.Drawing.Size(128, 19);
            this.todaysNoteLabel.TabIndex = 1;
            this.todaysNoteLabel.Text = "Today\'s note";
            // 
            // todaysNoteUnderline
            // 
            this.todaysNoteUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.todaysNoteUnderline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.todaysNoteUnderline.Location = new System.Drawing.Point(22, 21);
            this.todaysNoteUnderline.Name = "todaysNoteUnderline";
            this.todaysNoteUnderline.Size = new System.Drawing.Size(420, 2);
            this.todaysNoteUnderline.TabIndex = 3;
            // 
            // calenderLabel
            // 
            this.calenderLabel.AutoSize = true;
            this.calenderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.calenderLabel.Location = new System.Drawing.Point(17, 6);
            this.calenderLabel.Name = "calenderLabel";
            this.calenderLabel.Size = new System.Drawing.Size(49, 13);
            this.calenderLabel.TabIndex = 5;
            this.calenderLabel.Text = "Calendar";
            // 
            // progressUnderline
            // 
            this.progressUnderline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.progressUnderline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.progressUnderline.Location = new System.Drawing.Point(22, 23);
            this.progressUnderline.Name = "progressUnderline";
            this.progressUnderline.Size = new System.Drawing.Size(420, 2);
            this.progressUnderline.TabIndex = 4;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.progressLabel.Location = new System.Drawing.Point(19, 7);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "Progress";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel1.Location = new System.Drawing.Point(20, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 2);
            this.panel1.TabIndex = 4;
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(187)))), ((int)(((byte)(191)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.logoutButton.Location = new System.Drawing.Point(808, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(52, 44);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel2.Controls.Add(this.theoreticalProgressFill);
            this.panel2.Location = new System.Drawing.Point(22, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 28);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel3.Controls.Add(this.practicalProgressFill);
            this.panel3.Location = new System.Drawing.Point(22, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 28);
            this.panel3.TabIndex = 8;
            // 
            // theoreticalLabel
            // 
            this.theoreticalLabel.AutoSize = true;
            this.theoreticalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
            this.theoreticalLabel.Location = new System.Drawing.Point(19, 34);
            this.theoreticalLabel.Name = "theoreticalLabel";
            this.theoreticalLabel.Size = new System.Drawing.Size(60, 13);
            this.theoreticalLabel.TabIndex = 9;
            this.theoreticalLabel.Text = "Theoretical";
            // 
            // practicalLabel
            // 
            this.practicalLabel.AutoSize = true;
            this.practicalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
            this.practicalLabel.Location = new System.Drawing.Point(19, 89);
            this.practicalLabel.Name = "practicalLabel";
            this.practicalLabel.Size = new System.Drawing.Size(48, 13);
            this.practicalLabel.TabIndex = 10;
            this.practicalLabel.Text = "Practical";
            // 
            // practicalProgressFill
            // 
            this.practicalProgressFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
            this.practicalProgressFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.practicalProgressFill.Location = new System.Drawing.Point(0, 0);
            this.practicalProgressFill.Name = "practicalProgressFill";
            this.practicalProgressFill.Size = new System.Drawing.Size(190, 28);
            this.practicalProgressFill.TabIndex = 0;
            // 
            // theoreticalProgressFill
            // 
            this.theoreticalProgressFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(197)))), ((int)(((byte)(204)))));
            this.theoreticalProgressFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.theoreticalProgressFill.Location = new System.Drawing.Point(0, 0);
            this.theoreticalProgressFill.Name = "theoreticalProgressFill";
            this.theoreticalProgressFill.Size = new System.Drawing.Size(316, 28);
            this.theoreticalProgressFill.TabIndex = 0;
            // 
            // theoreticalStatus
            // 
            this.theoreticalStatus.AutoSize = true;
            this.theoreticalStatus.Location = new System.Drawing.Point(406, 34);
            this.theoreticalStatus.Name = "theoreticalStatus";
            this.theoreticalStatus.Size = new System.Drawing.Size(36, 13);
            this.theoreticalStatus.TabIndex = 11;
            this.theoreticalStatus.Text = "17/24";
            this.theoreticalStatus.Click += new System.EventHandler(this.theoreticalStatus_Click);
            // 
            // practicalStatus
            // 
            this.practicalStatus.AutoSize = true;
            this.practicalStatus.Location = new System.Drawing.Point(412, 89);
            this.practicalStatus.Name = "practicalStatus";
            this.practicalStatus.Size = new System.Drawing.Size(30, 13);
            this.practicalStatus.TabIndex = 12;
            this.practicalStatus.Text = "6/14";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.monthCalendar1.Location = new System.Drawing.Point(20, 30);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            // 
            // overviewTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.miscPanel);
            this.Controls.Add(this.progressBarPanel);
            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.todaysNotePanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "overviewTab";
            this.Size = new System.Drawing.Size(897, 532);
            this.headerPanel.ResumeLayout(false);
            this.todaysNotePanel.ResumeLayout(false);
            this.todaysNotePanel.PerformLayout();
            this.calendarPanel.ResumeLayout(false);
            this.calendarPanel.PerformLayout();
            this.progressBarPanel.ResumeLayout(false);
            this.progressBarPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel todaysNotePanel;
        private System.Windows.Forms.Panel calendarPanel;
        private System.Windows.Forms.Panel progressBarPanel;
        private System.Windows.Forms.Panel miscPanel;
        private System.Windows.Forms.Label welcomeUserLabel;
        private System.Windows.Forms.TextBox todaysNoteTextbox;
        private System.Windows.Forms.Panel todaysNoteUnderline;
        private System.Windows.Forms.Label todaysNoteLabel;
        private System.Windows.Forms.Label calenderLabel;
        private System.Windows.Forms.Panel progressUnderline;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label practicalStatus;
        private System.Windows.Forms.Label theoreticalStatus;
        private System.Windows.Forms.Label practicalLabel;
        private System.Windows.Forms.Label theoreticalLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel practicalProgressFill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel theoreticalProgressFill;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
