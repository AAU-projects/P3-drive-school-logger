namespace DriveLogGUI
{
    partial class RegisterForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registerSubtitleLabel = new System.Windows.Forms.Label();
            this.registerUploadPhotoButton = new System.Windows.Forms.Button();
            this.registerCreateNewUserButton = new System.Windows.Forms.Button();
            this.registerCancelHyperLink = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.registerPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.verifyPasswordBox = new TextboxBorderColor();
            this.registerZipBox = new TextboxBorderColor();
            this.registerCityBox = new TextboxBorderColor();
            this.registerAdressBox = new TextboxBorderColor();
            this.registerCprBox = new TextboxBorderColor();
            this.registerEmailBox = new TextboxBorderColor();
            this.registerPhoneBox = new TextboxBorderColor();
            this.registerLastnameBox = new TextboxBorderColor();
            this.registerFirstnameBox = new TextboxBorderColor();
            this.registerPasswordBox = new TextboxBorderColor();
            this.registerUsernameBox = new TextboxBorderColor();
            this.vertifyPasswordStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // registerSubtitleLabel
            // 
            this.registerSubtitleLabel.AutoSize = true;
            this.registerSubtitleLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.registerSubtitleLabel.Location = new System.Drawing.Point(17, 9);
            this.registerSubtitleLabel.Name = "registerSubtitleLabel";
            this.registerSubtitleLabel.Size = new System.Drawing.Size(191, 33);
            this.registerSubtitleLabel.TabIndex = 21;
            this.registerSubtitleLabel.Text = "Create new user";
            // 
            // registerUploadPhotoButton
            // 
            this.registerUploadPhotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.registerUploadPhotoButton.FlatAppearance.BorderSize = 0;
            this.registerUploadPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerUploadPhotoButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.registerUploadPhotoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.registerUploadPhotoButton.Location = new System.Drawing.Point(162, 94);
            this.registerUploadPhotoButton.Name = "registerUploadPhotoButton";
            this.registerUploadPhotoButton.Size = new System.Drawing.Size(346, 46);
            this.registerUploadPhotoButton.TabIndex = 11;
            this.registerUploadPhotoButton.Text = "Upload Profile Picture";
            this.registerUploadPhotoButton.UseVisualStyleBackColor = false;
            this.registerUploadPhotoButton.Click += new System.EventHandler(this.registerUploadPhotoButton_Click);
            // 
            // registerCreateNewUserButton
            // 
            this.registerCreateNewUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.registerCreateNewUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerCreateNewUserButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.registerCreateNewUserButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.registerCreateNewUserButton.Location = new System.Drawing.Point(23, 625);
            this.registerCreateNewUserButton.Name = "registerCreateNewUserButton";
            this.registerCreateNewUserButton.Size = new System.Drawing.Size(485, 46);
            this.registerCreateNewUserButton.TabIndex = 12;
            this.registerCreateNewUserButton.Text = "Create";
            this.registerCreateNewUserButton.UseVisualStyleBackColor = false;
            this.registerCreateNewUserButton.Click += new System.EventHandler(this.registerCreateNewUserButton_Click);
            // 
            // registerCancelHyperLink
            // 
            this.registerCancelHyperLink.AutoSize = true;
            this.registerCancelHyperLink.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.registerCancelHyperLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.registerCancelHyperLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.registerCancelHyperLink.Location = new System.Drawing.Point(239, 674);
            this.registerCancelHyperLink.Name = "registerCancelHyperLink";
            this.registerCancelHyperLink.Size = new System.Drawing.Size(53, 19);
            this.registerCancelHyperLink.TabIndex = 13;
            this.registerCancelHyperLink.TabStop = true;
            this.registerCancelHyperLink.Text = "Cancel";
            this.registerCancelHyperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerCancelHyperLink_LinkClicked);
            // 
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStatusLabel.Location = new System.Drawing.Point(20, 605);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(93, 15);
            this.passwordStatusLabel.TabIndex = 28;
            this.passwordStatusLabel.Text = "StatusPassword";
            // 
            // registerPicture
            // 
            this.registerPicture.Image = global::DriveLogGUI.Properties.Resources.avataricon;
            this.registerPicture.InitialImage = global::DriveLogGUI.Properties.Resources.avataricon;
            this.registerPicture.Location = new System.Drawing.Point(23, 57);
            this.registerPicture.Name = "registerPicture";
            this.registerPicture.Size = new System.Drawing.Size(121, 118);
            this.registerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.registerPicture.TabIndex = 29;
            this.registerPicture.TabStop = false;
            this.registerPicture.Click += new System.EventHandler(this.registerPicture_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.label1.Location = new System.Drawing.Point(17, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 33);
            this.label1.TabIndex = 40;
            this.label1.Text = "Personal Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.label2.Location = new System.Drawing.Point(17, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 33);
            this.label2.TabIndex = 41;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.label3.Location = new System.Drawing.Point(17, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 33);
            this.label3.TabIndex = 42;
            this.label3.Text = "Account Details";
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.verifyPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyPasswordBox.DefaultText = "Verify Password";
            this.verifyPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyPasswordBox.Location = new System.Drawing.Point(271, 577);
            this.verifyPasswordBox.Name = "verifyPasswordBox";
            this.verifyPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.verifyPasswordBox.TabIndex = 10;
            this.verifyPasswordBox.Text = "Verify Password";
            this.verifyPasswordBox.Click += new System.EventHandler(this.verifyPasswordBox_Click);
            this.verifyPasswordBox.TextChanged += new System.EventHandler(this.verifyPasswordBox_TextChanged);
            // 
            // registerZipBox
            // 
            this.registerZipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerZipBox.BorderColor = System.Drawing.Color.Blue;
            this.registerZipBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerZipBox.DefaultText = "Zip Code";
            this.registerZipBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerZipBox.Location = new System.Drawing.Point(23, 442);
            this.registerZipBox.Name = "registerZipBox";
            this.registerZipBox.Size = new System.Drawing.Size(237, 23);
            this.registerZipBox.TabIndex = 6;
            this.registerZipBox.Text = "Zip Code";
            this.registerZipBox.Click += new System.EventHandler(this.registerZipBox_Click);
            this.registerZipBox.Leave += new System.EventHandler(this.registerZipBox_Leave);
            // 
            // registerCityBox
            // 
            this.registerCityBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerCityBox.BorderColor = System.Drawing.Color.Blue;
            this.registerCityBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerCityBox.DefaultText = "City";
            this.registerCityBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerCityBox.Location = new System.Drawing.Point(271, 442);
            this.registerCityBox.Name = "registerCityBox";
            this.registerCityBox.Size = new System.Drawing.Size(237, 23);
            this.registerCityBox.TabIndex = 7;
            this.registerCityBox.Text = "City";
            this.registerCityBox.Click += new System.EventHandler(this.registerCityBox_Click);
            this.registerCityBox.TextChanged += new System.EventHandler(this.registerCityBox_TextChanged);
            this.registerCityBox.Leave += new System.EventHandler(this.registerCityBox_Leave);
            // 
            // registerAdressBox
            // 
            this.registerAdressBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerAdressBox.BorderColor = System.Drawing.Color.Blue;
            this.registerAdressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerAdressBox.DefaultText = "Address";
            this.registerAdressBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerAdressBox.Location = new System.Drawing.Point(23, 402);
            this.registerAdressBox.Name = "registerAdressBox";
            this.registerAdressBox.Size = new System.Drawing.Size(237, 23);
            this.registerAdressBox.TabIndex = 5;
            this.registerAdressBox.Text = "Address";
            this.registerAdressBox.Click += new System.EventHandler(this.registerAdressBox_Click);
            this.registerAdressBox.Leave += new System.EventHandler(this.registerAdressBox_Leave);
            // 
            // registerCprBox
            // 
            this.registerCprBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerCprBox.BorderColor = System.Drawing.Color.Blue;
            this.registerCprBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerCprBox.DefaultText = "CPR";
            this.registerCprBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerCprBox.Location = new System.Drawing.Point(271, 278);
            this.registerCprBox.Name = "registerCprBox";
            this.registerCprBox.Size = new System.Drawing.Size(237, 23);
            this.registerCprBox.TabIndex = 4;
            this.registerCprBox.Text = "CPR";
            this.registerCprBox.Click += new System.EventHandler(this.registerCprBox_Click);
            this.registerCprBox.Leave += new System.EventHandler(this.registerCprBox_Leave);
            // 
            // registerEmailBox
            // 
            this.registerEmailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerEmailBox.BorderColor = System.Drawing.Color.Blue;
            this.registerEmailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerEmailBox.DefaultText = "Email Address";
            this.registerEmailBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerEmailBox.Location = new System.Drawing.Point(23, 317);
            this.registerEmailBox.Name = "registerEmailBox";
            this.registerEmailBox.Size = new System.Drawing.Size(237, 23);
            this.registerEmailBox.TabIndex = 3;
            this.registerEmailBox.Text = "Email Address";
            this.registerEmailBox.Click += new System.EventHandler(this.registerEmailBox_Click);
            this.registerEmailBox.Leave += new System.EventHandler(this.registerEmailBox_Leave);
            // 
            // registerPhoneBox
            // 
            this.registerPhoneBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerPhoneBox.BorderColor = System.Drawing.Color.Blue;
            this.registerPhoneBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerPhoneBox.DefaultText = "Phone Number";
            this.registerPhoneBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerPhoneBox.Location = new System.Drawing.Point(23, 278);
            this.registerPhoneBox.Name = "registerPhoneBox";
            this.registerPhoneBox.Size = new System.Drawing.Size(237, 23);
            this.registerPhoneBox.TabIndex = 2;
            this.registerPhoneBox.Text = "Phone Number";
            this.registerPhoneBox.Click += new System.EventHandler(this.registerPhoneBox_Click);
            this.registerPhoneBox.Leave += new System.EventHandler(this.registerPhoneBox_Leave);
            // 
            // registerLastnameBox
            // 
            this.registerLastnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerLastnameBox.BorderColor = System.Drawing.Color.Blue;
            this.registerLastnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerLastnameBox.DefaultText = "Lastname";
            this.registerLastnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerLastnameBox.Location = new System.Drawing.Point(271, 239);
            this.registerLastnameBox.Name = "registerLastnameBox";
            this.registerLastnameBox.Size = new System.Drawing.Size(237, 23);
            this.registerLastnameBox.TabIndex = 1;
            this.registerLastnameBox.Text = "Lastname";
            this.registerLastnameBox.Click += new System.EventHandler(this.registerLastnameBox_Click);
            this.registerLastnameBox.Leave += new System.EventHandler(this.registerLastnameBox_Leave);
            // 
            // registerFirstnameBox
            // 
            this.registerFirstnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerFirstnameBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerFirstnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerFirstnameBox.DefaultText = "Firstname";
            this.registerFirstnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerFirstnameBox.Location = new System.Drawing.Point(23, 239);
            this.registerFirstnameBox.Name = "registerFirstnameBox";
            this.registerFirstnameBox.ShortcutsEnabled = false;
            this.registerFirstnameBox.Size = new System.Drawing.Size(237, 23);
            this.registerFirstnameBox.TabIndex = 0;
            this.registerFirstnameBox.Text = "Firstname";
            this.registerFirstnameBox.Click += new System.EventHandler(this.registerFirstnameBox_Click);
            this.registerFirstnameBox.Leave += new System.EventHandler(this.registerFirstnameBox_Leave);
            // 
            // registerPasswordBox
            // 
            this.registerPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.registerPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerPasswordBox.DefaultText = "Password";
            this.registerPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerPasswordBox.Location = new System.Drawing.Point(23, 577);
            this.registerPasswordBox.Name = "registerPasswordBox";
            this.registerPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.registerPasswordBox.TabIndex = 9;
            this.registerPasswordBox.Text = "Password";
            this.registerPasswordBox.Click += new System.EventHandler(this.registerPasswordBox_Click);
            this.registerPasswordBox.TextChanged += new System.EventHandler(this.registerPasswordBox_TextChanged);
            // 
            // registerUsernameBox
            // 
            this.registerUsernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerUsernameBox.BorderColor = System.Drawing.Color.Blue;
            this.registerUsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerUsernameBox.DefaultText = "Username";
            this.registerUsernameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerUsernameBox.Location = new System.Drawing.Point(23, 535);
            this.registerUsernameBox.Name = "registerUsernameBox";
            this.registerUsernameBox.Size = new System.Drawing.Size(237, 23);
            this.registerUsernameBox.TabIndex = 8;
            this.registerUsernameBox.Text = "Username";
            this.registerUsernameBox.Click += new System.EventHandler(this.registerUsernameBox_Click);
            this.registerUsernameBox.Leave += new System.EventHandler(this.registerUsernameBox_Leave);
            // 
            // vertifyPasswordStatusLabel
            // 
            this.vertifyPasswordStatusLabel.AutoSize = true;
            this.vertifyPasswordStatusLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.vertifyPasswordStatusLabel.Location = new System.Drawing.Point(268, 604);
            this.vertifyPasswordStatusLabel.Name = "vertifyPasswordStatusLabel";
            this.vertifyPasswordStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.vertifyPasswordStatusLabel.TabIndex = 30;
            this.vertifyPasswordStatusLabel.Text = "StatusVerify";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(529, 705);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vertifyPasswordStatusLabel);
            this.Controls.Add(this.registerPicture);
            this.Controls.Add(this.passwordStatusLabel);
            this.Controls.Add(this.verifyPasswordBox);
            this.Controls.Add(this.registerCancelHyperLink);
            this.Controls.Add(this.registerCreateNewUserButton);
            this.Controls.Add(this.registerUploadPhotoButton);
            this.Controls.Add(this.registerSubtitleLabel);
            this.Controls.Add(this.registerZipBox);
            this.Controls.Add(this.registerCityBox);
            this.Controls.Add(this.registerAdressBox);
            this.Controls.Add(this.registerCprBox);
            this.Controls.Add(this.registerEmailBox);
            this.Controls.Add(this.registerPhoneBox);
            this.Controls.Add(this.registerLastnameBox);
            this.Controls.Add(this.registerFirstnameBox);
            this.Controls.Add(this.registerPasswordBox);
            this.Controls.Add(this.registerUsernameBox);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextboxBorderColor registerFirstnameBox;
        private TextboxBorderColor registerUsernameBox;
        private TextboxBorderColor registerPasswordBox;
        private TextboxBorderColor registerLastnameBox;
        private TextboxBorderColor registerPhoneBox;
        private TextboxBorderColor registerEmailBox;
        private TextboxBorderColor registerCprBox;
        private TextboxBorderColor registerAdressBox;
        private TextboxBorderColor registerCityBox;
        private TextboxBorderColor registerZipBox;
        private System.Windows.Forms.Label registerSubtitleLabel;
        private System.Windows.Forms.Button registerUploadPhotoButton;
        private System.Windows.Forms.Button registerCreateNewUserButton;
        private System.Windows.Forms.LinkLabel registerCancelHyperLink;
        private TextboxBorderColor verifyPasswordBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label passwordStatusLabel;
        private System.Windows.Forms.PictureBox registerPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label vertifyPasswordStatusLabel;
    }
}