using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DriveLogGUI.Windows
{
    public partial class UploadProfilePicForm : Form
    {
        private Bitmap originalImage;
        private Bitmap croppedImage;
        private Point startPoint;
        private Point endPoint;

        public UploadProfilePicForm(Form registerForm)
        {
            _registerForm = registerForm;
            InitializeComponent();
            editPictureBox.Controls.Add(dragPanel);
            dragPicture.Visible = false;
            dragPanel.Visible = false;
            this.AllowDrop = true;

            UploadButton.Anchor = AnchorStyles.Bottom;
        }

        private static Form _registerForm;

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

                // Resets the picturebox location and resizes the image.
                ResetPictureBox();
                Image draggedImage = Image.FromFile(files[0]);
                draggedImage = CheckImageSize(draggedImage);

                // Sets position, width, and height for picturebox.
                editPictureBox.Width = draggedImage.Width;
                editPictureBox.Height = draggedImage.Height;
                editPictureBox.Left = this.Width / 2 - draggedImage.Width / 2;
                editPictureBox.Image = draggedImage;
                editPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                SetDragPanelPosition();
                dragPicture.Visible = true;
                dragPanel.Visible = true;
            }
        }

        private Image CheckImageSize(Image image)
        {
            Image imageToCheck = image;

            if (imageToCheck.Width > editPictureBox.Width)
            {
                decimal newHeight = (Convert.ToDecimal(imageToCheck.Height) / Convert.ToDecimal(imageToCheck.Width)) * Convert.ToDecimal(editPictureBox.Width);
                imageToCheck = ResizeImage(imageToCheck, editPictureBox.Width, (int)newHeight);
            }

            if (imageToCheck.Height > editPictureBox.Height)
            {
                decimal newWidth = (Convert.ToDecimal(imageToCheck.Width) / Convert.ToDecimal(imageToCheck.Height)) * Convert.ToDecimal(editPictureBox.Height);
                imageToCheck = ResizeImage(imageToCheck, (int)newWidth, editPictureBox.Height);
            }

            return imageToCheck;
        }

        private void ResetPictureBox()
        {
            this.editPictureBox.Location = new Point(12, 105);
            this.editPictureBox.Size = new Size(671, 338);
        }

        private void SetDragPanelPosition()
        {
            if (editPictureBox.Width > editPictureBox.Height)
            {
                dragPanel.Width = editPictureBox.Height;
                dragPanel.Height = editPictureBox.Height;
            }
            else
            {
                dragPanel.Width = editPictureBox.Width;
                dragPanel.Height = editPictureBox.Width;
            }
            dragPanel.Left = 0;
            dragPanel.Top = 0;
        }

        private Bitmap ResizeImage(Image Image, int Width, int Height)
        {
            var destRect = new Rectangle(0, 0, Width, Height);
            var destImage = new Bitmap(Width, Height);

            destImage.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(Image, destRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private static readonly List<string> AcceptedImageExtensions = new List<string> { ".jpg", ".png", ".bmp",".jpeg" };
        private bool ValidateDroppedFile(string filepath)
        {
            if (AcceptedImageExtensions.Contains(Path.GetExtension(filepath).ToLower())) return true;
            return false;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (editPictureBox.Image == null) return;

            if (_registerForm is RegisterForm)
            {
                RegisterForm tempregisterForm = _registerForm as RegisterForm;

                tempregisterForm.ProfileImage = editPictureBox.Image;
            }
            else if (_registerForm is EditUserInfoForm)
            {
                EditUserInfoForm tempregisterForm = _registerForm as EditUserInfoForm;

                tempregisterForm.ProfilePicture = editPictureBox.Image;
            }
            this.Dispose();
            _registerForm.Show();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {

        }

        bool allowResize = false;
        private void dragPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (dragPanel.Bottom < 0)
            {
                dragPanel.Height = editPictureBox.Height;
                dragPanel.Width = editPictureBox.Height;
            }
            allowResize = false;
        }

        private void dragPicture_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
        }

        private void dragPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                this.dragPanel.Height = dragPicture.Top + e.Y;
                this.dragPanel.Width = dragPicture.Top + e.Y;

                /*if (dragPanel.Bottom > dragPanel.Height)
                {
                    dragPanel.Height = editPictureBox.Height;
                    dragPanel.Width = editPictureBox.Height;
                }*/
            }
        }
    }
}
