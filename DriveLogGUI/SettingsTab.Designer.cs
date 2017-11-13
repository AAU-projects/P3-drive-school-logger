namespace DriveLogGUI
{
    partial class SettingsTab
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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.templateButton = new System.Windows.Forms.Button();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.sidePanel.Controls.Add(this.templateButton);
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(132, 544);
            this.sidePanel.TabIndex = 0;
            // 
            // templateButton
            // 
            this.templateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateButton.FlatAppearance.BorderSize = 0;
            this.templateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateButton.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.templateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.templateButton.Location = new System.Drawing.Point(0, 3);
            this.templateButton.Name = "templateButton";
            this.templateButton.Size = new System.Drawing.Size(132, 30);
            this.templateButton.TabIndex = 1;
            this.templateButton.Text = "Lesson Templates";
            this.templateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.templateButton.UseVisualStyleBackColor = true;
            this.templateButton.Click += new System.EventHandler(this.templateButton_Click);
            // 
            // SettingsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sidePanel);
            this.Name = "SettingsTab";
            this.Size = new System.Drawing.Size(897, 544);
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button templateButton;
    }
}
