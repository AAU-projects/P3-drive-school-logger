namespace DriveLogGUI
{
    partial class LoginForm
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
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.createNewUserLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // UsernameBox
            // 
            this.UsernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.UsernameBox.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.UsernameBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.UsernameBox.Location = new System.Drawing.Point(12, 12);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(276, 34);
            this.UsernameBox.TabIndex = 2;
            this.UsernameBox.Text = "Username";
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.PasswordBox.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.PasswordBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.PasswordBox.Location = new System.Drawing.Point(12, 52);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(276, 34);
            this.PasswordBox.TabIndex = 3;
            this.PasswordBox.Text = "Password";
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.loginButton.Location = new System.Drawing.Point(12, 92);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(276, 35);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // createNewUserLabel
            // 
            this.createNewUserLabel.AutoSize = true;
            this.createNewUserLabel.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.createNewUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.createNewUserLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.createNewUserLabel.Location = new System.Drawing.Point(94, 130);
            this.createNewUserLabel.Name = "createNewUserLabel";
            this.createNewUserLabel.Size = new System.Drawing.Size(116, 19);
            this.createNewUserLabel.TabIndex = 5;
            this.createNewUserLabel.TabStop = true;
            this.createNewUserLabel.Text = "Create new user";
            this.createNewUserLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createNewUserLabel_LinkClicked);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(303, 163);
            this.Controls.Add(this.createNewUserLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.LinkLabel createNewUserLabel;
    }
}

