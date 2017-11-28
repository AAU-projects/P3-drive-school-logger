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

        public static DialogResult Show(string text, string caption, Image symbol, int extraHeight)
        {
            MsgBox = new CustomMsgBox();
            MsgBox.Size = new Size(MsgBox.Size.Width, MsgBox.Size.Height + extraHeight);
            MsgBox.textLabel.Visible = false;
            MsgBox.messageBox.Size = new Size(MsgBox.messageBox.Size.Width, MsgBox.messageBox.Size.Height + extraHeight);
            MsgBox.messageBox.Location = new Point(MsgBox.messageBox.Location.X, 40);
            MsgBox.messageBox.Text = text;
            MsgBox.messageBox.Visible = true;
            MsgBox.okButton.Text = "Confirm";
            MsgBox.okButton.Location = new Point(MsgBox.okButton.Location.X + 50, MsgBox.Size.Height - 30);
            MsgBox.button1.Location = new Point(MsgBox.button1.Location.X, MsgBox.Size.Height - 30);
            MsgBox.button2.Location = new Point(MsgBox.button2.Location.X, MsgBox.Size.Height - 30);
            MsgBox.cancelButton.Location = new Point(MsgBox.cancelButton.Location.X - 110, MsgBox.Size.Height - 30);
            MsgBox.cancelButton.Visible = true;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
