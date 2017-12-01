namespace DriveLogGUI.Windows
{
    partial class UploadProfilePicForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dragAndDropLabel = new System.Windows.Forms.Label();
            this.UploadButton = new System.Windows.Forms.Button();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.overlayPanel = new System.Windows.Forms.Panel();
            this.dragPicture = new System.Windows.Forms.PictureBox();
            this.dragAndDropPictureBox = new System.Windows.Forms.PictureBox();
            this.editPictureBox = new System.Windows.Forms.PictureBox();
            this.dragPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dragPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragAndDropPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose profile picture";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.acceptButton.FlatAppearance.BorderSize = 0;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.ForeColor = System.Drawing.Color.White;
            this.acceptButton.Location = new System.Drawing.Point(205, 521);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(153, 34);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Set profile picture";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Gainsboro;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(364, 521);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(104, 34);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dragAndDropLabel
            // 
            this.dragAndDropLabel.AutoSize = true;
            this.dragAndDropLabel.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dragAndDropLabel.Location = new System.Drawing.Point(122, 335);
            this.dragAndDropLabel.Name = "dragAndDropLabel";
            this.dragAndDropLabel.Size = new System.Drawing.Size(435, 46);
            this.dragAndDropLabel.TabIndex = 4;
            this.dragAndDropLabel.Text = "Drag and drop a picture here,\r\nor click the button bellow to select a picture fro" +
    "m the PC";
            this.dragAndDropLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.Gainsboro;
            this.UploadButton.FlatAppearance.BorderSize = 0;
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.Color.Black;
            this.UploadButton.Location = new System.Drawing.Point(276, 449);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(133, 39);
            this.UploadButton.TabIndex = 7;
            this.UploadButton.Text = "Browse Files";
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.Transparent;
            this.dragPanel.Controls.Add(this.dragPicture);
            this.dragPanel.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.dragPanel.ForeColor = System.Drawing.Color.Red;
            this.dragPanel.Location = new System.Drawing.Point(247, 155);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(200, 200);
            this.dragPanel.TabIndex = 8;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseDown);
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseMove);
            this.dragPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseUp);
            // 
            // overlayPanel
            // 
            this.overlayPanel.BackColor = System.Drawing.Color.Black;
            this.overlayPanel.Location = new System.Drawing.Point(41, 188);
            this.overlayPanel.Name = "overlayPanel";
            this.overlayPanel.Size = new System.Drawing.Size(200, 100);
            this.overlayPanel.TabIndex = 9;
            // 
            // dragPicture
            // 
            this.dragPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dragPicture.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.dragPicture.Image = global::DriveLogGUI.Properties.Resources.resize2;
            this.dragPicture.Location = new System.Drawing.Point(179, 177);
            this.dragPicture.Name = "dragPicture";
            this.dragPicture.Size = new System.Drawing.Size(20, 22);
            this.dragPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragPicture.TabIndex = 0;
            this.dragPicture.TabStop = false;
            this.dragPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPicture_MouseDown);
            this.dragPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragPicture_MouseMove);
            this.dragPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dragPicture_MouseUp);
            // 
            // dragAndDropPictureBox
            // 
            this.dragAndDropPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.dragAndDropPictureBox.Image = global::DriveLogGUI.Properties.Resources.drag_and_drop_icon;
            this.dragAndDropPictureBox.InitialImage = null;
            this.dragAndDropPictureBox.Location = new System.Drawing.Point(247, 132);
            this.dragAndDropPictureBox.Name = "dragAndDropPictureBox";
            this.dragAndDropPictureBox.Size = new System.Drawing.Size(200, 200);
            this.dragAndDropPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragAndDropPictureBox.TabIndex = 3;
            this.dragAndDropPictureBox.TabStop = false;
            // 
            // editPictureBox
            // 
            this.editPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editPictureBox.Location = new System.Drawing.Point(12, 105);
            this.editPictureBox.Name = "editPictureBox";
            this.editPictureBox.Size = new System.Drawing.Size(671, 338);
            this.editPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.editPictureBox.TabIndex = 6;
            this.editPictureBox.TabStop = false;
            // 
            // UploadProfilePicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(695, 570);
            this.Controls.Add(this.overlayPanel);
            this.Controls.Add(this.dragPanel);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.dragAndDropLabel);
            this.Controls.Add(this.dragAndDropPictureBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UploadProfilePicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose profile picture";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UploadProfilePicForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UploadProfilePicForm_DragEnter);
            this.dragPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dragPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragAndDropPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox dragAndDropPictureBox;
        private System.Windows.Forms.Label dragAndDropLabel;
        private System.Windows.Forms.PictureBox editPictureBox;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.PictureBox dragPicture;
        private System.Windows.Forms.Panel overlayPanel;
    }
}