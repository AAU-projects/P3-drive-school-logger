﻿namespace DriveLogGUI
{
    partial class CustomMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageForm));
            this.NoButton = new System.Windows.Forms.Button();
            this.YesButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.topBar = new System.Windows.Forms.Panel();
            this.captionLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.symbolpictureBox = new System.Windows.Forms.PictureBox();
            this.textboxPanel = new System.Windows.Forms.Panel();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolpictureBox)).BeginInit();
            this.textboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoButton
            // 
            this.NoButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.NoButton.Location = new System.Drawing.Point(142, 101);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(75, 23);
            this.NoButton.TabIndex = 19;
            this.NoButton.Text = "No";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.Visible = false;
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // YesButton
            // 
            this.YesButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.YesButton.Location = new System.Drawing.Point(40, 101);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(75, 23);
            this.YesButton.TabIndex = 24;
            this.YesButton.Text = "Yes";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Visible = false;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.Location = new System.Drawing.Point(0, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(179, 59);
            this.textLabel.TabIndex = 23;
            this.textLabel.Text = "This is how much text you want This is how much text you want This is how much te" +
    "xt you want";
            // 
            // okButton
            // 
            this.okButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.okButton.Location = new System.Drawing.Point(89, 101);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 20;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(108)))), ((int)(((byte)(112)))));
            this.topBar.Controls.Add(this.captionLabel);
            this.topBar.Controls.Add(this.closeButton);
            this.topBar.Controls.Add(this.button2);
            this.topBar.Controls.Add(this.button1);
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(252, 22);
            this.topBar.TabIndex = 22;
            this.topBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseDown);
            this.topBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.topBar_MouseMove);
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.ForeColor = System.Drawing.Color.White;
            this.captionLabel.Location = new System.Drawing.Point(3, 5);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(77, 13);
            this.captionLabel.TabIndex = 4;
            this.captionLabel.Text = "Error message:";
            // 
            // closeButton
            // 
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(227, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(25, 22);
            this.closeButton.TabIndex = 3;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button3_Click);
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
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageBox.Location = new System.Drawing.Point(61, 36);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(179, 59);
            this.messageBox.TabIndex = 21;
            this.messageBox.Visible = false;
            // 
            // symbolpictureBox
            // 
            this.symbolpictureBox.Image = global::DriveLogGUI.Properties.Resources.icons8_checkmark;
            this.symbolpictureBox.Location = new System.Drawing.Point(12, 45);
            this.symbolpictureBox.Name = "symbolpictureBox";
            this.symbolpictureBox.Size = new System.Drawing.Size(40, 40);
            this.symbolpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.symbolpictureBox.TabIndex = 25;
            this.symbolpictureBox.TabStop = false;
            // 
            // textboxPanel
            // 
            this.textboxPanel.Controls.Add(this.textLabel);
            this.textboxPanel.Location = new System.Drawing.Point(58, 36);
            this.textboxPanel.Name = "textboxPanel";
            this.textboxPanel.Size = new System.Drawing.Size(179, 59);
            this.textboxPanel.TabIndex = 26;
            // 
            // CustomMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 133);
            this.Controls.Add(this.textboxPanel);
            this.Controls.Add(this.symbolpictureBox);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.messageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomMessageForm2";
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbolpictureBox)).EndInit();
            this.textboxPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button NoButton;
        public System.Windows.Forms.Button YesButton;
        public System.Windows.Forms.Label textLabel;
        public System.Windows.Forms.Button okButton;
        public System.Windows.Forms.Panel topBar;
        public System.Windows.Forms.Label captionLabel;
        public System.Windows.Forms.Button closeButton;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox messageBox;
        public System.Windows.Forms.PictureBox symbolpictureBox;
        public System.Windows.Forms.Panel textboxPanel;
    }
}