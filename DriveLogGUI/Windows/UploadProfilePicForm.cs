using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DriveLogCode.DesignSchemes;

namespace DriveLogGUI.Windows
{
    public partial class UploadProfilePicForm : Form
    {
        // Used to get the point, from where the user starts moving the dragPanel.
        // This is used to calculate the correct position, by subtracting the start values from the movement of the mouse pointer.
        private int startX;
        private int startY;

        // Used to indicated when then user is trying to resize the dragPanel.
        private bool allowResize = false;

        private static Form _registerForm;

        private static readonly List<string> AcceptedImageExtensions = new List<string> { ".jpg", ".png", ".bmp", ".jpeg" };

        /// <summary>
        /// Initializes the Form, and hides the crop panels. Also sets AllowDrop to true, to enable drag-and-drop functionality in this form.
        /// </summary>
        /// <param name="registerForm">A reference to the previous form, to use when returning.</param>
        public UploadProfilePicForm(Form registerForm)
        {
            _registerForm = registerForm;
            InitializeComponent();

            editPictureBox.Controls.Add(dragPanel);
            editPictureBox.Controls.Add(overlayPanel);

            dragPicture.Visible = false;
            dragPanel.Visible = false;
            overlayPanel.Visible = false;

            // Enables the use of drag and drop within this form.
            this.AllowDrop = true;

            // Sets the color of the crop overlay.
            overlayPanel.BackColor = Color.FromArgb(75, 0, 0, 0);
        }

        /// <summary>
        /// Disposes of the UploadProfilePicForm and shows the RegisterForm
        /// </summary>
        /// <param name="sender">The button pressed</param>
        /// <param name="e">EventArgs</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _registerForm.Show();
        }

        /// <summary>
        /// An Event for when a file is dragged into the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains the DragEvent data</param>
        private void UploadProfilePicForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// An Event for when the file is dropped on the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains the DragEvent data</param>
        private void UploadProfilePicForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            // If multiple files have been dragged, no picture will be loaded. 
            if (files.Length == 1 && ValidateDroppedFile(files[0]))
                PictureLoaded(Image.FromFile(files[0]));
        }

        /// <summary>
        /// Loads the desired image into the PictureBox.
        /// </summary>
        /// <param name="loadedImage">Image to load</param>
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

            // Set position of remaining panels, based on the position of the picturebox.
            SetDragPanelPosition();
            SetOverlayPanelPosition();

            dragPicture.Visible = true;
            dragPanel.Visible = true;
            overlayPanel.Visible = true;
        }

        /// <summary>
        /// Resizes the image to fit within the boundaries of the editPictureBox, without changing the aspect ratio of the image.
        /// </summary>
        /// <param name="image">The image to resize</param>
        /// <returns>A resized image</returns>
        private Image CheckImageSize(Image image)
        {
            Image imageToCheck = image;
            decimal scale;

            // Finds the scale that will allow us to resize the image, so both sides are within the boundaries, while keeping the aspect ratio.
            if (editPictureBox.Width / image.Width < editPictureBox.Height / image.Height)
                scale = Convert.ToDecimal(editPictureBox.Width) / Convert.ToDecimal(image.Width);
            else
                scale = Convert.ToDecimal(editPictureBox.Height) / Convert.ToDecimal(image.Height);

            decimal newWidth = Convert.ToDecimal(image.Width) * scale;
            decimal newHeight = Convert.ToDecimal(image.Height) * scale;

            imageToCheck = ResizeImage(imageToCheck, (int) newWidth, (int) newHeight);

            return imageToCheck;
        }

        /// <summary>
        /// Handles the actual resizing of the image.
        /// </summary>
        /// <param name="Image">The image to resize</param>
        /// <param name="Width">The desired width of the image</param>
        /// <param name="Height">The desired height of the image</param>
        /// <returns>A resized image</returns>
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

        /// <summary>
        /// Crops an image using the position and size of the dragPanel
        /// </summary>
        /// <param name="Image">The image to crop</param>
        /// <returns>The cropped image</returns>
        private Image CropImage(Image Image)
        {
            Bitmap croppedImage = new Bitmap(Image);

            // Clones the part of the image that is within the boundaries of the dragPanel.
            return croppedImage.Clone(new Rectangle(dragPanel.Location.X, dragPanel.Location.Y, dragPanel.Width, dragPanel.Height), croppedImage.PixelFormat);
        }

        /// <summary>
        /// Resets the PictureBox size and location.
        /// </summary>
        private void ResetPictureBox()
        {
            this.editPictureBox.Location = new Point(12, 105);
            this.editPictureBox.Size = new Size(671, 338);
        }

        /// <summary>
        /// Sets the position fof the dragPanel.
        /// </summary>
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
            // Since left and top is the distance relative to the parent, setting it to 0 "resets" the control and puts it in the top left corner.
            dragPanel.Left = 0;
            dragPanel.Top = 0;
        }

        /// <summary>
        /// Sets the position of the overlayPanel
        /// </summary>
        private void SetOverlayPanelPosition()
        {
            overlayPanel.Width = editPictureBox.Width;
            overlayPanel.Height = editPictureBox.Height;
            overlayPanel.Left = 0;
            overlayPanel.Top = 0;
        }

        /// <summary>
        /// Checks if the dropped files are of the allowed filetype
        /// </summary>
        /// <param name="filepath">The path to the file</param>
        /// <returns>A boolean indicating if the file is allowed or not</returns>
        private bool ValidateDroppedFile(string filepath)
        {
            if (AcceptedImageExtensions.Contains(Path.GetExtension(filepath).ToLower())) return true;
            return false;
        }

        /// <summary>
        /// The Event for when the user clicks the accept button. If an image has been loaded, it will return to the registerform, and the new profilepicture is displayed
        /// </summary>
        /// <param name="sender">The accept button</param>
        /// <param name="e">The EventArgs</param>
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

        /// <summary>
        /// The Event for when the user clicks the browse button. This will open a file dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Title = "Select Image";
                fileDialog.Filter = $"Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                    PictureLoaded(new Bitmap(fileDialog.FileName));
            }
        }

        /// <summary>
        /// The Event for when the user stops holding down the mouse, while dragging the dragPicture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPicture_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
        }

        /// <summary>
        /// The Event for when the user starts holding down the mouse, while dragging the dragPicture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPicture_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
        }

        /// <summary>
        /// The Event for when the mouse is moving, while hovering above the dragPicture.
        /// This will move the panel, if allowResize is set to true. 
        /// This is used when trying to resize the crop box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                int newSize;
                // Check the height.
                if (dragPanel.Height + dragPanel.Top > editPictureBox.Height)
                {
                    allowResize = false;
                    newSize = dragPanel.Height - (dragPanel.Height - editPictureBox.Height);
                } // Check the Width,
                else if (dragPanel.Width + dragPanel.Left > editPictureBox.Width)
                {
                    allowResize = false;
                    newSize = dragPanel.Height - (dragPanel.Height - editPictureBox.Width);
                } // Check if the larger panel becomes smaller than the cornerpanel.
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

        /// <summary>
        /// Used to check a value against a min and max value.
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        /// <returns>Returns an int. Can either be the value itself, the min, or the max</returns>
        private int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        /// <summary>
        /// The Event for when the mouse is hovering above the dragPanel
        /// Used to move the dragpanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (allowResize)
            {
                Point newLocation;
                // Set the min and max values.
                int minX = 0;
                int maxX = editPictureBox.Width - dragPanel.Width;
                int minY = 0;
                int maxY = editPictureBox.Height - dragPanel.Height;

                // Uses the Clamp function to check if the new position is outside the boundaries.
                int clampX = Clamp(e.X + this.dragPanel.Left - startX, minX, maxX);
                int clampY = Clamp(e.Y + this.dragPanel.Top - startY, minY, maxY);
                newLocation = new Point(clampX,clampY);

                // Sets the new location.
                this.dragPanel.Location = newLocation;
            }
        }

        /// <summary>
        /// The Event for when the user starts holding down the mouse, while dragging the dragPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPanel_MouseDown(object sender, MouseEventArgs e)
        {
            allowResize = true;
            startX = e.X;
            startY = e.Y;
        }

        /// <summary>
        /// The Event for when the user stops holding down the mouse, while dragging the dragPanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dragPanel_MouseUp(object sender, MouseEventArgs e)
        {
            allowResize = false;
        }
    }
}
