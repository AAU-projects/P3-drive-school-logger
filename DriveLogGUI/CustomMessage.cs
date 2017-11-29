using System;
using System.Drawing;
using System.Windows.Forms;

namespace DriveLogGUI.Windows
{
    public static class CustomMsgBox
    {
        public static DialogResult ShowOk(string text, string caption, Image symbol)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.okButton.Show();
            MsgBox.okButton.TabIndex = 0;
            MsgBox.ShowDialog();

            return MsgBox.result; 
        }

        public static DialogResult ShowYesNo(string text, string caption, Image symbol)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.YesButton.Show();
            MsgBox.NoButton.Show();
            MsgBox.NoButton.TabIndex = 0;
            MsgBox.ShowDialog();

            return MsgBox.result;
        }

        public static DialogResult ShowConfirm(string text, string caption, Image symbol, int extraHeight)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.Size = new Size(MsgBox.Size.Width, MsgBox.Size.Height + extraHeight);
            MsgBox.textLabel.Visible = false;
            MsgBox.messageBox.Size = new Size(MsgBox.messageBox.Size.Width, MsgBox.messageBox.Size.Height + extraHeight);
            MsgBox.messageBox.Location = new Point(MsgBox.messageBox.Location.X, 40);
            MsgBox.messageBox.Text = text;
            MsgBox.messageBox.Visible = true;
            MsgBox.okButton.Text = "Confirm";
            MsgBox.okButton.Location = new Point(MsgBox.okButton.Location.X + 50, MsgBox.Size.Height - 30);
            MsgBox.okButton.Visible = true;
            MsgBox.button1.Location = new Point(MsgBox.button1.Location.X, MsgBox.Size.Height - 30);
            MsgBox.button2.Location = new Point(MsgBox.button2.Location.X, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Location = new Point(MsgBox.NoButton.Location.X - 110, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Text = "Cancel";
            MsgBox.NoButton.Visible = true;
            MsgBox.captionLabel.Text = caption;
            MsgBox.symbolpictureBox.Image = symbol;
            MsgBox.ShowDialog();

            return MsgBox.result;
        }
    }
}
