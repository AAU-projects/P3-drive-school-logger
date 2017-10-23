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
            this.registerUsernameLabel = new System.Windows.Forms.Label();
            this.registerPasswordLabel = new System.Windows.Forms.Label();
            this.registerFirstnameLabel = new System.Windows.Forms.Label();
            this.registerLastnameLabel = new System.Windows.Forms.Label();
            this.registerPhoneLabel = new System.Windows.Forms.Label();
            this.registerEmailLabel = new System.Windows.Forms.Label();
            this.registerCPRLabel = new System.Windows.Forms.Label();
            this.registerAdressLabel = new System.Windows.Forms.Label();
            this.registerCityLabel = new System.Windows.Forms.Label();
            this.registerZipcodeLabel = new System.Windows.Forms.Label();
            this.registerTitleLabel = new System.Windows.Forms.Label();
            this.registerSubtitleLabel = new System.Windows.Forms.Label();
            this.registerUploadPhotoButton = new System.Windows.Forms.Button();
            this.registerCreateNewUserButton = new System.Windows.Forms.Button();
            this.registerCancelHyperLink = new System.Windows.Forms.LinkLabel();
            this.registerConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.registerPicture = new System.Windows.Forms.PictureBox();
            this.vertifyPasswordStatusLabel = new System.Windows.Forms.Label();
            this.firstnameStatusLabel = new System.Windows.Forms.Label();
            this.lastnameStatusLabel = new System.Windows.Forms.Label();
            this.emailStatusLabel = new System.Windows.Forms.Label();
            this.phoneStatusLabel = new System.Windows.Forms.Label();
            this.cityStatusLabel = new System.Windows.Forms.Label();
            this.zipcodeStatusLabel = new System.Windows.Forms.Label();
            this.adressStatusLabel = new System.Windows.Forms.Label();
            this.CPRStatusLabel = new System.Windows.Forms.Label();
            this.usernameStatusLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // registerUsernameLabel
            // 
            this.registerUsernameLabel.AutoSize = true;
            this.registerUsernameLabel.Location = new System.Drawing.Point(19, 349);
            this.registerUsernameLabel.Name = "registerUsernameLabel";
            this.registerUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.registerUsernameLabel.TabIndex = 2;
            this.registerUsernameLabel.Text = "Username:";
            // 
            // registerPasswordLabel
            // 
            this.registerPasswordLabel.AutoSize = true;
            this.registerPasswordLabel.Location = new System.Drawing.Point(20, 385);
            this.registerPasswordLabel.Name = "registerPasswordLabel";
            this.registerPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.registerPasswordLabel.TabIndex = 1;
            this.registerPasswordLabel.Text = "Password:";
            // 
            // registerFirstnameLabel
            // 
            this.registerFirstnameLabel.AutoSize = true;
            this.registerFirstnameLabel.Location = new System.Drawing.Point(19, 84);
            this.registerFirstnameLabel.Name = "registerFirstnameLabel";
            this.registerFirstnameLabel.Size = new System.Drawing.Size(55, 13);
            this.registerFirstnameLabel.TabIndex = 0;
            this.registerFirstnameLabel.Text = "Firstname:";
            // 
            // registerLastnameLabel
            // 
            this.registerLastnameLabel.AutoSize = true;
            this.registerLastnameLabel.Location = new System.Drawing.Point(19, 117);
            this.registerLastnameLabel.Name = "registerLastnameLabel";
            this.registerLastnameLabel.Size = new System.Drawing.Size(56, 13);
            this.registerLastnameLabel.TabIndex = 4;
            this.registerLastnameLabel.Text = "Lastname:";
            // 
            // registerPhoneLabel
            // 
            this.registerPhoneLabel.AutoSize = true;
            this.registerPhoneLabel.Location = new System.Drawing.Point(20, 150);
            this.registerPhoneLabel.Name = "registerPhoneLabel";
            this.registerPhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.registerPhoneLabel.TabIndex = 5;
            this.registerPhoneLabel.Text = "Phone:";
            // 
            // registerEmailLabel
            // 
            this.registerEmailLabel.AutoSize = true;
            this.registerEmailLabel.Location = new System.Drawing.Point(20, 183);
            this.registerEmailLabel.Name = "registerEmailLabel";
            this.registerEmailLabel.Size = new System.Drawing.Size(35, 13);
            this.registerEmailLabel.TabIndex = 6;
            this.registerEmailLabel.Text = "Email:";
            // 
            // registerCPRLabel
            // 
            this.registerCPRLabel.AutoSize = true;
            this.registerCPRLabel.Location = new System.Drawing.Point(20, 216);
            this.registerCPRLabel.Name = "registerCPRLabel";
            this.registerCPRLabel.Size = new System.Drawing.Size(47, 13);
            this.registerCPRLabel.TabIndex = 7;
            this.registerCPRLabel.Text = "CPR. nr:";
            // 
            // registerAdressLabel
            // 
            this.registerAdressLabel.AutoSize = true;
            this.registerAdressLabel.Location = new System.Drawing.Point(20, 249);
            this.registerAdressLabel.Name = "registerAdressLabel";
            this.registerAdressLabel.Size = new System.Drawing.Size(42, 13);
            this.registerAdressLabel.TabIndex = 8;
            this.registerAdressLabel.Text = "Adress:";
            // 
            // registerCityLabel
            // 
            this.registerCityLabel.AutoSize = true;
            this.registerCityLabel.Location = new System.Drawing.Point(19, 318);
            this.registerCityLabel.Name = "registerCityLabel";
            this.registerCityLabel.Size = new System.Drawing.Size(27, 13);
            this.registerCityLabel.TabIndex = 9;
            this.registerCityLabel.Text = "City:";
            // 
            // registerZipcodeLabel
            // 
            this.registerZipcodeLabel.AutoSize = true;
            this.registerZipcodeLabel.Location = new System.Drawing.Point(20, 285);
            this.registerZipcodeLabel.Name = "registerZipcodeLabel";
            this.registerZipcodeLabel.Size = new System.Drawing.Size(52, 13);
            this.registerZipcodeLabel.TabIndex = 10;
            this.registerZipcodeLabel.Text = "Zip code:";
            // 
            // registerTitleLabel
            // 
            this.registerTitleLabel.AutoSize = true;
            this.registerTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerTitleLabel.Location = new System.Drawing.Point(159, 9);
            this.registerTitleLabel.Name = "registerTitleLabel";
            this.registerTitleLabel.Size = new System.Drawing.Size(165, 26);
            this.registerTitleLabel.TabIndex = 20;
            this.registerTitleLabel.Text = "City Køreskolen";
            this.registerTitleLabel.Click += new System.EventHandler(this.registerTitleLabel_Click);
            // 
            // registerSubtitleLabel
            // 
            this.registerSubtitleLabel.AutoSize = true;
            this.registerSubtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerSubtitleLabel.Location = new System.Drawing.Point(171, 35);
            this.registerSubtitleLabel.Name = "registerSubtitleLabel";
            this.registerSubtitleLabel.Size = new System.Drawing.Size(138, 20);
            this.registerSubtitleLabel.TabIndex = 21;
            this.registerSubtitleLabel.Text = "Create a new user";
            // 
            // registerUploadPhotoButton
            // 
            this.registerUploadPhotoButton.Location = new System.Drawing.Point(349, 249);
            this.registerUploadPhotoButton.Name = "registerUploadPhotoButton";
            this.registerUploadPhotoButton.Size = new System.Drawing.Size(91, 23);
            this.registerUploadPhotoButton.TabIndex = 11;
            this.registerUploadPhotoButton.Text = "Upload picture";
            this.registerUploadPhotoButton.UseVisualStyleBackColor = true;
            this.registerUploadPhotoButton.Click += new System.EventHandler(this.registerUploadPhotoButton_Click);
            // 
            // registerCreateNewUserButton
            // 
            this.registerCreateNewUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerCreateNewUserButton.Location = new System.Drawing.Point(164, 453);
            this.registerCreateNewUserButton.Name = "registerCreateNewUserButton";
            this.registerCreateNewUserButton.Size = new System.Drawing.Size(144, 44);
            this.registerCreateNewUserButton.TabIndex = 12;
            this.registerCreateNewUserButton.Text = "Create";
            this.registerCreateNewUserButton.UseVisualStyleBackColor = true;
            this.registerCreateNewUserButton.Click += new System.EventHandler(this.registerCreateNewUserButton_Click);
            // 
            // registerCancelHyperLink
            // 
            this.registerCancelHyperLink.AutoSize = true;
            this.registerCancelHyperLink.Location = new System.Drawing.Point(216, 500);
            this.registerCancelHyperLink.Name = "registerCancelHyperLink";
            this.registerCancelHyperLink.Size = new System.Drawing.Size(40, 13);
            this.registerCancelHyperLink.TabIndex = 13;
            this.registerCancelHyperLink.TabStop = true;
            this.registerCancelHyperLink.Text = "Cancel";
            this.registerCancelHyperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerCancelHyperLink_LinkClicked);
            // 
            // registerConfirmPasswordLabel
            // 
            this.registerConfirmPasswordLabel.AutoSize = true;
            this.registerConfirmPasswordLabel.Location = new System.Drawing.Point(20, 418);
            this.registerConfirmPasswordLabel.Name = "registerConfirmPasswordLabel";
            this.registerConfirmPasswordLabel.Size = new System.Drawing.Size(84, 13);
            this.registerConfirmPasswordLabel.TabIndex = 26;
            this.registerConfirmPasswordLabel.Text = "Verify password:";
            // 
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.Location = new System.Drawing.Point(264, 385);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(83, 13);
            this.passwordStatusLabel.TabIndex = 28;
            this.passwordStatusLabel.Text = "StatusPassword";
            // 
            // registerPicture
            // 
            this.registerPicture.Location = new System.Drawing.Point(316, 81);
            this.registerPicture.Name = "registerPicture";
            this.registerPicture.Size = new System.Drawing.Size(155, 155);
            this.registerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.registerPicture.TabIndex = 29;
            this.registerPicture.TabStop = false;
            this.registerPicture.Click += new System.EventHandler(this.registerPicture_Click);
            // 
            // vertifyPasswordStatusLabel
            // 
            this.vertifyPasswordStatusLabel.AutoSize = true;
            this.vertifyPasswordStatusLabel.Location = new System.Drawing.Point(263, 418);
            this.vertifyPasswordStatusLabel.Name = "vertifyPasswordStatusLabel";
            this.vertifyPasswordStatusLabel.Size = new System.Drawing.Size(63, 13);
            this.vertifyPasswordStatusLabel.TabIndex = 30;
            this.vertifyPasswordStatusLabel.Text = "StatusVerify";
            // 
            // firstnameStatusLabel
            // 
            this.firstnameStatusLabel.AutoSize = true;
            this.firstnameStatusLabel.Location = new System.Drawing.Point(264, 84);
            this.firstnameStatusLabel.Name = "firstnameStatusLabel";
            this.firstnameStatusLabel.Size = new System.Drawing.Size(56, 13);
            this.firstnameStatusLabel.TabIndex = 31;
            this.firstnameStatusLabel.Text = "StatusFirst";
            // 
            // lastnameStatusLabel
            // 
            this.lastnameStatusLabel.AutoSize = true;
            this.lastnameStatusLabel.Location = new System.Drawing.Point(264, 117);
            this.lastnameStatusLabel.Name = "lastnameStatusLabel";
            this.lastnameStatusLabel.Size = new System.Drawing.Size(57, 13);
            this.lastnameStatusLabel.TabIndex = 32;
            this.lastnameStatusLabel.Text = "StatusLast";
            // 
            // emailStatusLabel
            // 
            this.emailStatusLabel.AutoSize = true;
            this.emailStatusLabel.Location = new System.Drawing.Point(264, 183);
            this.emailStatusLabel.Name = "emailStatusLabel";
            this.emailStatusLabel.Size = new System.Drawing.Size(62, 13);
            this.emailStatusLabel.TabIndex = 34;
            this.emailStatusLabel.Text = "StatusEmail";
            // 
            // phoneStatusLabel
            // 
            this.phoneStatusLabel.AutoSize = true;
            this.phoneStatusLabel.Location = new System.Drawing.Point(264, 150);
            this.phoneStatusLabel.Name = "phoneStatusLabel";
            this.phoneStatusLabel.Size = new System.Drawing.Size(68, 13);
            this.phoneStatusLabel.TabIndex = 33;
            this.phoneStatusLabel.Text = "StatusPhone";
            // 
            // cityStatusLabel
            // 
            this.cityStatusLabel.AutoSize = true;
            this.cityStatusLabel.Location = new System.Drawing.Point(264, 315);
            this.cityStatusLabel.Name = "cityStatusLabel";
            this.cityStatusLabel.Size = new System.Drawing.Size(54, 13);
            this.cityStatusLabel.TabIndex = 38;
            this.cityStatusLabel.Text = "StatusCity";
            // 
            // zipcodeStatusLabel
            // 
            this.zipcodeStatusLabel.AutoSize = true;
            this.zipcodeStatusLabel.Location = new System.Drawing.Point(264, 282);
            this.zipcodeStatusLabel.Name = "zipcodeStatusLabel";
            this.zipcodeStatusLabel.Size = new System.Drawing.Size(52, 13);
            this.zipcodeStatusLabel.TabIndex = 37;
            this.zipcodeStatusLabel.Text = "StatusZip";
            // 
            // adressStatusLabel
            // 
            this.adressStatusLabel.AutoSize = true;
            this.adressStatusLabel.Location = new System.Drawing.Point(264, 249);
            this.adressStatusLabel.Name = "adressStatusLabel";
            this.adressStatusLabel.Size = new System.Drawing.Size(69, 13);
            this.adressStatusLabel.TabIndex = 36;
            this.adressStatusLabel.Text = "StatusAdress";
            // 
            // CPRStatusLabel
            // 
            this.CPRStatusLabel.AutoSize = true;
            this.CPRStatusLabel.Location = new System.Drawing.Point(264, 216);
            this.CPRStatusLabel.Name = "CPRStatusLabel";
            this.CPRStatusLabel.Size = new System.Drawing.Size(59, 13);
            this.CPRStatusLabel.TabIndex = 35;
            this.CPRStatusLabel.Text = "StatusCPR";
            // 
            // usernameStatusLabel
            // 
            this.usernameStatusLabel.AutoSize = true;
            this.usernameStatusLabel.Location = new System.Drawing.Point(264, 349);
            this.usernameStatusLabel.Name = "usernameStatusLabel";
            this.usernameStatusLabel.Size = new System.Drawing.Size(85, 13);
            this.usernameStatusLabel.TabIndex = 39;
            this.usernameStatusLabel.Text = "StatusUsername";
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyPasswordBox.Location = new System.Drawing.Point(112, 415);
            this.verifyPasswordBox.Name = "verifyPasswordBox";
            this.verifyPasswordBox.PasswordChar = '*';
            this.verifyPasswordBox.Size = new System.Drawing.Size(145, 20);
            this.verifyPasswordBox.TabIndex = 10;
            this.verifyPasswordBox.TextChanged += new System.EventHandler(this.verifyPasswordBox_TextChanged);
            // 
            // registerZipBox
            // 
            this.registerZipBox.BorderColor = System.Drawing.Color.Blue;
            this.registerZipBox.Location = new System.Drawing.Point(112, 282);
            this.registerZipBox.Name = "registerZipBox";
            this.registerZipBox.Size = new System.Drawing.Size(145, 20);
            this.registerZipBox.TabIndex = 6;
            this.registerZipBox.Leave += new System.EventHandler(this.registerZipBox_Leave);
            // 
            // registerCityBox
            // 
            this.registerCityBox.BorderColor = System.Drawing.Color.Blue;
            this.registerCityBox.Location = new System.Drawing.Point(112, 315);
            this.registerCityBox.Name = "registerCityBox";
            this.registerCityBox.Size = new System.Drawing.Size(145, 20);
            this.registerCityBox.TabIndex = 7;
            this.registerCityBox.TextChanged += new System.EventHandler(this.registerCityBox_TextChanged);
            this.registerCityBox.Leave += new System.EventHandler(this.registerCityBox_Leave);
            // 
            // registerAdressBox
            // 
            this.registerAdressBox.BorderColor = System.Drawing.Color.Blue;
            this.registerAdressBox.Location = new System.Drawing.Point(111, 246);
            this.registerAdressBox.Name = "registerAdressBox";
            this.registerAdressBox.Size = new System.Drawing.Size(145, 20);
            this.registerAdressBox.TabIndex = 5;
            this.registerAdressBox.Leave += new System.EventHandler(this.registerAdressBox_Leave);
            // 
            // registerCprBox
            // 
            this.registerCprBox.BorderColor = System.Drawing.Color.Blue;
            this.registerCprBox.Location = new System.Drawing.Point(111, 213);
            this.registerCprBox.Name = "registerCprBox";
            this.registerCprBox.Size = new System.Drawing.Size(145, 20);
            this.registerCprBox.TabIndex = 4;
            this.registerCprBox.Leave += new System.EventHandler(this.registerCprBox_Leave);
            // 
            // registerEmailBox
            // 
            this.registerEmailBox.BorderColor = System.Drawing.Color.Blue;
            this.registerEmailBox.Location = new System.Drawing.Point(111, 180);
            this.registerEmailBox.Name = "registerEmailBox";
            this.registerEmailBox.Size = new System.Drawing.Size(145, 20);
            this.registerEmailBox.TabIndex = 3;
            this.registerEmailBox.Leave += new System.EventHandler(this.registerEmailBox_Leave);
            // 
            // registerPhoneBox
            // 
            this.registerPhoneBox.BorderColor = System.Drawing.Color.Blue;
            this.registerPhoneBox.Location = new System.Drawing.Point(111, 147);
            this.registerPhoneBox.Name = "registerPhoneBox";
            this.registerPhoneBox.Size = new System.Drawing.Size(145, 20);
            this.registerPhoneBox.TabIndex = 2;
            this.registerPhoneBox.Leave += new System.EventHandler(this.registerPhoneBox_Leave);
            // 
            // registerLastnameBox
            // 
            this.registerLastnameBox.BorderColor = System.Drawing.Color.Blue;
            this.registerLastnameBox.Location = new System.Drawing.Point(111, 114);
            this.registerLastnameBox.Name = "registerLastnameBox";
            this.registerLastnameBox.Size = new System.Drawing.Size(145, 20);
            this.registerLastnameBox.TabIndex = 1;
            this.registerLastnameBox.Leave += new System.EventHandler(this.registerLastnameBox_Leave);
            // 
            // registerFirstnameBox
            // 
            this.registerFirstnameBox.BorderColor = System.Drawing.Color.Blue;
            this.registerFirstnameBox.Location = new System.Drawing.Point(111, 81);
            this.registerFirstnameBox.Name = "registerFirstnameBox";
            this.registerFirstnameBox.Size = new System.Drawing.Size(145, 20);
            this.registerFirstnameBox.TabIndex = 0;
            this.registerFirstnameBox.TextChanged += new System.EventHandler(this.registerFirstnameBox_TextChanged);
            this.registerFirstnameBox.Leave += new System.EventHandler(this.registerFirstnameBox_Leave);
            // 
            // registerPasswordBox
            // 
            this.registerPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.registerPasswordBox.Location = new System.Drawing.Point(112, 382);
            this.registerPasswordBox.Name = "registerPasswordBox";
            this.registerPasswordBox.PasswordChar = '*';
            this.registerPasswordBox.Size = new System.Drawing.Size(145, 20);
            this.registerPasswordBox.TabIndex = 9;
            this.registerPasswordBox.TextChanged += new System.EventHandler(this.registerPasswordBox_TextChanged);
            // 
            // registerUsernameBox
            // 
            this.registerUsernameBox.BorderColor = System.Drawing.Color.Blue;
            this.registerUsernameBox.Location = new System.Drawing.Point(112, 346);
            this.registerUsernameBox.Name = "registerUsernameBox";
            this.registerUsernameBox.Size = new System.Drawing.Size(145, 20);
            this.registerUsernameBox.TabIndex = 8;
            this.registerUsernameBox.TextChanged += new System.EventHandler(this.registerUsernameBox_TextChanged);
            this.registerUsernameBox.Leave += new System.EventHandler(this.registerUsernameBox_Leave);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 528);
            this.Controls.Add(this.usernameStatusLabel);
            this.Controls.Add(this.cityStatusLabel);
            this.Controls.Add(this.zipcodeStatusLabel);
            this.Controls.Add(this.adressStatusLabel);
            this.Controls.Add(this.CPRStatusLabel);
            this.Controls.Add(this.emailStatusLabel);
            this.Controls.Add(this.phoneStatusLabel);
            this.Controls.Add(this.lastnameStatusLabel);
            this.Controls.Add(this.firstnameStatusLabel);
            this.Controls.Add(this.vertifyPasswordStatusLabel);
            this.Controls.Add(this.registerPicture);
            this.Controls.Add(this.passwordStatusLabel);
            this.Controls.Add(this.verifyPasswordBox);
            this.Controls.Add(this.registerConfirmPasswordLabel);
            this.Controls.Add(this.registerCancelHyperLink);
            this.Controls.Add(this.registerCreateNewUserButton);
            this.Controls.Add(this.registerUploadPhotoButton);
            this.Controls.Add(this.registerSubtitleLabel);
            this.Controls.Add(this.registerTitleLabel);
            this.Controls.Add(this.registerZipBox);
            this.Controls.Add(this.registerCityBox);
            this.Controls.Add(this.registerAdressBox);
            this.Controls.Add(this.registerCprBox);
            this.Controls.Add(this.registerEmailBox);
            this.Controls.Add(this.registerPhoneBox);
            this.Controls.Add(this.registerLastnameBox);
            this.Controls.Add(this.registerFirstnameBox);
            this.Controls.Add(this.registerPasswordBox);
            this.Controls.Add(this.registerZipcodeLabel);
            this.Controls.Add(this.registerCityLabel);
            this.Controls.Add(this.registerAdressLabel);
            this.Controls.Add(this.registerCPRLabel);
            this.Controls.Add(this.registerEmailLabel);
            this.Controls.Add(this.registerPhoneLabel);
            this.Controls.Add(this.registerLastnameLabel);
            this.Controls.Add(this.registerUsernameBox);
            this.Controls.Add(this.registerFirstnameLabel);
            this.Controls.Add(this.registerPasswordLabel);
            this.Controls.Add(this.registerUsernameLabel);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label registerUsernameLabel;
        private System.Windows.Forms.Label registerPasswordLabel;
        private System.Windows.Forms.Label registerFirstnameLabel;
        private TextboxBorderColor registerFirstnameBox;
        private TextboxBorderColor registerUsernameBox;
        private System.Windows.Forms.Label registerLastnameLabel;
        private System.Windows.Forms.Label registerPhoneLabel;
        private System.Windows.Forms.Label registerEmailLabel;
        private System.Windows.Forms.Label registerCPRLabel;
        private System.Windows.Forms.Label registerAdressLabel;
        private System.Windows.Forms.Label registerCityLabel;
        private System.Windows.Forms.Label registerZipcodeLabel;
        private TextboxBorderColor registerPasswordBox;
        private TextboxBorderColor registerLastnameBox;
        private TextboxBorderColor registerPhoneBox;
        private TextboxBorderColor registerEmailBox;
        private TextboxBorderColor registerCprBox;
        private TextboxBorderColor registerAdressBox;
        private TextboxBorderColor registerCityBox;
        private TextboxBorderColor registerZipBox;
        private System.Windows.Forms.Label registerTitleLabel;
        private System.Windows.Forms.Label registerSubtitleLabel;
        private System.Windows.Forms.Button registerUploadPhotoButton;
        private System.Windows.Forms.Button registerCreateNewUserButton;
        private System.Windows.Forms.LinkLabel registerCancelHyperLink;
        private TextboxBorderColor verifyPasswordBox;
        private System.Windows.Forms.Label registerConfirmPasswordLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label passwordStatusLabel;
        private System.Windows.Forms.PictureBox registerPicture;
        private System.Windows.Forms.Label vertifyPasswordStatusLabel;
        private System.Windows.Forms.Label firstnameStatusLabel;
        private System.Windows.Forms.Label lastnameStatusLabel;
        private System.Windows.Forms.Label emailStatusLabel;
        private System.Windows.Forms.Label phoneStatusLabel;
        private System.Windows.Forms.Label cityStatusLabel;
        private System.Windows.Forms.Label zipcodeStatusLabel;
        private System.Windows.Forms.Label adressStatusLabel;
        private System.Windows.Forms.Label CPRStatusLabel;
        private System.Windows.Forms.Label usernameStatusLabel;
    }
}