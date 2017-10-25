namespace DriveLogGUI
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
            this.dragAndDropPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uploadPictureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dragAndDropPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose profile picture";
            // 
            // acceptButton
            // 
            this.acceptButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.acceptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptButton.ForeColor = System.Drawing.Color.White;
            this.acceptButton.Location = new System.Drawing.Point(193, 521);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(153, 34);
            this.acceptButton.TabIndex = 1;
            this.acceptButton.Text = "Set profile picture";
            this.acceptButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Gainsboro;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // dragAndDropPictureBox
            // 
            this.dragAndDropPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.dragAndDropPictureBox.Image = global::DriveLogGUI.Properties.Resources.drag_and_drop_icon;
            this.dragAndDropPictureBox.InitialImage = null;
            this.dragAndDropPictureBox.Location = new System.Drawing.Point(237, 152);
            this.dragAndDropPictureBox.Name = "dragAndDropPictureBox";
            this.dragAndDropPictureBox.Size = new System.Drawing.Size(200, 200);
            this.dragAndDropPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragAndDropPictureBox.TabIndex = 3;
            this.dragAndDropPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(435, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drag and drop a picture here,\r\nor click the button bellow to select a picture fro" +
    "m the PC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // uploadPictureButton
            // 
            this.uploadPictureButton.BackColor = System.Drawing.Color.Gainsboro;
            this.uploadPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadPictureButton.Font = new System.Drawing.Font("Calibri Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadPictureButton.ForeColor = System.Drawing.Color.Black;
            this.uploadPictureButton.Location = new System.Drawing.Point(279, 391);
            this.uploadPictureButton.Name = "uploadPictureButton";
            this.uploadPictureButton.Size = new System.Drawing.Size(104, 34);
            this.uploadPictureButton.TabIndex = 5;
            this.uploadPictureButton.Text = "Choose image";
            this.uploadPictureButton.UseVisualStyleBackColor = false;
            // 
            // UploadProfilePicForm
            // 
            this.AcceptButton = this.uploadPictureButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(695, 578);
            this.Controls.Add(this.uploadPictureButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dragAndDropPictureBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UploadProfilePicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose profile picture";
            ((System.ComponentModel.ISupportInitialize)(this.dragAndDropPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox dragAndDropPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uploadPictureButton;
    }
}