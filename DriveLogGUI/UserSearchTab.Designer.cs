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
            this.logoutButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.studentsOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(187)))), ((int)(((byte)(191)))));
            this.logoutButton.FlatAppearance.BorderSize = 0;
            this.logoutButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.logoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.logoutButton.Location = new System.Drawing.Point(808, 6);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(52, 44);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = false;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.headerPanel.Controls.Add(this.checkBox1);
            this.headerPanel.Controls.Add(this.studentsOnlyCheckBox);
            this.headerPanel.Controls.Add(this.activeCheckBox);
            this.headerPanel.Controls.Add(this.logoutButton);
            this.headerPanel.Controls.Add(this.searchBox);
            this.headerPanel.Controls.Add(this.headerLabel);
            this.headerPanel.Location = new System.Drawing.Point(12, 12);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(873, 118);
            this.headerPanel.TabIndex = 5;
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
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(22, 55);
            this.searchBox.Multiline = true;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(838, 40);
            this.searchBox.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Checked = true;
            this.activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeCheckBox.Location = new System.Drawing.Point(22, 98);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(106, 17);
            this.activeCheckBox.TabIndex = 2;
            this.activeCheckBox.Text = "Active users only";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // studentsOnlyCheckBox
            // 
            this.studentsOnlyCheckBox.AutoSize = true;
            this.studentsOnlyCheckBox.Checked = true;
            this.studentsOnlyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.studentsOnlyCheckBox.Location = new System.Drawing.Point(134, 98);
            this.studentsOnlyCheckBox.Name = "studentsOnlyCheckBox";
            this.studentsOnlyCheckBox.Size = new System.Drawing.Size(90, 17);
            this.studentsOnlyCheckBox.TabIndex = 3;
            this.studentsOnlyCheckBox.Text = "Students only";
            this.studentsOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(230, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Eventuel check box?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // resultsPanel
            // 
            this.resultsPanel.AutoScroll = true;
            this.resultsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.resultsPanel.Location = new System.Drawing.Point(12, 136);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(873, 395);
            this.resultsPanel.TabIndex = 7;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox studentsOnlyCheckBox;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.Panel resultsPanel;
    }
}
