using System;
using System.Drawing;
using System.Windows.Forms;

namespace DriveLogGUI.Windows
{
    public partial class CustomMsgBox : Form
    {
        static CustomMsgBox MsgBox;
        static DialogResult result = DialogResult.No;
        private Point _lastClick;

        public CustomMsgBox()
        {
            InitializeComponent();
        }



        public static DialogResult Show(string text, string caption, Image symbol)
        {
            MsgBox = new CustomMsgBox();
            MsgBox.textLabel.Text = text;
            MsgBox.captionLabel.Text = caption;
            MsgBox.symbolpictureBox.Image = symbol;
            MsgBox.ShowDialog();

            return result;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            MsgBox.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MsgBox.Close();
        }

        private void topBar_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void topBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }
    }
}
