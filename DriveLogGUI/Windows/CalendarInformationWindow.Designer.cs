namespace DriveLogGUI.Windows
{
    partial class CalendarInformationWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.pictureBoxCalendarInformation = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalendarInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.CloseButton);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(897, 22);
            this.topPanel.TabIndex = 4;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // pictureBoxCalendarInformation
            // 
            this.pictureBoxCalendarInformation.Image = global::DriveLogGUI.Properties.Resources.calendarInformation;
            this.pictureBoxCalendarInformation.Location = new System.Drawing.Point(0, 22);
            this.pictureBoxCalendarInformation.Name = "pictureBoxCalendarInformation";
            this.pictureBoxCalendarInformation.Size = new System.Drawing.Size(898, 555);
            this.pictureBoxCalendarInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCalendarInformation.TabIndex = 5;
            this.pictureBoxCalendarInformation.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::DriveLogGUI.Properties.Resources.exit6;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(872, -1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 22);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.ReshowDelay = 100;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 88);
            this.panel1.TabIndex = 8;
            this.toolTip1.SetToolTip(this.panel1, "The same data is shown here as the selected appointment label in the calendar");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 115);
            this.panel2.TabIndex = 9;
            this.toolTip1.SetToolTip(this.panel2, "A more detailed data is given for the selected appointment here, including the sp" +
        "ecific date, timeperiod, and booking status");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(0, 301);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 83);
            this.panel3.TabIndex = 10;
            this.toolTip1.SetToolTip(this.panel3, "A more detailed description of why you can not book the selected appointment can " +
        "be seen here");
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Location = new System.Drawing.Point(0, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 108);
            this.panel4.TabIndex = 11;
            this.toolTip1.SetToolTip(this.panel4, "All labels that can not be booked are marked with a colored label, which means di" +
        "fferent things. ");
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Location = new System.Drawing.Point(209, 179);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(223, 104);
            this.panel5.TabIndex = 12;
            this.toolTip1.SetToolTip(this.panel5, "When an appointment is greyed out it means its no longer releant for the user,t t" +
        "his can happen for different reasons.");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Location = new System.Drawing.Point(701, 179);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(161, 104);
            this.panel6.TabIndex = 13;
            this.toolTip1.SetToolTip(this.panel6, "These panels have not been marked with a color, and are not greyed out. This mean" +
        "s they are bookable.");
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Location = new System.Drawing.Point(504, 112);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(121, 64);
            this.panel7.TabIndex = 14;
            this.toolTip1.SetToolTip(this.panel7, "This is the current date, marked with a more dark panel.");
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Location = new System.Drawing.Point(221, 43);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(230, 67);
            this.panel8.TabIndex = 15;
            this.toolTip1.SetToolTip(this.panel8, "All the data for the specific date and week can be seen here");
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Location = new System.Drawing.Point(457, 28);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(93, 82);
            this.panel9.TabIndex = 16;
            this.toolTip1.SetToolTip(this.panel9, "You may navigate through the weeks with the arrows");
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Transparent;
            this.panel10.Location = new System.Drawing.Point(719, 22);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(88, 88);
            this.panel10.TabIndex = 17;
            this.toolTip1.SetToolTip(this.panel10, "Clicking this button will take you to the current week that today would be in.");
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Location = new System.Drawing.Point(813, 22);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(72, 88);
            this.panel11.TabIndex = 18;
            this.toolTip1.SetToolTip(this.panel11, "You may type a specific week number which will take you to that week in the selec" +
        "ted year.");
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Location = new System.Drawing.Point(35, 504);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(136, 48);
            this.panel12.TabIndex = 19;
            this.toolTip1.SetToolTip(this.panel12, "This button changes depending on which appointment is selected. There are three d" +
        "ifferent states, book, cancel, unavailable.\r\n");
            // 
            // CalendarInformationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 578);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxCalendarInformation);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalendarInformationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CalendarInformationWindow";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalendarInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.PictureBox pictureBoxCalendarInformation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
    }
}