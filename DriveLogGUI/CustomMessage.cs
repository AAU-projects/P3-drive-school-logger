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
    }
}
