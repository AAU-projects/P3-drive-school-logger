namespace DriveLogGUI
{
    partial class MainWindowTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowTab));
            this.leftSidePanel = new System.Windows.Forms.Panel();
            this.labelForTitle2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.userSearchButton = new System.Windows.Forms.Button();
            this.panelForProfile = new System.Windows.Forms.Panel();
            this.firstAidButton = new System.Windows.Forms.Button();
            this.doctorsNoteButton = new System.Windows.Forms.Button();
            this.driveLogButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.bookingButton = new System.Windows.Forms.Button();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.OverviewButton = new System.Windows.Forms.Button();
            this.labelForTitle = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureSearchTab = new System.Windows.Forms.PictureBox();
            this.pictureBookingTab = new System.Windows.Forms.PictureBox();
            this.pictureSettingsTab = new System.Windows.Forms.PictureBox();
            this.pictureProfileTab = new System.Windows.Forms.PictureBox();
            this.pictureHomeTab = new System.Windows.Forms.PictureBox();
            this.leftSidePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelForProfile.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBookingTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettingsTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfileTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHomeTab)).BeginInit();
            this.SuspendLayout();
            // 
            // leftSidePanel
            // 
            this.leftSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.leftSidePanel.Controls.Add(this.labelForTitle2);
            this.leftSidePanel.Controls.Add(this.panel4);
            this.leftSidePanel.Controls.Add(this.labelForTitle);
            this.leftSidePanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.leftSidePanel.Location = new System.Drawing.Point(0, 0);
            this.leftSidePanel.Name = "leftSidePanel";
            this.leftSidePanel.Size = new System.Drawing.Size(132, 564);
            this.leftSidePanel.TabIndex = 0;
            // 
            // labelForTitle2
            // 
            this.labelForTitle2.AutoSize = true;
            this.labelForTitle2.BackColor = System.Drawing.Color.Transparent;
            this.labelForTitle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForTitle2.ForeColor = System.Drawing.Color.White;
            this.labelForTitle2.Location = new System.Drawing.Point(4, 20);
            this.labelForTitle2.Name = "labelForTitle2";
            this.labelForTitle2.Size = new System.Drawing.Size(84, 18);
            this.labelForTitle2.TabIndex = 1;
            this.labelForTitle2.Text = "Køreskolen";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureSearchTab);
            this.panel4.Controls.Add(this.userSearchButton);
            this.panel4.Controls.Add(this.panelForProfile);
            this.panel4.Controls.Add(this.pictureBookingTab);
            this.panel4.Controls.Add(this.pictureSettingsTab);
            this.panel4.Controls.Add(this.pictureProfileTab);
            this.panel4.Controls.Add(this.pictureHomeTab);
            this.panel4.Controls.Add(this.settingsButton);
            this.panel4.Controls.Add(this.bookingButton);
            this.panel4.Controls.Add(this.ProfileButton);
            this.panel4.Controls.Add(this.OverviewButton);
            this.panel4.Location = new System.Drawing.Point(0, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(132, 315);
            this.panel4.TabIndex = 0;
            // 
            // userSearchButton
            // 
            this.userSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userSearchButton.Enabled = false;
            this.userSearchButton.FlatAppearance.BorderSize = 0;
            this.userSearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.userSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSearchButton.ForeColor = System.Drawing.Color.White;
            this.userSearchButton.Location = new System.Drawing.Point(0, 104);
            this.userSearchButton.Name = "userSearchButton";
            this.userSearchButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userSearchButton.Size = new System.Drawing.Size(132, 36);
            this.userSearchButton.TabIndex = 4;
            this.userSearchButton.Text = "Users";
            this.userSearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userSearchButton.UseVisualStyleBackColor = true;
            this.userSearchButton.Visible = false;
            this.userSearchButton.Click += new System.EventHandler(this.userSearchButton_Click);
            // 
            // panelForProfile
            // 
            this.panelForProfile.Controls.Add(this.firstAidButton);
            this.panelForProfile.Controls.Add(this.doctorsNoteButton);
            this.panelForProfile.Controls.Add(this.driveLogButton);
            this.panelForProfile.Location = new System.Drawing.Point(0, 188);
            this.panelForProfile.Name = "panelForProfile";
            this.panelForProfile.Size = new System.Drawing.Size(200, 96);
            this.panelForProfile.TabIndex = 1;
            this.panelForProfile.Visible = false;
            // 
            // firstAidButton
            // 
            this.firstAidButton.FlatAppearance.BorderSize = 0;
            this.firstAidButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.firstAidButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstAidButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstAidButton.ForeColor = System.Drawing.Color.White;
            this.firstAidButton.Location = new System.Drawing.Point(24, 64);
            this.firstAidButton.Name = "firstAidButton";
            this.firstAidButton.Size = new System.Drawing.Size(108, 32);
            this.firstAidButton.TabIndex = 6;
            this.firstAidButton.Text = "First aid";
            this.firstAidButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.firstAidButton.UseVisualStyleBackColor = true;
            this.firstAidButton.Click += new System.EventHandler(this.firstAidButton_Click);
            // 
            // doctorsNoteButton
            // 
            this.doctorsNoteButton.FlatAppearance.BorderSize = 0;
            this.doctorsNoteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.doctorsNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doctorsNoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doctorsNoteButton.ForeColor = System.Drawing.Color.White;
            this.doctorsNoteButton.Location = new System.Drawing.Point(24, 32);
            this.doctorsNoteButton.Name = "doctorsNoteButton";
            this.doctorsNoteButton.Size = new System.Drawing.Size(108, 32);
            this.doctorsNoteButton.TabIndex = 5;
            this.doctorsNoteButton.Text = "Doctors note";
            this.doctorsNoteButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.doctorsNoteButton.UseVisualStyleBackColor = true;
            this.doctorsNoteButton.Click += new System.EventHandler(this.doctorsNoteButton_Click_1);
            // 
            // driveLogButton
            // 
            this.driveLogButton.FlatAppearance.BorderSize = 0;
            this.driveLogButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.driveLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.driveLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveLogButton.ForeColor = System.Drawing.Color.White;
            this.driveLogButton.Location = new System.Drawing.Point(24, 0);
            this.driveLogButton.Name = "driveLogButton";
            this.driveLogButton.Size = new System.Drawing.Size(108, 32);
            this.driveLogButton.TabIndex = 4;
            this.driveLogButton.Text = "Drivers log";
            this.driveLogButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.driveLogButton.UseVisualStyleBackColor = true;
            this.driveLogButton.Click += new System.EventHandler(this.driveLogButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Location = new System.Drawing.Point(0, 104);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingsButton.Size = new System.Drawing.Size(132, 36);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Settings";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // bookingButton
            // 
            this.bookingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bookingButton.FlatAppearance.BorderSize = 0;
            this.bookingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.bookingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bookingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookingButton.ForeColor = System.Drawing.Color.White;
            this.bookingButton.Location = new System.Drawing.Point(0, 70);
            this.bookingButton.Name = "bookingButton";
            this.bookingButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bookingButton.Size = new System.Drawing.Size(132, 36);
            this.bookingButton.TabIndex = 2;
            this.bookingButton.Text = "Booking";
            this.bookingButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bookingButton.UseVisualStyleBackColor = true;
            this.bookingButton.Click += new System.EventHandler(this.bookingButton_Click);
            // 
            // ProfileButton
            // 
            this.ProfileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProfileButton.FlatAppearance.BorderSize = 0;
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.ForeColor = System.Drawing.Color.White;
            this.ProfileButton.Location = new System.Drawing.Point(0, 36);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ProfileButton.Size = new System.Drawing.Size(132, 36);
            this.ProfileButton.TabIndex = 1;
            this.ProfileButton.Text = "Profile";
            this.ProfileButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProfileButton.UseVisualStyleBackColor = true;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // OverviewButton
            // 
            this.OverviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OverviewButton.FlatAppearance.BorderSize = 0;
            this.OverviewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.OverviewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OverviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverviewButton.ForeColor = System.Drawing.Color.White;
            this.OverviewButton.Location = new System.Drawing.Point(0, 0);
            this.OverviewButton.Name = "OverviewButton";
            this.OverviewButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.OverviewButton.Size = new System.Drawing.Size(132, 36);
            this.OverviewButton.TabIndex = 0;
            this.OverviewButton.Text = "Overview";
            this.OverviewButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OverviewButton.UseVisualStyleBackColor = true;
            this.OverviewButton.Click += new System.EventHandler(this.OverviewButton_Click);
            // 
            // labelForTitle
            // 
            this.labelForTitle.AutoSize = true;
            this.labelForTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelForTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForTitle.ForeColor = System.Drawing.Color.White;
            this.labelForTitle.Location = new System.Drawing.Point(3, 0);
            this.labelForTitle.Name = "labelForTitle";
            this.labelForTitle.Size = new System.Drawing.Size(51, 24);
            this.labelForTitle.TabIndex = 0;
            this.labelForTitle.Text = "CITY";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.button2);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Location = new System.Drawing.Point(132, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 22);
            this.topPanel.TabIndex = 1;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(848, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 22);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button2_MouseClick);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DriveLogGUI.Properties.Resources.exit6;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(873, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureSearchTab
            // 
            this.pictureSearchTab.BackColor = System.Drawing.Color.Transparent;
            this.pictureSearchTab.Enabled = false;
            this.pictureSearchTab.Image = ((System.Drawing.Image)(resources.GetObject("pictureSearchTab.Image")));
            this.pictureSearchTab.Location = new System.Drawing.Point(3, 0);
            this.pictureSearchTab.Name = "pictureSearchTab";
            this.pictureSearchTab.Size = new System.Drawing.Size(30, 30);
            this.pictureSearchTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSearchTab.TabIndex = 7;
            this.pictureSearchTab.TabStop = false;
            this.pictureSearchTab.Visible = false;
            // 
            // pictureBookingTab
            // 
            this.pictureBookingTab.BackColor = System.Drawing.Color.Transparent;
            this.pictureBookingTab.Image = ((System.Drawing.Image)(resources.GetObject("pictureBookingTab.Image")));
            this.pictureBookingTab.Location = new System.Drawing.Point(0, 0);
            this.pictureBookingTab.Name = "pictureBookingTab";
            this.pictureBookingTab.Size = new System.Drawing.Size(30, 30);
            this.pictureBookingTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBookingTab.TabIndex = 5;
            this.pictureBookingTab.TabStop = false;
            // 
            // pictureSettingsTab
            // 
            this.pictureSettingsTab.BackColor = System.Drawing.Color.Transparent;
            this.pictureSettingsTab.Image = ((System.Drawing.Image)(resources.GetObject("pictureSettingsTab.Image")));
            this.pictureSettingsTab.Location = new System.Drawing.Point(0, 0);
            this.pictureSettingsTab.Name = "pictureSettingsTab";
            this.pictureSettingsTab.Size = new System.Drawing.Size(30, 30);
            this.pictureSettingsTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSettingsTab.TabIndex = 6;
            this.pictureSettingsTab.TabStop = false;
            // 
            // pictureProfileTab
            // 
            this.pictureProfileTab.BackColor = System.Drawing.Color.Transparent;
            this.pictureProfileTab.Image = ((System.Drawing.Image)(resources.GetObject("pictureProfileTab.Image")));
            this.pictureProfileTab.Location = new System.Drawing.Point(0, 0);
            this.pictureProfileTab.Name = "pictureProfileTab";
            this.pictureProfileTab.Size = new System.Drawing.Size(30, 30);
            this.pictureProfileTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProfileTab.TabIndex = 4;
            this.pictureProfileTab.TabStop = false;
            // 
            // pictureHomeTab
            // 
            this.pictureHomeTab.BackColor = System.Drawing.Color.Transparent;
            this.pictureHomeTab.Image = ((System.Drawing.Image)(resources.GetObject("pictureHomeTab.Image")));
            this.pictureHomeTab.Location = new System.Drawing.Point(0, 0);
            this.pictureHomeTab.Name = "pictureHomeTab";
            this.pictureHomeTab.Size = new System.Drawing.Size(30, 30);
            this.pictureHomeTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureHomeTab.TabIndex = 0;
            this.pictureHomeTab.TabStop = false;
            // 
            // MainWindowTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 564);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.leftSidePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindowTab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindowTab";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindowTab_FormClosing);
            this.leftSidePanel.ResumeLayout(false);
            this.leftSidePanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panelForProfile.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBookingTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettingsTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfileTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHomeTab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftSidePanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label labelForTitle2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button bookingButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button OverviewButton;
        private System.Windows.Forms.Label labelForTitle;
        private System.Windows.Forms.Panel panelForProfile;
        private System.Windows.Forms.Button firstAidButton;
        private System.Windows.Forms.Button doctorsNoteButton;
        private System.Windows.Forms.Button driveLogButton;
        private System.Windows.Forms.PictureBox pictureSettingsTab;
        private System.Windows.Forms.PictureBox pictureBookingTab;
        private System.Windows.Forms.PictureBox pictureHomeTab;
        private System.Windows.Forms.PictureBox pictureProfileTab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button userSearchButton;
        private System.Windows.Forms.PictureBox pictureSearchTab;
    }
}