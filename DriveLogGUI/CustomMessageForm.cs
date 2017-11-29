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
    public partial class CustomMessageForm : Form
    {
        public DialogResult result = DialogResult.No;
        private Point _lastClick;

        public CustomMessageForm(string text, string caption, Image symbol)
        {
            InitializeComponent();

            textLabel.Text = text;
            captionLabel.Text = caption;
            symbolpictureBox.Image = symbol;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            this.Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            this.Close();
        }
    }
}
