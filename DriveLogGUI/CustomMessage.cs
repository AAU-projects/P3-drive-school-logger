using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DriveLogCode.Objects;

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

        public static DialogResult ShowYesNo(string text, string caption, List<Lesson> cancelLessons, Image symbol)
        {
            int extraHeight = cancelLessons.Count * 20 + 60;
            int extraWidth = 200;
            StringBuilder lessons = new StringBuilder();

            lessons.AppendLine($"You will be canceling these {cancelLessons.Count} lessons below, do you want to proceed?");
            foreach (var lesson in cancelLessons)
            {
                lessons.AppendLine($"{lesson.StartDate.ToString("yy-MM-dd HH:mm")} - {lesson.EndDate.ToString("yy-MM-dd HH:mm")} lesson {lesson.TemplateID} / {lesson.Progress}");
            }

            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.Size = new Size(MsgBox.Size.Width + extraWidth, MsgBox.Size.Height + extraHeight);
            MsgBox.topBar.Size = new Size(MsgBox.topBar.Width + extraWidth, MsgBox.topBar.Height);
            MsgBox.closeButton.Location = new Point(MsgBox.closeButton.Location.X + extraWidth, MsgBox.closeButton.Height);

            MsgBox.textboxPanel.Size = new Size(MsgBox.textboxPanel.Size.Width + extraWidth, MsgBox.textboxPanel.Size.Height + extraHeight);
            MsgBox.textLabel.Size = new Size(MsgBox.textLabel.Size.Width+ extraWidth, MsgBox.textLabel.Size.Height + extraHeight);
            MsgBox.textLabel.Location = new Point(0, 0);

            MsgBox.textLabel.Text = lessons.ToString();

            MsgBox.YesButton.Location = new Point(MsgBox.Size.Width / 2 - MsgBox.YesButton.Width, MsgBox.Size.Height - 30);
            MsgBox.YesButton.Show();

            MsgBox.NoButton.Location = new Point(MsgBox.Size.Width / 2 + MsgBox.NoButton.Width, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Show();
            MsgBox.NoButton.TabIndex = 0;

            MsgBox.ShowDialog();

            return MsgBox.result;
        }

        public static DialogResult ShowConfirm(string text, string caption, Image symbol, int extraHeight)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.Size = new Size(MsgBox.Size.Width, MsgBox.Size.Height + extraHeight);
            MsgBox.textboxPanel.Size = new Size(MsgBox.textboxPanel.Size.Width, MsgBox.textboxPanel.Size.Height + extraHeight);
            MsgBox.textLabel.Size = new Size(MsgBox.textLabel.Size.Width, MsgBox.textLabel.Size.Height + extraHeight);
            MsgBox.textLabel.Location = new Point(0, 0);
            MsgBox.textLabel.Text = text;

            MsgBox.okButton.Text = "Confirm";
            MsgBox.okButton.Location = new Point(MsgBox.okButton.Location.X + 50, MsgBox.Size.Height - 30);
            MsgBox.okButton.Visible = true;

            MsgBox.NoButton.Location = new Point(MsgBox.NoButton.Location.X - 110, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Text = "Cancel";
            MsgBox.NoButton.Visible = true;

            MsgBox.symbolpictureBox.Image = symbol;
            MsgBox.ShowDialog();

            return MsgBox.result;
        }
    }
}
