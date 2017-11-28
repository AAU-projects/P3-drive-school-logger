﻿namespace DriveLogGUI.MenuTabs
{
    partial class CalendarTabG
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
            if (disposing && (components != null)) {
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
            this.panelForCalendar = new System.Windows.Forms.Panel();
            this.backPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.weekNumberTextbox = new System.Windows.Forms.TextBox();
            this.weekNumberLabel = new System.Windows.Forms.Label();
            this.weekSelectButton = new System.Windows.Forms.Button();
            this.gotoTodayButton = new System.Windows.Forms.Button();
            this.buttonRightWeek = new System.Windows.Forms.Label();
            this.buttonLeftWeek = new System.Windows.Forms.Label();
            this.datesInWeek = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.warningInformationLabel = new System.Windows.Forms.Label();
            this.bookInformationLabel = new System.Windows.Forms.Label();
            this.warningTitleLabel = new System.Windows.Forms.Label();
            this.bookingInformationButton = new System.Windows.Forms.Button();
            this.instructorTitleInformationLabel = new System.Windows.Forms.Label();
            this.instructorInformationLabel = new System.Windows.Forms.Label();
            this.timeInformationLabel = new System.Windows.Forms.Label();
            this.dateInformationLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.informationLabel = new System.Windows.Forms.Label();
            this.panelForCalendar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelForCalendar
            // 
            this.panelForCalendar.BackColor = System.Drawing.Color.White;
            this.panelForCalendar.Controls.Add(this.backPanel);
            this.panelForCalendar.Location = new System.Drawing.Point(211, 93);
            this.panelForCalendar.Name = "panelForCalendar";
            this.panelForCalendar.Size = new System.Drawing.Size(686, 451);
            this.panelForCalendar.TabIndex = 1;
            this.panelForCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelForCalendar_Paint);
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.backPanel.Location = new System.Drawing.Point(0, 25);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(687, 401);
            this.backPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.panel1.Controls.Add(this.weekNumberTextbox);
            this.panel1.Controls.Add(this.weekNumberLabel);
            this.panel1.Controls.Add(this.weekSelectButton);
            this.panel1.Controls.Add(this.gotoTodayButton);
            this.panel1.Controls.Add(this.buttonRightWeek);
            this.panel1.Controls.Add(this.buttonLeftWeek);
            this.panel1.Controls.Add(this.datesInWeek);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(211, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 93);
            this.panel1.TabIndex = 2;
            // 
            // weekNumberTextbox
            // 
            this.weekNumberTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.weekNumberTextbox.Font = new System.Drawing.Font("Calibri Light", 9.75F);
            this.weekNumberTextbox.Location = new System.Drawing.Point(595, 60);
            this.weekNumberTextbox.MaxLength = 2;
            this.weekNumberTextbox.Name = "weekNumberTextbox";
            this.weekNumberTextbox.Size = new System.Drawing.Size(77, 23);
            this.weekNumberTextbox.TabIndex = 0;
            this.weekNumberTextbox.Text = "42";
            this.weekNumberTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.weekNumberTextbox.Visible = false;
            this.weekNumberTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weekNumberTextbox_KeyPress);
            this.weekNumberTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.weekNumberTextbox_KeyUp);
            // 
            // weekNumberLabel
            // 
            this.weekNumberLabel.AutoSize = true;
            this.weekNumberLabel.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.weekNumberLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.weekNumberLabel.Location = new System.Drawing.Point(15, 61);
            this.weekNumberLabel.Name = "weekNumberLabel";
            this.weekNumberLabel.Size = new System.Drawing.Size(63, 19);
            this.weekNumberLabel.TabIndex = 6;
            this.weekNumberLabel.Text = "week 41";
            // 
            // weekSelectButton
            // 
            this.weekSelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.weekSelectButton.FlatAppearance.BorderSize = 0;
            this.weekSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.weekSelectButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekSelectButton.Location = new System.Drawing.Point(597, 38);
            this.weekSelectButton.Name = "weekSelectButton";
            this.weekSelectButton.Size = new System.Drawing.Size(75, 23);
            this.weekSelectButton.TabIndex = 4;
            this.weekSelectButton.Text = "WEEK NR.";
            this.weekSelectButton.UseVisualStyleBackColor = false;
            this.weekSelectButton.Click += new System.EventHandler(this.weekSelectButton_Click);
            // 
            // gotoTodayButton
            // 
            this.gotoTodayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.gotoTodayButton.FlatAppearance.BorderSize = 0;
            this.gotoTodayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoTodayButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gotoTodayButton.Location = new System.Drawing.Point(536, 38);
            this.gotoTodayButton.Name = "gotoTodayButton";
            this.gotoTodayButton.Size = new System.Drawing.Size(58, 23);
            this.gotoTodayButton.TabIndex = 3;
            this.gotoTodayButton.Text = "TODAY";
            this.gotoTodayButton.UseVisualStyleBackColor = false;
            this.gotoTodayButton.Click += new System.EventHandler(this.gotoTodayButton_Click);
            // 
            // buttonRightWeek
            // 
            this.buttonRightWeek.AutoSize = true;
            this.buttonRightWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRightWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRightWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRightWeek.Location = new System.Drawing.Point(286, 31);
            this.buttonRightWeek.Name = "buttonRightWeek";
            this.buttonRightWeek.Size = new System.Drawing.Size(25, 29);
            this.buttonRightWeek.TabIndex = 2;
            this.buttonRightWeek.Text = ">";
            this.buttonRightWeek.Click += new System.EventHandler(this.buttonRightWeek_Click);
            // 
            // buttonLeftWeek
            // 
            this.buttonLeftWeek.AutoSize = true;
            this.buttonLeftWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLeftWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeftWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonLeftWeek.Location = new System.Drawing.Point(253, 31);
            this.buttonLeftWeek.Name = "buttonLeftWeek";
            this.buttonLeftWeek.Size = new System.Drawing.Size(25, 29);
            this.buttonLeftWeek.TabIndex = 1;
            this.buttonLeftWeek.Text = "<";
            this.buttonLeftWeek.Click += new System.EventHandler(this.buttonLeftWeek_Click);
            // 
            // datesInWeek
            // 
            this.datesInWeek.AutoSize = true;
            this.datesInWeek.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datesInWeek.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.datesInWeek.Location = new System.Drawing.Point(14, 32);
            this.datesInWeek.Name = "datesInWeek";
            this.datesInWeek.Size = new System.Drawing.Size(216, 29);
            this.datesInWeek.TabIndex = 0;
            this.datesInWeek.Text = "6-12 November 2017";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 544);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel4.Controls.Add(this.warningInformationLabel);
            this.panel4.Controls.Add(this.bookInformationLabel);
            this.panel4.Controls.Add(this.warningTitleLabel);
            this.panel4.Controls.Add(this.bookingInformationButton);
            this.panel4.Controls.Add(this.instructorTitleInformationLabel);
            this.panel4.Controls.Add(this.instructorInformationLabel);
            this.panel4.Controls.Add(this.timeInformationLabel);
            this.panel4.Controls.Add(this.dateInformationLabel);
            this.panel4.Location = new System.Drawing.Point(20, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(171, 401);
            this.panel4.TabIndex = 9;
            // 
            // warningInformationLabel
            // 
            this.warningInformationLabel.Font = new System.Drawing.Font("Calibri Light", 9F);
            this.warningInformationLabel.Location = new System.Drawing.Point(14, 279);
            this.warningInformationLabel.Name = "warningInformationLabel";
            this.warningInformationLabel.Size = new System.Drawing.Size(141, 75);
            this.warningInformationLabel.TabIndex = 16;
            this.warningInformationLabel.Text = "Kim";
            // 
            // bookInformationLabel
            // 
            this.bookInformationLabel.AutoSize = true;
            this.bookInformationLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookInformationLabel.Location = new System.Drawing.Point(11, 90);
            this.bookInformationLabel.Name = "bookInformationLabel";
            this.bookInformationLabel.Size = new System.Drawing.Size(141, 19);
            this.bookInformationLabel.TabIndex = 15;
            this.bookInformationLabel.Text = "Booking status: 4/24";
            // 
            // warningTitleLabel
            // 
            this.warningTitleLabel.AutoSize = true;
            this.warningTitleLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold);
            this.warningTitleLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.warningTitleLabel.Location = new System.Drawing.Point(49, 260);
            this.warningTitleLabel.Name = "warningTitleLabel";
            this.warningTitleLabel.Size = new System.Drawing.Size(71, 19);
            this.warningTitleLabel.TabIndex = 14;
            this.warningTitleLabel.Text = "Warning";
            this.warningTitleLabel.Visible = false;
            // 
            // bookingInformationButton
            // 
            this.bookingInformationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.bookingInformationButton.FlatAppearance.BorderSize = 0;
            this.bookingInformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookingInformationButton.Font = new System.Drawing.Font("Calibri Light", 9.75F);
            this.bookingInformationButton.ForeColor = System.Drawing.Color.White;
            this.bookingInformationButton.Location = new System.Drawing.Point(30, 357);
            this.bookingInformationButton.Name = "bookingInformationButton";
            this.bookingInformationButton.Size = new System.Drawing.Size(108, 23);
            this.bookingInformationButton.TabIndex = 12;
            this.bookingInformationButton.Text = "UNAVAILABLE";
            this.bookingInformationButton.UseVisualStyleBackColor = false;
            this.bookingInformationButton.Click += new System.EventHandler(this.bookingInformationButton_Click);
            // 
            // instructorTitleInformationLabel
            // 
            this.instructorTitleInformationLabel.AutoSize = true;
            this.instructorTitleInformationLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorTitleInformationLabel.Location = new System.Drawing.Point(11, 122);
            this.instructorTitleInformationLabel.Name = "instructorTitleInformationLabel";
            this.instructorTitleInformationLabel.Size = new System.Drawing.Size(82, 19);
            this.instructorTitleInformationLabel.TabIndex = 11;
            this.instructorTitleInformationLabel.Text = "Instructor";
            // 
            // instructorInformationLabel
            // 
            this.instructorInformationLabel.AutoSize = true;
            this.instructorInformationLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorInformationLabel.Location = new System.Drawing.Point(12, 141);
            this.instructorInformationLabel.Name = "instructorInformationLabel";
            this.instructorInformationLabel.Size = new System.Drawing.Size(34, 19);
            this.instructorInformationLabel.TabIndex = 10;
            this.instructorInformationLabel.Text = "Kim";
            // 
            // timeInformationLabel
            // 
            this.timeInformationLabel.AutoSize = true;
            this.timeInformationLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeInformationLabel.Location = new System.Drawing.Point(12, 61);
            this.timeInformationLabel.Name = "timeInformationLabel";
            this.timeInformationLabel.Size = new System.Drawing.Size(127, 19);
            this.timeInformationLabel.TabIndex = 7;
            this.timeInformationLabel.Text = "Time: 09:00-12:00";
            // 
            // dateInformationLabel
            // 
            this.dateInformationLabel.AutoSize = true;
            this.dateInformationLabel.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateInformationLabel.Location = new System.Drawing.Point(11, 29);
            this.dateInformationLabel.Name = "dateInformationLabel";
            this.dateInformationLabel.Size = new System.Drawing.Size(124, 19);
            this.dateInformationLabel.TabIndex = 6;
            this.dateInformationLabel.Text = "Date: 12/04/2017";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel3.Controls.Add(this.informationLabel);
            this.panel3.Location = new System.Drawing.Point(20, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(171, 93);
            this.panel3.TabIndex = 8;
            // 
            // informationLabel
            // 
            this.informationLabel.Font = new System.Drawing.Font("Calibri Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.informationLabel.Location = new System.Drawing.Point(0, 3);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(171, 80);
            this.informationLabel.TabIndex = 6;
            this.informationLabel.Text = "Select an object";
            this.informationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalendarTabG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelForCalendar);
            this.Name = "CalendarTabG";
            this.Size = new System.Drawing.Size(898, 544);
            this.panelForCalendar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelForCalendar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button gotoTodayButton;
        private System.Windows.Forms.Label buttonRightWeek;
        private System.Windows.Forms.Label buttonLeftWeek;
        private System.Windows.Forms.Label datesInWeek;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button weekSelectButton;
        private System.Windows.Forms.Panel backPanel;
        private System.Windows.Forms.Label weekNumberLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label instructorTitleInformationLabel;
        private System.Windows.Forms.Label instructorInformationLabel;
        private System.Windows.Forms.Label timeInformationLabel;
        private System.Windows.Forms.Label dateInformationLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Button bookingInformationButton;
        private System.Windows.Forms.TextBox weekNumberTextbox;
        private System.Windows.Forms.Label warningTitleLabel;
        private System.Windows.Forms.Label bookInformationLabel;
        private System.Windows.Forms.Label warningInformationLabel;
    }
}