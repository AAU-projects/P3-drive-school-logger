namespace DriveLogGUI.Windows
{
    partial class BookAppointmentWindow
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
            if (disposing && (components != null)) {
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.TitleDateLabel = new System.Windows.Forms.Label();
            this.TitleTimeLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::DriveLogGUI.Properties.Resources.exit6;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Location = new System.Drawing.Point(368, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 22);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topPanel.Controls.Add(this.CloseButton);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(393, 22);
            this.topPanel.TabIndex = 3;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseMove);
            // 
            // TitleDateLabel
            // 
            this.TitleDateLabel.AutoSize = true;
            this.TitleDateLabel.Font = new System.Drawing.Font("Calibri Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleDateLabel.Location = new System.Drawing.Point(2, 25);
            this.TitleDateLabel.Name = "TitleDateLabel";
            this.TitleDateLabel.Size = new System.Drawing.Size(378, 33);
            this.TitleDateLabel.TabIndex = 4;
            this.TitleDateLabel.Text = "Book appointment at 24-12-2012";
            // 
            // TitleTimeLabel
            // 
            this.TitleTimeLabel.AutoSize = true;
            this.TitleTimeLabel.Font = new System.Drawing.Font("Calibri Light", 16F);
            this.TitleTimeLabel.Location = new System.Drawing.Point(3, 58);
            this.TitleTimeLabel.Name = "TitleTimeLabel";
            this.TitleTimeLabel.Size = new System.Drawing.Size(125, 27);
            this.TitleTimeLabel.TabIndex = 5;
            this.TitleTimeLabel.Text = "09:00 - 13:00";
            // 
            // BookAppointmentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 221);
            this.Controls.Add(this.TitleTimeLabel);
            this.Controls.Add(this.TitleDateLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookAppointmentWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BookAppointmentWindow";
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label TitleDateLabel;
        private System.Windows.Forms.Label TitleTimeLabel;
    }
}