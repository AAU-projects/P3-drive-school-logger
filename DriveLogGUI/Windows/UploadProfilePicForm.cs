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
                SetOverlayPanelPosition();
                dragPicture.Visible = true;
                dragPanel.Visible = true;
                overlayPanel.Visible = true;
            }
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
                int nx;
                if (dragPanel.Height + dragPanel.Top > editPictureBox.Height)
                {
                    allowResize = false;
                    nx = dragPanel.Height - (dragPanel.Height - editPictureBox.Height);
                }
                else if (dragPanel.Width + dragPanel.Left > editPictureBox.Width)
                {
                    allowResize = false;
                    nx = dragPanel.Height - (dragPanel.Height - editPictureBox.Width);
                }
                else if (dragPanel.Width < dragPicture.Width)
                {
                    allowResize = false;
                    nx = dragPicture.Width + 20;
                }
                else
                    nx = dragPicture.Top + e.Y;

                this.dragPanel.Height = nx;
                this.dragPanel.Width = nx;

                /*int nx;
                if (dragPanel.Width + dragPanel.Left <= editPictureBox.Width)
                {
                    nx = dragPicture.Top + e.Y;
                    //this.dragPanel.Height = dragPicture.Top + e.Y;
                    //this.dragPanel.Width = dragPicture.Top + e.Y;
                }
                else if (dragPanel.Height + dragPanel.Top <= editPictureBox.Height)
                {
                    allowResize = false;
                    nx = dragPanel.Height - (dragPanel.Height - editPictureBox.Height);
                }
                else
                {
                    allowResize = false;
                    nx = dragPanel.Height - (dragPanel.Height - editPictureBox.Width);
                    //this.dragPanel.Height = dragPanel.Height - (dragPanel.Height - dragPicture.Width);
                    //this.dragPanel.Width = dragPanel.Height - (dragPanel.Height - dragPicture.Width);
                }
                this.dragPanel.Height = nx;
                this.dragPanel.Width = nx;*/
            }
        }

        private readonly SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 255));
        private void dragPanel_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics panelGraphics = e.Graphics;
            GraphicsPath graphicsPath = new GraphicsPath();
            /*Region graphicRegion = new Region(new Rectangle(editPictureBox.Location.X, editPictureBox.Location.Y, editPictureBox.Width, editPictureBox.Height));
            graphicsPath.AddRectangle(new Rectangle(dragPanel.Location.X, dragPanel.Location.Y, dragPanel.Width, dragPanel.Height));#1#

            Region graphicRegion = new Region(new Rectangle(0, 0, editPictureBox.Width, editPictureBox.Height));
            graphicsPath.AddRectangle(new Rectangle(0, 0, dragPanel.Width, dragPanel.Height));

            //graphicsPath.AddRectangle(new Rectangle(editPictureBox.Location.X, editPictureBox.Location.Y, editPictureBox.Width, editPictureBox.Height));
            graphicRegion.Exclude(graphicsPath);
            panelGraphics.FillRegion(semiTransBrush, graphicRegion);
            
            base.OnPaint(e);*/
        }
    }
}
