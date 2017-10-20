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
            System.Windows.Forms.PictureBox registerPicturebox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registerUsernameLabel = new System.Windows.Forms.Label();
            this.registerPasswordLabel = new System.Windows.Forms.Label();
            this.registerFirstnameLabel = new System.Windows.Forms.Label();
            this.registerUsernameBox = new System.Windows.Forms.TextBox();
            this.registerLastnameLabel = new System.Windows.Forms.Label();
            this.registerPhoneLabel = new System.Windows.Forms.Label();
            this.registerEmailLabel = new System.Windows.Forms.Label();
            this.registerCPRLabel = new System.Windows.Forms.Label();
            this.registerAdressLabel = new System.Windows.Forms.Label();
            this.registerCityLabel = new System.Windows.Forms.Label();
            this.registerZipcodeLabel = new System.Windows.Forms.Label();
            this.registerPasswordBox = new System.Windows.Forms.TextBox();
            this.registerFirstnameBox = new System.Windows.Forms.TextBox();
            this.registerLastnameBox = new System.Windows.Forms.TextBox();
            this.registerPhoneBox = new System.Windows.Forms.TextBox();
            this.registerEmailBox = new System.Windows.Forms.TextBox();
            this.registerCprBox = new System.Windows.Forms.TextBox();
            this.registerAdressBox = new System.Windows.Forms.TextBox();
            this.registerCityBox = new System.Windows.Forms.TextBox();
            this.registerZipBox = new System.Windows.Forms.TextBox();
            this.registerTitleLabel = new System.Windows.Forms.Label();
            this.registerSubtitleLabel = new System.Windows.Forms.Label();
            this.registerUploadPhotoButton = new System.Windows.Forms.Button();
            this.registerCreateNewUserButton = new System.Windows.Forms.Button();
            this.registerCancelHyperLink = new System.Windows.Forms.LinkLabel();
            this.verifyPasswordBox = new System.Windows.Forms.TextBox();
            this.registerConfirmPasswordLabel = new System.Windows.Forms.Label();
            registerPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(registerPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // registerPicturebox
            // 
            registerPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("registerPicturebox.Image")));
            registerPicturebox.Location = new System.Drawing.Point(328, 81);
            registerPicturebox.Name = "registerPicturebox";
            registerPicturebox.Size = new System.Drawing.Size(128, 128);
            registerPicturebox.TabIndex = 22;
            registerPicturebox.TabStop = false;
            // 
            // registerUsernameLabel
            // 
            this.registerUsernameLabel.AutoSize = true;
            this.registerUsernameLabel.Location = new System.Drawing.Point(19, 84);
            this.registerUsernameLabel.Name = "registerUsernameLabel";
            this.registerUsernameLabel.Size = new System.Drawing.Size(58, 13);
            this.registerUsernameLabel.TabIndex = 0;
            this.registerUsernameLabel.Text = "Username:";
            // 
            // registerPasswordLabel
            // 
            this.registerPasswordLabel.AutoSize = true;
            this.registerPasswordLabel.Location = new System.Drawing.Point(19, 117);
            this.registerPasswordLabel.Name = "registerPasswordLabel";
            this.registerPasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.registerPasswordLabel.TabIndex = 1;
            this.registerPasswordLabel.Text = "Password:";
            // 
            // registerFirstnameLabel
            // 
            this.registerFirstnameLabel.AutoSize = true;
            this.registerFirstnameLabel.Location = new System.Drawing.Point(19, 184);
            this.registerFirstnameLabel.Name = "registerFirstnameLabel";
            this.registerFirstnameLabel.Size = new System.Drawing.Size(55, 13);
            this.registerFirstnameLabel.TabIndex = 2;
            this.registerFirstnameLabel.Text = "Firstname:";
            // 
            // registerUsernameBox
            // 
            this.registerUsernameBox.Location = new System.Drawing.Point(111, 81);
            this.registerUsernameBox.Name = "registerUsernameBox";
            this.registerUsernameBox.Size = new System.Drawing.Size(145, 20);
            this.registerUsernameBox.TabIndex = 3;
            this.registerUsernameBox.TextChanged += new System.EventHandler(this.registerUsernameBox_TextChanged);
            this.registerUsernameBox.Leave += new System.EventHandler(this.registerUsernameBox_Leave);
            // 
            // registerLastnameLabel
            // 
            this.registerLastnameLabel.AutoSize = true;
            this.registerLastnameLabel.Location = new System.Drawing.Point(19, 217);
            this.registerLastnameLabel.Name = "registerLastnameLabel";
            this.registerLastnameLabel.Size = new System.Drawing.Size(56, 13);
            this.registerLastnameLabel.TabIndex = 4;
            this.registerLastnameLabel.Text = "Lastname:";
            // 
            // registerPhoneLabel
            // 
            this.registerPhoneLabel.AutoSize = true;
            this.registerPhoneLabel.Location = new System.Drawing.Point(20, 250);
            this.registerPhoneLabel.Name = "registerPhoneLabel";
            this.registerPhoneLabel.Size = new System.Drawing.Size(41, 13);
            this.registerPhoneLabel.TabIndex = 5;
            this.registerPhoneLabel.Text = "Phone:";
            // 
            // registerEmailLabel
            // 
            this.registerEmailLabel.AutoSize = true;
            this.registerEmailLabel.Location = new System.Drawing.Point(20, 283);
            this.registerEmailLabel.Name = "registerEmailLabel";
            this.registerEmailLabel.Size = new System.Drawing.Size(35, 13);
            this.registerEmailLabel.TabIndex = 6;
            this.registerEmailLabel.Text = "Email:";
            // 
            // registerCPRLabel
            // 
            this.registerCPRLabel.AutoSize = true;
            this.registerCPRLabel.Location = new System.Drawing.Point(20, 316);
            this.registerCPRLabel.Name = "registerCPRLabel";
            this.registerCPRLabel.Size = new System.Drawing.Size(47, 13);
            this.registerCPRLabel.TabIndex = 7;
            this.registerCPRLabel.Text = "CPR. nr:";
            // 
            // registerAdressLabel
            // 
            this.registerAdressLabel.AutoSize = true;
            this.registerAdressLabel.Location = new System.Drawing.Point(20, 349);
            this.registerAdressLabel.Name = "registerAdressLabel";
            this.registerAdressLabel.Size = new System.Drawing.Size(42, 13);
            this.registerAdressLabel.TabIndex = 8;
            this.registerAdressLabel.Text = "Adress:";
            // 
            // registerCityLabel
            // 
            this.registerCityLabel.AutoSize = true;
            this.registerCityLabel.Location = new System.Drawing.Point(20, 382);
            this.registerCityLabel.Name = "registerCityLabel";
            this.registerCityLabel.Size = new System.Drawing.Size(27, 13);
            this.registerCityLabel.TabIndex = 9;
            this.registerCityLabel.Text = "City:";
            // 
            // registerZipcodeLabel
            // 
            this.registerZipcodeLabel.AutoSize = true;
            this.registerZipcodeLabel.Location = new System.Drawing.Point(19, 415);
            this.registerZipcodeLabel.Name = "registerZipcodeLabel";
            this.registerZipcodeLabel.Size = new System.Drawing.Size(52, 13);
            this.registerZipcodeLabel.TabIndex = 10;
            this.registerZipcodeLabel.Text = "Zip code:";
            // 
            // registerPasswordBox
            // 
            this.registerPasswordBox.Location = new System.Drawing.Point(111, 114);
            this.registerPasswordBox.Name = "registerPasswordBox";
            this.registerPasswordBox.PasswordChar = '*';
            this.registerPasswordBox.Size = new System.Drawing.Size(145, 20);
            this.registerPasswordBox.TabIndex = 11;
            // 
            // registerFirstnameBox
            // 
            this.registerFirstnameBox.Location = new System.Drawing.Point(111, 181);
            this.registerFirstnameBox.Name = "registerFirstnameBox";
            this.registerFirstnameBox.Size = new System.Drawing.Size(145, 20);
            this.registerFirstnameBox.TabIndex = 12;
            // 
            // registerLastnameBox
            // 
            this.registerLastnameBox.Location = new System.Drawing.Point(111, 214);
            this.registerLastnameBox.Name = "registerLastnameBox";
            this.registerLastnameBox.Size = new System.Drawing.Size(145, 20);
            this.registerLastnameBox.TabIndex = 13;
            // 
            // registerPhoneBox
            // 
            this.registerPhoneBox.Location = new System.Drawing.Point(111, 247);
            this.registerPhoneBox.Name = "registerPhoneBox";
            this.registerPhoneBox.Size = new System.Drawing.Size(145, 20);
            this.registerPhoneBox.TabIndex = 14;
            // 
            // registerEmailBox
            // 
            this.registerEmailBox.Location = new System.Drawing.Point(111, 280);
            this.registerEmailBox.Name = "registerEmailBox";
            this.registerEmailBox.Size = new System.Drawing.Size(145, 20);
            this.registerEmailBox.TabIndex = 15;
            this.registerEmailBox.Leave += new System.EventHandler(this.registerEmailBox_Leave);
            // 
            // registerCprBox
            // 
            this.registerCprBox.Location = new System.Drawing.Point(111, 313);
            this.registerCprBox.Name = "registerCprBox";
            this.registerCprBox.Size = new System.Drawing.Size(145, 20);
            this.registerCprBox.TabIndex = 16;
            // 
            // registerAdressBox
            // 
            this.registerAdressBox.Location = new System.Drawing.Point(111, 346);
            this.registerAdressBox.Name = "registerAdressBox";
            this.registerAdressBox.Size = new System.Drawing.Size(145, 20);
            this.registerAdressBox.TabIndex = 17;
            // 
            // registerCityBox
            // 
            this.registerCityBox.Location = new System.Drawing.Point(111, 379);
            this.registerCityBox.Name = "registerCityBox";
            this.registerCityBox.Size = new System.Drawing.Size(145, 20);
            this.registerCityBox.TabIndex = 18;
            // 
            // registerZipBox
            // 
            this.registerZipBox.Location = new System.Drawing.Point(111, 412);
            this.registerZipBox.Name = "registerZipBox";
            this.registerZipBox.Size = new System.Drawing.Size(145, 20);
            this.registerZipBox.TabIndex = 19;
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
            this.registerUploadPhotoButton.Location = new System.Drawing.Point(346, 215);
            this.registerUploadPhotoButton.Name = "registerUploadPhotoButton";
            this.registerUploadPhotoButton.Size = new System.Drawing.Size(91, 23);
            this.registerUploadPhotoButton.TabIndex = 23;
            this.registerUploadPhotoButton.Text = "Upload picture";
            this.registerUploadPhotoButton.UseVisualStyleBackColor = true;
            // 
            // registerCreateNewUserButton
            // 
            this.registerCreateNewUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerCreateNewUserButton.Location = new System.Drawing.Point(164, 453);
            this.registerCreateNewUserButton.Name = "registerCreateNewUserButton";
            this.registerCreateNewUserButton.Size = new System.Drawing.Size(144, 44);
            this.registerCreateNewUserButton.TabIndex = 24;
            this.registerCreateNewUserButton.Text = "Create";
            this.registerCreateNewUserButton.UseVisualStyleBackColor = true;
            // 
            // registerCancelHyperLink
            // 
            this.registerCancelHyperLink.AutoSize = true;
            this.registerCancelHyperLink.Location = new System.Drawing.Point(216, 500);
            this.registerCancelHyperLink.Name = "registerCancelHyperLink";
            this.registerCancelHyperLink.Size = new System.Drawing.Size(40, 13);
            this.registerCancelHyperLink.TabIndex = 25;
            this.registerCancelHyperLink.TabStop = true;
            this.registerCancelHyperLink.Text = "Cancel";
            this.registerCancelHyperLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerCancelHyperLink_LinkClicked);
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.Location = new System.Drawing.Point(111, 147);
            this.verifyPasswordBox.Name = "verifyPasswordBox";
            this.verifyPasswordBox.PasswordChar = '*';
            this.verifyPasswordBox.Size = new System.Drawing.Size(145, 20);
            this.verifyPasswordBox.TabIndex = 27;
            // 
            // registerConfirmPasswordLabel
            // 
            this.registerConfirmPasswordLabel.AutoSize = true;
            this.registerConfirmPasswordLabel.Location = new System.Drawing.Point(19, 150);
            this.registerConfirmPasswordLabel.Name = "registerConfirmPasswordLabel";
            this.registerConfirmPasswordLabel.Size = new System.Drawing.Size(84, 13);
            this.registerConfirmPasswordLabel.TabIndex = 26;
            this.registerConfirmPasswordLabel.Text = "Verify password:";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 528);
            this.Controls.Add(this.verifyPasswordBox);
            this.Controls.Add(this.registerConfirmPasswordLabel);
            this.Controls.Add(this.registerCancelHyperLink);
            this.Controls.Add(this.registerCreateNewUserButton);
            this.Controls.Add(this.registerUploadPhotoButton);
            this.Controls.Add(registerPicturebox);
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
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(registerPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label registerUsernameLabel;
        private System.Windows.Forms.Label registerPasswordLabel;
        private System.Windows.Forms.Label registerFirstnameLabel;
        private System.Windows.Forms.TextBox registerUsernameBox;
        private System.Windows.Forms.Label registerLastnameLabel;
        private System.Windows.Forms.Label registerPhoneLabel;
        private System.Windows.Forms.Label registerEmailLabel;
        private System.Windows.Forms.Label registerCPRLabel;
        private System.Windows.Forms.Label registerAdressLabel;
        private System.Windows.Forms.Label registerCityLabel;
        private System.Windows.Forms.Label registerZipcodeLabel;
        private System.Windows.Forms.TextBox registerPasswordBox;
        private System.Windows.Forms.TextBox registerFirstnameBox;
        private System.Windows.Forms.TextBox registerLastnameBox;
        private System.Windows.Forms.TextBox registerPhoneBox;
        private System.Windows.Forms.TextBox registerEmailBox;
        private System.Windows.Forms.TextBox registerCprBox;
        private System.Windows.Forms.TextBox registerAdressBox;
        private System.Windows.Forms.TextBox registerCityBox;
        private System.Windows.Forms.TextBox registerZipBox;
        private System.Windows.Forms.Label registerTitleLabel;
        private System.Windows.Forms.Label registerSubtitleLabel;
        private System.Windows.Forms.Button registerUploadPhotoButton;
        private System.Windows.Forms.Button registerCreateNewUserButton;
        private System.Windows.Forms.LinkLabel registerCancelHyperLink;
        private System.Windows.Forms.TextBox verifyPasswordBox;
        private System.Windows.Forms.Label registerConfirmPasswordLabel;
    }
}