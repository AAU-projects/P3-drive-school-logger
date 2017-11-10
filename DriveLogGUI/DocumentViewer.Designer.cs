using System.Windows.Forms;
using Spire.PdfViewer.Forms;

namespace DriveLogGUI
{
    partial class DocumentViewer
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.viewer = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.viewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Calibri Light", 28F, System.Drawing.FontStyle.Bold);
            this.TitleLabel.Location = new System.Drawing.Point(44, 17);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(268, 46);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Document Title";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Italic);
            this.DateLabel.Location = new System.Drawing.Point(300, 39);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(48, 24);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Date";
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.uploadButton.FlatAppearance.BorderSize = 0;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("Calibri Light", 16.25F);
            this.uploadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.uploadButton.Location = new System.Drawing.Point(732, 21);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(115, 39);
            this.uploadButton.TabIndex = 3;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // viewer
            // 
            this.viewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.viewer.Location = new System.Drawing.Point(50, 82);
            this.viewer.MultiPagesThreshold = 60;
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(797, 460);
            this.viewer.TabIndex = 4;
            this.viewer.Text = "Pdf Viewer";
            this.viewer.Threshold = 60;
            this.viewer.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // DocumentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewer);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "DocumentViewer";
            this.Size = new System.Drawing.Size(897, 544);
            this.viewer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Button uploadButton;
        private PdfDocumentViewer viewer;
    }
}
