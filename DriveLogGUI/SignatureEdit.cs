using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class SignatureEdit : Form
    {
        private Point _lastClick;
        private Bitmap _signatureImage = new Bitmap(540, 135);
        private bool _draw = false;
        private bool edited = false;
        public SignatureEdit()
        {
            InitializeComponent();
            signatureBox.Image = _signatureImage;
        }

        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void topBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void signatureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _draw = true;
            Graphics graphics = Graphics.FromImage(_signatureImage);
            Pen pen = new Pen(Color.Black, 4);
            graphics.DrawRectangle(pen, e.X, e.Y, 2f, 2f);
            graphics.Save();
            signatureBox.Image = _signatureImage;
        }

        private void signatureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _draw = false;
        }

        private void signatureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draw)
            {
                edited = true;
                Graphics graphics = Graphics.FromImage(_signatureImage);
                SolidBrush brush = new SolidBrush(Color.Black);
                graphics.FillRectangle(brush, e.X, e.Y, 2, 2);
                graphics.Save();
                signatureBox.Image = _signatureImage;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (edited)
            {
                
            }
            else
            {
                CustomMsgBox.Show("Please write your signature in the box", "Missing Signature",
                    CustomMsgBoxIcon.Error);
            }
        }
    }
}
