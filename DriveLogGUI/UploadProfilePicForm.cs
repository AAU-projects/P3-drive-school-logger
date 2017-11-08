using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class UploadProfilePicForm : Form
    {
        public UploadProfilePicForm(Form registerForm, ref Image location)
        {
            _registerForm = registerForm;
            _location = location;
            InitializeComponent();
            this.AllowDrop = true;
        }

        private static Form _registerForm;
        private Image _location;
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _registerForm.Show();
        }

        private void UploadProfilePicForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void UploadProfilePicForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 1 && ValidateDroppedFile(files[0]))
            {
                dragAndDropLabel.Visible = false;
                dragAndDropPictureBox.Visible = false;
                
                editPictureBox.Image = Image.FromFile(files[0]);
            }
        }


        private static readonly List<string> AcceptedImageExtensions = new List<string> { ".jpg", ".png", ".bmp", };
        private bool ValidateDroppedFile(string filepath)
        {
            if (AcceptedImageExtensions.Contains(Path.GetExtension(filepath).ToLower())) return true;
            return false;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (editPictureBox.Image == null) return;

            _location = editPictureBox.Image;
            this.Dispose();
            _registerForm.Show();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
