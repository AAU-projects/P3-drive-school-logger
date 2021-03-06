﻿using DriveLogGUI.CustomControls;

namespace DriveLogGUI.Windows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registerSubtitleLabel = new System.Windows.Forms.Label();
            this.registerUploadPhotoButton = new System.Windows.Forms.Button();
            this.registerCreateNewUserButton = new System.Windows.Forms.Button();
            this.registerCancelHyperLink = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.labelForPersonalInformation = new System.Windows.Forms.Label();
            this.labelForAddress = new System.Windows.Forms.Label();
            this.labelForAccountDetails = new System.Windows.Forms.Label();
            this.vertifyPasswordStatusLabel = new System.Windows.Forms.Label();
            this.topBarPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.registerPicture = new System.Windows.Forms.PictureBox();
            this.signatureBox = new System.Windows.Forms.PictureBox();
            this.signatureButton = new System.Windows.Forms.Button();
            this.verifyPasswordBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerZipBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerCityBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerAdressBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerCprBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerEmailBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerPhoneBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerLastnameBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerFirstnameBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerPasswordBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.registerUsernameBox = new DriveLogGUI.CustomControls.TextboxBorderColor();
            this.topBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // registerSubtitleLabel
            // 
            this.registerSubtitleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.registerSubtitleLabel.Location = new System.Drawing.Point(0, 34);
            this.registerSubtitleLabel.Name = "registerSubtitleLabel";
            this.registerSubtitleLabel.Size = new System.Drawing.Size(529, 33);
            this.registerSubtitleLabel.TabIndex = 21;
            this.registerSubtitleLabel.Text = "Create new user";
            this.registerSubtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registerUploadPhotoButton
            // 
            this.registerUploadPhotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.registerUploadPhotoButton.FlatAppearance.BorderSize = 0;
            this.registerUploadPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerUploadPhotoButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.registerUploadPhotoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.registerUploadPhotoButton.Location = new System.Drawing.Point(162, 116);
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
            this.registerCreateNewUserButton.Location = new System.Drawing.Point(23, 660);
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
            this.registerCancelHyperLink.Location = new System.Drawing.Point(239, 709);
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
            this.passwordStatusLabel.Location = new System.Drawing.Point(20, 640);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(93, 15);
            this.passwordStatusLabel.TabIndex = 28;
            this.passwordStatusLabel.Text = "StatusPassword";
            // 
            // labelForPersonalInformation
            // 
            this.labelForPersonalInformation.AutoSize = true;
            this.labelForPersonalInformation.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForPersonalInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.labelForPersonalInformation.Location = new System.Drawing.Point(17, 214);
            this.labelForPersonalInformation.Name = "labelForPersonalInformation";
            this.labelForPersonalInformation.Size = new System.Drawing.Size(243, 33);
            this.labelForPersonalInformation.TabIndex = 40;
            this.labelForPersonalInformation.Text = "Personal Information";
            // 
            // labelForAddress
            // 
            this.labelForAddress.AutoSize = true;
            this.labelForAddress.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.labelForAddress.Location = new System.Drawing.Point(17, 388);
            this.labelForAddress.Name = "labelForAddress";
            this.labelForAddress.Size = new System.Drawing.Size(103, 33);
            this.labelForAddress.TabIndex = 41;
            this.labelForAddress.Text = "Address";
            // 
            // labelForAccountDetails
            // 
            this.labelForAccountDetails.AutoSize = true;
            this.labelForAccountDetails.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForAccountDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.labelForAccountDetails.Location = new System.Drawing.Point(17, 517);
            this.labelForAccountDetails.Name = "labelForAccountDetails";
            this.labelForAccountDetails.Size = new System.Drawing.Size(185, 33);
            this.labelForAccountDetails.TabIndex = 42;
            this.labelForAccountDetails.Text = "Account Details";
            // 
            // vertifyPasswordStatusLabel
            // 
            this.vertifyPasswordStatusLabel.AutoSize = true;
            this.vertifyPasswordStatusLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.vertifyPasswordStatusLabel.Location = new System.Drawing.Point(268, 639);
            this.vertifyPasswordStatusLabel.Name = "vertifyPasswordStatusLabel";
            this.vertifyPasswordStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.vertifyPasswordStatusLabel.TabIndex = 30;
            this.vertifyPasswordStatusLabel.Text = "StatusVerify";
            // 
            // topBarPanel
            // 
            this.topBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topBarPanel.Controls.Add(this.button3);
            this.topBarPanel.Controls.Add(this.button2);
            this.topBarPanel.Controls.Add(this.button4);
            this.topBarPanel.Controls.Add(this.button1);
            this.topBarPanel.Location = new System.Drawing.Point(0, 0);
            this.topBarPanel.Name = "topBarPanel";
            this.topBarPanel.Size = new System.Drawing.Size(529, 22);
            this.topBarPanel.TabIndex = 43;
            this.topBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topBarPanel_Paint);
            this.topBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseDown);
            this.topBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBarPanel_MouseMove);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(479, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 22);
            this.button3.TabIndex = 45;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button3_MouseClick);
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
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(504, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 22);
            this.button4.TabIndex = 44;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // registerPicture
            // 
            this.registerPicture.Image = global::DriveLogGUI.Properties.Resources.avataricon;
            this.registerPicture.InitialImage = global::DriveLogGUI.Properties.Resources.avataricon;
            this.registerPicture.Location = new System.Drawing.Point(23, 79);
            this.registerPicture.Name = "registerPicture";
            this.registerPicture.Size = new System.Drawing.Size(128, 128);
            this.registerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.registerPicture.TabIndex = 29;
            this.registerPicture.TabStop = false;
            // 
            // signatureBox
            // 
            this.signatureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signatureBox.Location = new System.Drawing.Point(302, 339);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(180, 45);
            this.signatureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signatureBox.TabIndex = 44;
            this.signatureBox.TabStop = false;
            // 
            // signatureButton
            // 
            this.signatureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.signatureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signatureButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.signatureButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.signatureButton.Location = new System.Drawing.Point(340, 390);
            this.signatureButton.Name = "signatureButton";
            this.signatureButton.Size = new System.Drawing.Size(106, 30);
            this.signatureButton.TabIndex = 45;
            this.signatureButton.Text = "Edit Signature";
            this.signatureButton.UseVisualStyleBackColor = false;
            this.signatureButton.Click += new System.EventHandler(this.signatureButton_Click);
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.verifyPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyPasswordBox.DefaultText = "Verify Password";
            this.verifyPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.verifyPasswordBox.Location = new System.Drawing.Point(271, 612);
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
            this.registerZipBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerZipBox.Location = new System.Drawing.Point(23, 469);
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
            this.registerCityBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerCityBox.Location = new System.Drawing.Point(271, 469);
            this.registerCityBox.Name = "registerCityBox";
            this.registerCityBox.Size = new System.Drawing.Size(237, 23);
            this.registerCityBox.TabIndex = 7;
            this.registerCityBox.Text = "City";
            this.registerCityBox.Click += new System.EventHandler(this.registerCityBox_Click);
            this.registerCityBox.Leave += new System.EventHandler(this.registerCityBox_Leave);
            // 
            // registerAdressBox
            // 
            this.registerAdressBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.registerAdressBox.BorderColor = System.Drawing.Color.Blue;
            this.registerAdressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registerAdressBox.DefaultText = "Address";
            this.registerAdressBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.registerAdressBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerAdressBox.Location = new System.Drawing.Point(23, 429);
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
            this.registerCprBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerCprBox.Location = new System.Drawing.Point(271, 300);
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
            this.registerEmailBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerEmailBox.Location = new System.Drawing.Point(23, 339);
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
            this.registerPhoneBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerPhoneBox.Location = new System.Drawing.Point(23, 300);
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
            this.registerLastnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerLastnameBox.Location = new System.Drawing.Point(271, 261);
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
            this.registerFirstnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerFirstnameBox.Location = new System.Drawing.Point(23, 261);
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
            this.registerPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerPasswordBox.Location = new System.Drawing.Point(23, 612);
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
            this.registerUsernameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.registerUsernameBox.Location = new System.Drawing.Point(23, 570);
            this.registerUsernameBox.Name = "registerUsernameBox";
            this.registerUsernameBox.Size = new System.Drawing.Size(237, 23);
            this.registerUsernameBox.TabIndex = 8;
            this.registerUsernameBox.Text = "Username";
            this.registerUsernameBox.Click += new System.EventHandler(this.registerUsernameBox_Click);
            this.registerUsernameBox.Leave += new System.EventHandler(this.registerUsernameBox_Leave);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(529, 737);
            this.Controls.Add(this.signatureButton);
            this.Controls.Add(this.signatureBox);
            this.Controls.Add(this.topBarPanel);
            this.Controls.Add(this.labelForAccountDetails);
            this.Controls.Add(this.labelForAddress);
            this.Controls.Add(this.labelForPersonalInformation);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.topBarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.registerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureBox)).EndInit();
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
        private System.Windows.Forms.Label labelForPersonalInformation;
        private System.Windows.Forms.Label labelForAddress;
        private System.Windows.Forms.Label labelForAccountDetails;
        private System.Windows.Forms.Label vertifyPasswordStatusLabel;
        private System.Windows.Forms.Panel topBarPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox signatureBox;
        private System.Windows.Forms.Button signatureButton;
    }
}