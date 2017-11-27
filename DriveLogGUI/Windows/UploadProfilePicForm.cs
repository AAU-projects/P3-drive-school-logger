using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using DriveLogCode.DesignSchemes;

namespace DriveLogGUI.Windows
{
    public partial class UploadProfilePicForm : Form
    {
        private int startX;
        private int startY;


        public UploadProfilePicForm(Form registerForm)
        {
            _registerForm = registerForm;
            InitializeComponent();
            editPictureBox.Controls.Add(dragPanel);
            editPictureBox.Controls.Add(overlayPanel);
            dragPicture.Visible = false;
            dragPanel.Visible = false;
            overlayPanel.Visible = false;
            this.AllowDrop = true;
            overlayPanel.BackColor = Color.FromArgb(75, 0, 0, 0);
            //this.ResizeRedraw = true;
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
                PictureLoaded(Image.FromFile(files[0]));
        }

        private void PictureLoaded(Image loadedImage)
        {
            dragAndDropLabel.Visible = false;
            dragAndDropPictureBox.Visible = false;

            // Resets the picturebox location and resizes the image.
            ResetPictureBox();
            Image userImage = loadedImage;
            userImage = CheckImageSize(userImage);

            // Sets position, width, and height for picturebox.
            editPictureBox.Width = userImage.Width;
            editPictureBox.Height = userImage.Height;
            editPictureBox.Left = this.Width / 2 - userImage.Width / 2;
            editPictureBox.Image = userImage;
            editPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            SetDragPanelPosition();
            SetOverlayPanelPosition();
            dragPicture.Visible = true;
            dragPanel.Visible = true;
            overlayPanel.Visible = true;
        }

        private Image CheckImageSize(Image image)
        {
            Image imageToCheck = image;
            decimal scale;

            if (editPictureBox.Width / image.Width < editPictureBox.Height / image.Height)
                scale = Convert.ToDecimal(editPictureBox.Width) / Convert.ToDecimal(image.Width);

            else
                scale = Convert.ToDecimal(editPictureBox.Height) / Convert.ToDecimal(image.Height);

            decimal newWidth = Convert.ToDecimal(image.Width) * scale;
            decimal newHeight = Convert.ToDecimal(image.Height) * scale;

            imageToCheck = ResizeImage(imageToCheck, (int) newWidth, (int) newHeight);

            return imageToCheck;
        }
        private Bitmap ResizeImage(Image Image, int Width, int Height)
        {
            var resizedImageRectangle = new Rectangle(0, 0, Width, Height);
            var resizedImage = new Bitmap(Width, Height);

            // Maintains image DPI.
            resizedImage.SetResolution(Image.HorizontalResolution, Image.VerticalResolution);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                // Quality settings.
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(Image, resizedImageRectangle, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedImage;
        }

        private Image CropImage(Image Image)
        {
            Bitmap croppedImage = new Bitmap(Image);
            return croppedImage.Clone(new Rectangle(dragPanel.Location.X, dragPanel.Location.Y, dragPanel.Width, dragPanel.Height), croppedImage.PixelFormat);
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
        private void SetOverlayPanelPosition()
        {
            overlayPanel.Width = editPictureBox.Width;
            overlayPanel.Height = editPictureBox.Height;
            overlayPanel.Left = 0;
            overlayPanel.Top = 0;
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

                tempregisterForm.ProfileImage = CropImage(editPictureBox.Image);
            }
            else if (_registerForm is EditUserInfoForm)
            {
                EditUserInfoForm tempregisterForm = _registerForm as EditUserInfoForm;

                tempregisterForm.ProfilePicture = CropImage(editPictureBox.Image);
            }
            this.Dispose();
            _registerForm.Show();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select Image";
                fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    PictureLoaded(new Bitmap(fileDialog.FileName));
            }
        }

        private bool allowResize = false;
        private void dragPicture_MouseUp(object sender, MouseEventArgs e)
        {
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
                int newSize;
                if (dragPanel.Height + dragPanel.Top > editPictureBox.Height)
                {
                    allowResize = false;
                    newSize = dragPanel.Height - (dragPanel.Height - editPictureBox.Height);
                }
                else if (dragPanel.Width + dragPanel.Left > editPictureBox.Width)
                {
                    allowResize = false;
                    newSize = dragPanel.Height - (dragPanel.Height - editPictureBox.Width);
                }
                else if (dragPanel.Width < dragPicture.Width)
                {
                    allowResize = false;
                    newSize = dragPicture.Width + 20;
                }
                else
                    newSize = dragPicture.Top + e.Y;

                this.dragPanel.Height = newSize;
                this.dragPanel.Width = newSize;
            }
        }

        private void dragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                Point newLocation;

                // Checks the left side.
                if (this.dragPanel.Left + e.X - startX <= 0)
                {
                    allowResize = false;
                    newLocation = new Point(this.dragPanel.Location.X, this.dragPanel.Location.Y);
                } // Checks the right side.
                else if (this.dragPanel.Left + this.dragPanel.Width + e.X - startX >= editPictureBox.Width)
                {
                    allowResize = false;
                    newLocation = new Point(this.dragPanel.Location.X, this.dragPanel.Location.Y);
                } // Checks the top.
                else if (this.dragPanel.Top + e.Y - startY < 0)
                {
                    allowResize = false;
                    newLocation = new Point(this.dragPanel.Location.X, this.dragPanel.Location.Y);
                } // Checks the bottom.
                else if (this.dragPanel.Top + this.dragPanel.Height + e.Y - startY >= editPictureBox.Height)
                {
                    allowResize = false;
                    newLocation = new Point(this.dragPanel.Location.X, this.dragPanel.Location.Y);
                }// Sets the new location if none of the above was true. 
                else
                newLocation = new Point(e.X + this.dragPanel.Left - startX, e.Y + this.dragPanel.Top - startY);

                this.dragPanel.Location = newLocation;

            }
        }

        private void dragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
            startX = e.X;
            startY = e.Y;
        }

        private void dragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
        }
    }
}
