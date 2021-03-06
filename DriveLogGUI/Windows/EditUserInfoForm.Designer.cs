﻿using DriveLogGUI.CustomControls;

namespace DriveLogGUI.Windows
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.passwordStatusLabel = new System.Windows.Forms.Label();
            this.accountDetailsLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.personalInformationLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.editPictureButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.instructorCheckBox = new System.Windows.Forms.CheckBox();
            this.zipBox = new TextboxBorderColor();
            this.cityBox = new TextboxBorderColor();
            this.addressBox = new TextboxBorderColor();
            this.emailBox = new TextboxBorderColor();
            this.phoneBox = new TextboxBorderColor();
            this.lastnameBox = new TextboxBorderColor();
            this.firstnameBox = new TextboxBorderColor();
            this.verifyEditPasswordBox = new TextboxBorderColor();
            this.editPasswordBox = new TextboxBorderColor();
            this.usernameBox = new TextboxBorderColor();
            this.verifyPasswordBox = new TextboxBorderColor();
            this.signatureButton = new System.Windows.Forms.Button();
            this.signatureBox = new System.Windows.Forms.PictureBox();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyPasswordLabel
            // 
            this.verifyPasswordLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verifyPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.verifyPasswordLabel.Location = new System.Drawing.Point(0, 80);
            this.verifyPasswordLabel.Name = "verifyPasswordLabel";
            this.verifyPasswordLabel.Size = new System.Drawing.Size(529, 33);
            this.verifyPasswordLabel.TabIndex = 43;
            this.verifyPasswordLabel.Text = "Verify Password";
            this.verifyPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editProfileHeaderLabel
            // 
            this.editProfileHeaderLabel.Font = new System.Drawing.Font("Calibri", 25F);
            this.editProfileHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.editProfileHeaderLabel.Location = new System.Drawing.Point(0, 32);
            this.editProfileHeaderLabel.Name = "editProfileHeaderLabel";
            this.editProfileHeaderLabel.Size = new System.Drawing.Size(529, 48);
            this.editProfileHeaderLabel.TabIndex = 44;
            this.editProfileHeaderLabel.Text = "Edit User Information";
            this.editProfileHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verifyPasswordInfo
            // 
            this.verifyPasswordInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.verifyPasswordInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.verifyPasswordInfo.Location = new System.Drawing.Point(0, 113);
            this.verifyPasswordInfo.Name = "verifyPasswordInfo";
            this.verifyPasswordInfo.Size = new System.Drawing.Size(529, 24);
            this.verifyPasswordInfo.TabIndex = 45;
            this.verifyPasswordInfo.Text = "Please enter your current password to make changes";
            this.verifyPasswordInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
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
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
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
            // passwordStatusLabel
            // 
            this.passwordStatusLabel.AutoSize = true;
            this.passwordStatusLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStatusLabel.Location = new System.Drawing.Point(15, 294);
            this.passwordStatusLabel.Name = "passwordStatusLabel";
            this.passwordStatusLabel.Size = new System.Drawing.Size(0, 15);
            this.passwordStatusLabel.TabIndex = 51;
            // 
            // accountDetailsLabel
            // 
            this.accountDetailsLabel.AutoSize = true;
            this.accountDetailsLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountDetailsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.accountDetailsLabel.Location = new System.Drawing.Point(14, 187);
            this.accountDetailsLabel.Name = "accountDetailsLabel";
            this.accountDetailsLabel.Size = new System.Drawing.Size(185, 33);
            this.accountDetailsLabel.TabIndex = 53;
            this.accountDetailsLabel.Text = "Account Details";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.addressLabel.Location = new System.Drawing.Point(16, 514);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(103, 33);
            this.addressLabel.TabIndex = 62;
            this.addressLabel.Text = "Address";
            // 
            // personalInformationLabel
            // 
            this.personalInformationLabel.AutoSize = true;
            this.personalInformationLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalInformationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.personalInformationLabel.Location = new System.Drawing.Point(14, 369);
            this.personalInformationLabel.Name = "personalInformationLabel";
            this.personalInformationLabel.Size = new System.Drawing.Size(243, 33);
            this.personalInformationLabel.TabIndex = 61;
            this.personalInformationLabel.Text = "Personal Information";
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
            this.editPictureButton.Click += new System.EventHandler(this.editPictureButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.saveChangesButton.Enabled = false;
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.saveChangesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.saveChangesButton.Location = new System.Drawing.Point(195, 648);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(138, 36);
            this.saveChangesButton.TabIndex = 12;
            this.saveChangesButton.Text = "Save";
            this.saveChangesButton.UseVisualStyleBackColor = false;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // instructorCheckBox
            // 
            this.instructorCheckBox.AutoSize = true;
            this.instructorCheckBox.Enabled = false;
            this.instructorCheckBox.ForeColor = System.Drawing.Color.DarkGray;
            this.instructorCheckBox.Location = new System.Drawing.Point(18, 347);
            this.instructorCheckBox.Name = "instructorCheckBox";
            this.instructorCheckBox.Size = new System.Drawing.Size(70, 17);
            this.instructorCheckBox.TabIndex = 65;
            this.instructorCheckBox.Text = "Instructor";
            this.instructorCheckBox.UseVisualStyleBackColor = true;
            this.instructorCheckBox.Visible = false;
            // 
            // zipBox
            // 
            this.zipBox.BackColor = System.Drawing.SystemColors.Control;
            this.zipBox.BorderColor = System.Drawing.Color.Blue;
            this.zipBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zipBox.DefaultText = "Zip Code";
            this.zipBox.Enabled = false;
            this.zipBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.zipBox.ForeColor = System.Drawing.Color.DarkGray;
            this.zipBox.Location = new System.Drawing.Point(22, 595);
            this.zipBox.Name = "zipBox";
            this.zipBox.Size = new System.Drawing.Size(237, 23);
            this.zipBox.TabIndex = 9;
            this.zipBox.Text = "Zip Code";
            this.zipBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zipBox_MouseClick);
            this.zipBox.Leave += new System.EventHandler(this.zipBox_Leave);
            // 
            // cityBox
            // 
            this.cityBox.BackColor = System.Drawing.SystemColors.Control;
            this.cityBox.BorderColor = System.Drawing.Color.Blue;
            this.cityBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cityBox.DefaultText = "City";
            this.cityBox.Enabled = false;
            this.cityBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.cityBox.ForeColor = System.Drawing.Color.DarkGray;
            this.cityBox.Location = new System.Drawing.Point(270, 595);
            this.cityBox.Name = "cityBox";
            this.cityBox.Size = new System.Drawing.Size(237, 23);
            this.cityBox.TabIndex = 10;
            this.cityBox.Text = "City";
            this.cityBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cityBox_MouseClick);
            this.cityBox.Leave += new System.EventHandler(this.cityBox_Leave);
            // 
            // addressBox
            // 
            this.addressBox.BackColor = System.Drawing.SystemColors.Control;
            this.addressBox.BorderColor = System.Drawing.Color.Blue;
            this.addressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addressBox.DefaultText = "Address";
            this.addressBox.Enabled = false;
            this.addressBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.addressBox.ForeColor = System.Drawing.Color.DarkGray;
            this.addressBox.Location = new System.Drawing.Point(22, 555);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(237, 23);
            this.addressBox.TabIndex = 8;
            this.addressBox.Text = "Address";
            this.addressBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addressBox_MouseClick);
            this.addressBox.Leave += new System.EventHandler(this.addressBox_Leave);
            // 
            // emailBox
            // 
            this.emailBox.BackColor = System.Drawing.SystemColors.Control;
            this.emailBox.BorderColor = System.Drawing.Color.Blue;
            this.emailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailBox.DefaultText = "Email Address";
            this.emailBox.Enabled = false;
            this.emailBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.emailBox.ForeColor = System.Drawing.Color.DarkGray;
            this.emailBox.Location = new System.Drawing.Point(268, 455);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(237, 23);
            this.emailBox.TabIndex = 7;
            this.emailBox.Text = "Email Address";
            this.emailBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.emailBox_MouseClick);
            this.emailBox.Leave += new System.EventHandler(this.emailBox_Leave);
            // 
            // phoneBox
            // 
            this.phoneBox.BackColor = System.Drawing.SystemColors.Control;
            this.phoneBox.BorderColor = System.Drawing.Color.Blue;
            this.phoneBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneBox.DefaultText = "Phone Number";
            this.phoneBox.Enabled = false;
            this.phoneBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.phoneBox.ForeColor = System.Drawing.Color.DarkGray;
            this.phoneBox.Location = new System.Drawing.Point(20, 455);
            this.phoneBox.Name = "phoneBox";
            this.phoneBox.Size = new System.Drawing.Size(237, 23);
            this.phoneBox.TabIndex = 6;
            this.phoneBox.Text = "Phone Number";
            this.phoneBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.phoneBox_MouseClick);
            this.phoneBox.Leave += new System.EventHandler(this.phoneBox_Leave);
            // 
            // lastnameBox
            // 
            this.lastnameBox.BackColor = System.Drawing.SystemColors.Control;
            this.lastnameBox.BorderColor = System.Drawing.Color.Blue;
            this.lastnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastnameBox.DefaultText = "Lastname";
            this.lastnameBox.Enabled = false;
            this.lastnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.lastnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.lastnameBox.Location = new System.Drawing.Point(268, 416);
            this.lastnameBox.Name = "lastnameBox";
            this.lastnameBox.Size = new System.Drawing.Size(237, 23);
            this.lastnameBox.TabIndex = 5;
            this.lastnameBox.Text = "Lastname";
            this.lastnameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lastnameBox_MouseClick);
            this.lastnameBox.Leave += new System.EventHandler(this.lastnameBox_Leave);
            // 
            // firstnameBox
            // 
            this.firstnameBox.BackColor = System.Drawing.SystemColors.Control;
            this.firstnameBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.firstnameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstnameBox.DefaultText = "Firstname";
            this.firstnameBox.Enabled = false;
            this.firstnameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.firstnameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.firstnameBox.Location = new System.Drawing.Point(20, 416);
            this.firstnameBox.Name = "firstnameBox";
            this.firstnameBox.ShortcutsEnabled = false;
            this.firstnameBox.Size = new System.Drawing.Size(237, 23);
            this.firstnameBox.TabIndex = 4;
            this.firstnameBox.Text = "Firstname";
            this.firstnameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.firstnameBox_MouseClick);
            this.firstnameBox.Leave += new System.EventHandler(this.firstnameBox_Leave);
            // 
            // verifyEditPasswordBox
            // 
            this.verifyEditPasswordBox.BackColor = System.Drawing.SystemColors.Control;
            this.verifyEditPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyEditPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyEditPasswordBox.DefaultText = "Verify Password";
            this.verifyEditPasswordBox.Enabled = false;
            this.verifyEditPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyEditPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.verifyEditPasswordBox.Location = new System.Drawing.Point(18, 311);
            this.verifyEditPasswordBox.Name = "verifyEditPasswordBox";
            this.verifyEditPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.verifyEditPasswordBox.TabIndex = 3;
            this.verifyEditPasswordBox.Text = "Verify Password";
            this.verifyEditPasswordBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.verifyEditPasswordBox_MouseClick);
            this.verifyEditPasswordBox.TextChanged += new System.EventHandler(this.verifyEditPasswordBox_TextChanged);
            this.verifyEditPasswordBox.Leave += new System.EventHandler(this.verifyEditPasswordBox_Leave);
            // 
            // editPasswordBox
            // 
            this.editPasswordBox.BackColor = System.Drawing.SystemColors.Control;
            this.editPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.editPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editPasswordBox.DefaultText = "Password";
            this.editPasswordBox.Enabled = false;
            this.editPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.editPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.editPasswordBox.Location = new System.Drawing.Point(18, 265);
            this.editPasswordBox.Name = "editPasswordBox";
            this.editPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.editPasswordBox.TabIndex = 2;
            this.editPasswordBox.Text = "Password";
            this.editPasswordBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.editPasswordBox_MouseClick);
            this.editPasswordBox.TextChanged += new System.EventHandler(this.editPasswordBox_TextChanged);
            this.editPasswordBox.Leave += new System.EventHandler(this.editPasswordBox_Leave);
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.SystemColors.Control;
            this.usernameBox.BorderColor = System.Drawing.Color.Blue;
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameBox.DefaultText = "Username";
            this.usernameBox.Enabled = false;
            this.usernameBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.usernameBox.ForeColor = System.Drawing.Color.DarkGray;
            this.usernameBox.Location = new System.Drawing.Point(18, 223);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(237, 23);
            this.usernameBox.TabIndex = 1;
            this.usernameBox.Text = "Username";
            this.usernameBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.usernameBox_MouseClick);
            this.usernameBox.Leave += new System.EventHandler(this.usernameBox_Leave);
            // 
            // verifyPasswordBox
            // 
            this.verifyPasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(212)))), ((int)(((byte)(225)))));
            this.verifyPasswordBox.BorderColor = System.Drawing.Color.Blue;
            this.verifyPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.verifyPasswordBox.DefaultText = "Password";
            this.verifyPasswordBox.Font = new System.Drawing.Font("Calibri Light", 14F);
            this.verifyPasswordBox.ForeColor = System.Drawing.Color.DarkGray;
            this.verifyPasswordBox.Location = new System.Drawing.Point(145, 140);
            this.verifyPasswordBox.Name = "verifyPasswordBox";
            this.verifyPasswordBox.Size = new System.Drawing.Size(237, 23);
            this.verifyPasswordBox.TabIndex = 0;
            this.verifyPasswordBox.Text = "Password";
            this.verifyPasswordBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.verifyPasswordBox_MouseClick);
            this.verifyPasswordBox.TextChanged += new System.EventHandler(this.verifyPasswordBox_TextChanged);
            this.verifyPasswordBox.Leave += new System.EventHandler(this.verifyPasswordBox_Leave);
            // 
            // signatureButton
            // 
            this.signatureButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.signatureButton.Enabled = false;
            this.signatureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signatureButton.Font = new System.Drawing.Font("Calibri Light", 10F);
            this.signatureButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.signatureButton.Location = new System.Drawing.Point(336, 544);
            this.signatureButton.Name = "signatureButton";
            this.signatureButton.Size = new System.Drawing.Size(106, 30);
            this.signatureButton.TabIndex = 67;
            this.signatureButton.Text = "Edit Signature";
            this.signatureButton.UseVisualStyleBackColor = false;
            this.signatureButton.Click += new System.EventHandler(this.signatureButton_Click);
            // 
            // signatureBox
            // 
            this.signatureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signatureBox.Location = new System.Drawing.Point(298, 493);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(180, 45);
            this.signatureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.signatureBox.TabIndex = 66;
            this.signatureBox.TabStop = false;
            // 
            // EditUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(529, 695);
            this.Controls.Add(this.signatureButton);
            this.Controls.Add(this.signatureBox);
            this.Controls.Add(this.instructorCheckBox);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditUserInfoForm";
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signatureBox)).EndInit();
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
        private System.Windows.Forms.CheckBox instructorCheckBox;
        private System.Windows.Forms.Button signatureButton;
        private System.Windows.Forms.PictureBox signatureBox;
    }
}