namespace DriveLogGUI
{
    partial class EditUserInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditUserInfoForm));
            this.verifyPasswordLabel = new System.Windows.Forms.Label();
            this.editProfileHeaderLabel = new System.Windows.Forms.Label();
            this.verifyPasswordInfo = new System.Windows.Forms.Label();
            this.verifyPasswordBox = new TextboxBorderColor();
            this.topPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.usernameBox = new TextboxBorderColor();
            this.editPasswordBox = new TextboxBorderColor();
            this.verifyEditPasswordBox = new TextboxBorderColor();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.vertifyPasswordStatusLabel = new System.Windows.Forms.Label();
            this.accountDetailsLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.personalInformationLabel = new System.Windows.Forms.Label();
            this.zipBox = new TextboxBorderColor();
            this.cityBox = new TextboxBorderColor();
            this.addressBox = new TextboxBorderColor();
            this.emailBox = new TextboxBorderColor();
            this.phoneBox = new TextboxBorderColor();
            this.lastnameBox = new TextboxBorderColor();
            this.firstnameBox = new TextboxBorderColor();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.editPictureButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyPasswordLabel
            // 
            this.verifyPasswordLabel.AutoSize = true;
            this.verifyPasswordLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.verifyPasswordLabel.Location = new System.Drawing.Point(12, 91);
            this.verifyPasswordLabel.Name = "verifyPasswordLabel";
            this.verifyPasswordLabel.Size = new System.Drawing.Size(187, 33);
            this.verifyPasswordLabel.TabIndex = 43;
            this.verifyPasswordLabel.Text = "Verify Password";
            // 
            // editProfileHeaderLabel
            // 
            this.editProfileHeaderLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editProfileHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.editProfileHeaderLabel.Location = new System.Drawing.Point(0, 40);
            this.editProfileHeaderLabel.Name = "editProfileHeaderLabel";
            this.editProfileHeaderLabel.Size = new System.Drawing.Size(529, 33);
            this.editProfileHeaderLabel.TabIndex = 44;
            this.editProfileHeaderLabel.Text = "Edit user information";
            this.editProfileHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verifyPasswordInfo
            // 
            this.verifyPasswordInfo.AutoSize = true;
            this.verifyPasswordInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.verifyPasswordInfo.Location = new System.Drawing.Point(15, 124);
            this.verifyPasswordInfo.Name = "verifyPasswordInfo";
            this.verifyPasswordInfo.Size = new System.Drawing.Size(258, 13);
            this.verifyPasswordInfo.TabIndex = 45;
            this.verifyPasswordInfo.Text = "Please enter your current password to make changes";
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.verifyPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyPasswordBox.DefaultText = "Password";
            this.verifyPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.verifyPasswordBox.Location = new System.Drawing.Point(18, 149);
            this.verifyPasswordBox.Name = "verifyPasswordBox";
            this.verifyPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.verifyPasswordBox.TabIndex = 0;
            this.verifyPasswordBox.Text = "Password";
            this.verifyPasswordBox.TextChanged += new System.EventHandler(this.verifyPasswordBox_TextChanged);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Controls.Add(this.button1);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(529, 22);
            this.topPanel.TabIndex = 47;
            // 
            // closeButton
            // 
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(504, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 22);
            this.closeButton.TabIndex = 44;
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(873, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 22);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.usernameBox.BorderColor = System.Drawing.Color.Blue;
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameBox.DefaultText = "Username";
            this.usernameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.usernameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.usernameBox.Location = new System.Drawing.Point(18, 228);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.ReadOnly = true;
            this.usernameBox.Size = new System.Drawing.Size(237, 23);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Username";
            // 
            // editPasswordBox
            // 
            this.editPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.editPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.editPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editPasswordBox.DefaultText = "Password";
            this.editPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.editPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.editPasswordBox.Location = new System.Drawing.Point(18, 270);
            this.editPasswordBox.Name = "editPasswordBox";
            this.editPasswordBox.ReadOnly = true;
            this.editPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.editPasswordBox.TabIndex = 2;
            this.editPasswordBox.Text = "Password";
            // 
            // verifyEditPasswordBox
            // 
            this.verifyEditPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.verifyEditPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyEditPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyEditPasswordBox.DefaultText = "Verify Password";
            this.verifyEditPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyEditPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.verifyEditPasswordBox.Location = new System.Drawing.Point(18, 316);
            this.verifyEditPasswordBox.Name = "verifyEditPasswordBox";
            this.verifyEditPasswordBox.ReadOnly = true;
            this.verifyEditPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.verifyEditPasswordBox.TabIndex = 3;
            this.verifyEditPasswordBox.Text = "Verify Password";
            // 
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStatusLabel.Location = new System.Drawing.Point(15, 298);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(93, 15);
            this.passwordStatusLabel.TabIndex = 51;
            this.passwordStatusLabel.Text = "StatusPassword";
            // 
            // vertifyPasswordStatusLabel
            // 
            this.vertifyPasswordStatusLabel.AutoSize = true;
            this.vertifyPasswordStatusLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.vertifyPasswordStatusLabel.Location = new System.Drawing.Point(15, 343);
            this.vertifyPasswordStatusLabel.Name = "vertifyPasswordStatusLabel";
            this.vertifyPasswordStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.vertifyPasswordStatusLabel.TabIndex = 52;
            this.vertifyPasswordStatusLabel.Text = "StatusVerify";
            // 
            // accountDetailsLabel
            // 
            this.accountDetailsLabel.AutoSize = true;
            this.accountDetailsLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountDetailsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.accountDetailsLabel.Location = new System.Drawing.Point(14, 192);
            this.accountDetailsLabel.Name = "accountDetailsLabel";
            this.accountDetailsLabel.Size = new System.Drawing.Size(185, 33);
            this.accountDetailsLabel.TabIndex = 53;
            this.accountDetailsLabel.Text = "Account Details";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.addressLabel.Location = new System.Drawing.Point(16, 491);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(103, 33);
            this.addressLabel.TabIndex = 62;
            this.addressLabel.Text = "Address";
            // 
            // personalInformationLabel
            // 
            this.personalInformationLabel.AutoSize = true;
            this.personalInformationLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInformationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.personalInformationLabel.Location = new System.Drawing.Point(14, 369);
            this.personalInformationLabel.Name = "personalInformationLabel";
            this.personalInformationLabel.Size = new System.Drawing.Size(243, 33);
            this.personalInformationLabel.TabIndex = 61;
            this.personalInformationLabel.Text = "Personal Information";
            // 
            // zipBox
            // 
            this.zipBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.zipBox.BorderColor = System.Drawing.Color.Blue;
            this.zipBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zipBox.DefaultText = "Zip Code";
            this.zipBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.zipBox.ForeColor = System.Drawing.Color.DarkGray;
            this.zipBox.Location = new System.Drawing.Point(22, 572);
            this.zipBox.Name = "zipBox";
            this.zipBox.ReadOnly = true;
            this.zipBox.Size = new System.Drawing.Size(237, 23);
            this.zipBox.TabIndex = 9;
            this.zipBox.Text = "Zip Code";
            // 
            // cityBox
            // 
            this.cityBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.cityBox.BorderColor = System.Drawing.Color.Blue;
            this.cityBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cityBox.DefaultText = "City";
            this.cityBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.cityBox.ForeColor = System.Drawing.Color.DarkGray;
            this.cityBox.Location = new System.Drawing.Point(270, 572);
            this.cityBox.Name = "cityBox";
            this.cityBox.ReadOnly = true;
            this.cityBox.Size = new System.Drawing.Size(237, 23);
            this.cityBox.TabIndex = 10;
            this.cityBox.Text = "City";
            // 
            // addressBox
            // 
            this.addressBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.addressBox.BorderColor = System.Drawing.Color.Blue;
            this.addressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addressBox.DefaultText = "Address";
            this.addressBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.addressBox.ForeColor = System.Drawing.Color.DarkGray;
            this.addressBox.Location = new System.Drawing.Point(22, 532);
            this.addressBox.Name = "addressBox";
            this.addressBox.ReadOnly = true;
            this.addressBox.Size = new System.Drawing.Size(237, 23);
            this.addressBox.TabIndex = 8;
            this.addressBox.Text = "Address";
            // 
            // emailBox
            // 
            this.emailBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.emailBox.BorderColor = System.Drawing.Color.Blue;
            this.emailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailBox.DefaultText = "Email Address";
            this.emailBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.emailBox.ForeColor = System.Drawing.Color.DarkGray;
            this.emailBox.Location = new System.Drawing.Point(268, 455);
            this.emailBox.Name = "emailBox";
            this.emailBox.ReadOnly = true;
            this.emailBox.Size = new System.Drawing.Size(237, 23);
            this.emailBox.TabIndex = 7;
            this.emailBox.Text = "Email Address";
            // 
            // phoneBox
            // 
            this.phoneBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.phoneBox.BorderColor = System.Drawing.Color.Blue;
            this.phoneBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneBox.DefaultText = "Phone Number";
            this.phoneBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.phoneBox.ForeColor = System.Drawing.Color.DarkGray;
            this.phoneBox.Location = new System.Drawing.Point(20, 455);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.ReadOnly = true;
            this.phoneBox.Size = new System.Drawing.Size(237, 23);
            this.phoneBox.TabIndex = 6;
            this.phoneBox.Text = "Phone Number";
            // 
            // lastnameBox
            // 
            this.lastnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.lastnameBox.BorderColor = System.Drawing.Color.Blue;
            this.lastnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastnameBox.DefaultText = "Lastname";
            this.lastnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.lastnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.lastnameBox.Location = new System.Drawing.Point(268, 416);
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.ReadOnly = true;
            this.lastnameBox.Size = new System.Drawing.Size(237, 23);
            this.lastnameBox.TabIndex = 5;
            this.lastnameBox.Text = "Lastname";
            // 
            // firstnameBox
            // 
            this.firstnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.firstnameBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.firstnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstnameBox.DefaultText = "Firstname";
            this.firstnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.firstnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.firstnameBox.Location = new System.Drawing.Point(20, 416);
            this.firstnameBox.Name = "firstnameBox";
            this.firstnameBox.ReadOnly = true;
            this.firstnameBox.ShortcutsEnabled = false;
            this.firstnameBox.Size = new System.Drawing.Size(237, 23);
            this.firstnameBox.TabIndex = 4;
            this.firstnameBox.Text = "Firstname";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::DriveLogGUI.Properties.Resources.avataricon;
            this.pictureBox.InitialImage = global::DriveLogGUI.Properties.Resources.avataricon;
            this.pictureBox.Location = new System.Drawing.Point(341, 209);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(128, 128);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 64;
            this.pictureBox.TabStop = false;
            // 
            // editPictureButton
            // 
            this.editPictureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.editPictureButton.Enabled = false;
            this.editPictureButton.FlatAppearance.BorderSize = 0;
            this.editPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editPictureButton.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.editPictureButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.editPictureButton.Location = new System.Drawing.Point(358, 343);
            this.editPictureButton.Name = "editPictureButton";
            this.editPictureButton.Size = new System.Drawing.Size(98, 28);
            this.editPictureButton.TabIndex = 11;
            this.editPictureButton.Text = "Edit Picture";
            this.editPictureButton.UseVisualStyleBackColor = false;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.saveChangesButton.Enabled = false;
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.saveChangesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.saveChangesButton.Location = new System.Drawing.Point(202, 617);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(125, 36);
            this.saveChangesButton.TabIndex = 12;
            this.saveChangesButton.Text = "Save";
            this.saveChangesButton.UseVisualStyleBackColor = false;
            // 
            // EditUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(529, 673);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.editPictureButton);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.personalInformationLabel);
            this.Controls.Add(this.zipBox);
            this.Controls.Add(this.cityBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.phoneBox);
            this.Controls.Add(this.lastnameBox);
            this.Controls.Add(this.firstnameBox);
            this.Controls.Add(this.accountDetailsLabel);
            this.Controls.Add(this.vertifyPasswordStatusLabel);
            this.Controls.Add(this.passwordStatusLabel);
            this.Controls.Add(this.verifyEditPasswordBox);
            this.Controls.Add(this.editPasswordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.verifyPasswordBox);
            this.Controls.Add(this.verifyPasswordInfo);
            this.Controls.Add(this.editProfileHeaderLabel);
            this.Controls.Add(this.verifyPasswordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditUserInfoForm";
            this.Text = "EditUserInfoForm";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label verifyPasswordLabel;
        private System.Windows.Forms.Label editProfileHeaderLabel;
        private System.Windows.Forms.Label verifyPasswordInfo;
        private TextboxBorderColor verifyPasswordBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button button1;
        private TextboxBorderColor usernameBox;
        private TextboxBorderColor editPasswordBox;
        private TextboxBorderColor verifyEditPasswordBox;
        private System.Windows.Forms.Label passwordStatusLabel;
        private System.Windows.Forms.Label vertifyPasswordStatusLabel;
        private System.Windows.Forms.Label accountDetailsLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label personalInformationLabel;
        private TextboxBorderColor zipBox;
        private TextboxBorderColor cityBox;
        private TextboxBorderColor addressBox;
        private TextboxBorderColor emailBox;
        private TextboxBorderColor phoneBox;
        private TextboxBorderColor lastnameBox;
        private TextboxBorderColor firstnameBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button editPictureButton;
        private System.Windows.Forms.Button saveChangesButton;
    }
}