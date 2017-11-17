namespace DriveLogGUI
{
    partial class UserSearchTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSearchTab));
            this.logoutButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureSearchButton = new System.Windows.Forms.PictureBox();
            this.userCollectionMenu = new System.Windows.Forms.ComboBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.headerLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchButton)).BeginInit();
            this.resultsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(187)))), ((int)(((byte)(191)))));
            this.logoutButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.logoutButton.Location = new System.Drawing.Point(799, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(52, 44);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.headerPanel.Controls.Add(this.pictureSearchButton);
            this.headerPanel.Controls.Add(this.userCollectionMenu);
            this.headerPanel.Controls.Add(this.activeCheckBox);
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.searchBox);
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(873, 104);
            this.headerPanel.TabIndex = 5;
            // 
            // pictureSearchButton
            // 
            this.pictureSearchButton.BackColor = System.Drawing.Color.White;
            this.pictureSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("pictureSearchButton.Image")));
            this.pictureSearchButton.Location = new System.Drawing.Point(820, 62);
            this.pictureSearchButton.Name = "pictureSearchButton";
            this.pictureSearchButton.Size = new System.Drawing.Size(30, 30);
            this.pictureSearchButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSearchButton.TabIndex = 8;
            this.pictureSearchButton.TabStop = false;
            this.pictureSearchButton.Click += new System.EventHandler(this.pictureSearchButton_Click);
            this.pictureSearchButton.MouseEnter += new System.EventHandler(this.pictureSearchButton_MouseEnter);
            this.pictureSearchButton.MouseLeave += new System.EventHandler(this.pictureSearchButton_MouseLeave);
            // 
            // userCollectionMenu
            // 
            this.userCollectionMenu.BackColor = System.Drawing.SystemColors.Window;
            this.userCollectionMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userCollectionMenu.FormattingEnabled = true;
            this.userCollectionMenu.Items.AddRange(new object[] {
            "Students Only",
            "Instructors Only",
            "All Users"});
            this.userCollectionMenu.Location = new System.Drawing.Point(22, 34);
            this.userCollectionMenu.Name = "userCollectionMenu";
            this.userCollectionMenu.Size = new System.Drawing.Size(121, 21);
            this.userCollectionMenu.TabIndex = 9;
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Checked = true;
            this.activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activeCheckBox.Location = new System.Drawing.Point(149, 36);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(106, 17);
            this.activeCheckBox.TabIndex = 2;
            this.activeCheckBox.Text = "Active users only";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Calibri", 15F);
            this.searchBox.Location = new System.Drawing.Point(22, 61);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(829, 32);
            this.searchBox.TabIndex = 1;
            this.searchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyUp);
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("Myanmar Text", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(132)))), ((int)(((byte)(144)))));
            this.headerLabel.Location = new System.Drawing.Point(12, 6);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(848, 44);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Search for Users";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.resultsPanel.Controls.Add(this.errorLabel);
            this.resultsPanel.Location = new System.Drawing.Point(12, 122);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(873, 409);
            this.resultsPanel.TabIndex = 7;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Calibri", 20F);
            this.errorLabel.Location = new System.Drawing.Point(318, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(187, 33);
            this.errorLabel.TabIndex = 0;
            this.errorLabel.Text = "No Users Found";
            // 
            // UserSearchTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "UserSearchTab";
            this.Size = new System.Drawing.Size(897, 544);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearchButton)).EndInit();
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.PictureBox pictureSearchButton;
        private System.Windows.Forms.ComboBox userCollectionMenu;
    }
}
