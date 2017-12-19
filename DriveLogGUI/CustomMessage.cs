using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using DriveLogCode.Objects;

namespace DriveLogGUI.Windows
{
    public static class CustomMsgBox
    {
        /// <summary>
        /// Show a custom message box with a Ok Button
        /// </summary>
        /// <param name="text">Text that is displayed</param>
        /// <param name="caption">Text that is shown in the title</param>
        /// <param name="symbol">Symbol shown next to text</param>
        /// <returns>Returns the results which is the button the user clicked on</returns>
        public static DialogResult ShowOk(string text, string caption, Image symbol)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.okButton.Show();
            MsgBox.okButton.TabIndex = 0;
            MsgBox.ShowDialog();

            return MsgBox.result; 
        }

        /// <summary>
        /// Show a custom message box with a Yes and No Button
        /// </summary>
        /// <param name="text">Text that is displayed</param>
        /// <param name="caption">Text that is shown in the title</param>
        /// <param name="symbol">Symbol shown next to text</param>
        /// <returns>Returns the results which is the button the user clicked on</returns>
        public static DialogResult ShowYesNo(string text, string caption, Image symbol)
        {
            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.YesButton.Show();
            MsgBox.NoButton.Show();
            MsgBox.NoButton.TabIndex = 0;
            MsgBox.ShowDialog();

            return MsgBox.result;
        }

        /// <summary>
        /// Show a custom message box with a Yes and No Button with a custom size out from the cancel lessons
        /// </summary>
        /// <param name="text">Text that is displayed</param>
        /// <param name="caption">Text that is shown in the title</param>
        /// <param name="cancelLessons">All the lessons that have to be displayed</param>
        /// <param name="symbol">Symbol shown next to text</param>
        /// <returns>Returns the results which is the button the user clicked on</returns>
        public static DialogResult ShowYesNo(string text, string caption, List<Lesson> cancelLessons, Image symbol)
        {
            int extraHeight = cancelLessons.Count * 20 + 80;
            int extraWidth = 150;
            StringBuilder lessons = new StringBuilder();

            lessons.AppendLine($"Canceling this lesson will result in the \ncancelation of all other lessons after this date,\nas this lesson is a requirement for furture lessons.\n");
            lessons.AppendLine($"You will be canceling these {cancelLessons.Count} lessons below:\n");
            foreach (var lesson in cancelLessons)
            {
                lessons.AppendLine($"Date: {lesson.StartDate:dd/MM}    {lesson.StartDate:t} - {lesson.EndDate:t}    {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lesson.LessonTemplate.Title.ToLower())}");
            }

            lessons.AppendLine($"\nDo you want to proceed?");

            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.Size = new Size(MsgBox.Size.Width + extraWidth, MsgBox.Size.Height + extraHeight);
            MsgBox.topBar.Size = new Size(MsgBox.topBar.Width + extraWidth, MsgBox.topBar.Height);
            MsgBox.closeButton.Location = new Point(MsgBox.closeButton.Location.X+ extraWidth, MsgBox.closeButton.Location.Y);

            MsgBox.textboxPanel.Size = new Size(MsgBox.textboxPanel.Size.Width + extraWidth, MsgBox.textboxPanel.Size.Height + extraHeight);
            MsgBox.textLabel.Size = new Size(MsgBox.textLabel.Size.Width+ extraWidth, MsgBox.textLabel.Size.Height + extraHeight);


            MsgBox.textLabel.Text = lessons.ToString();
            MsgBox.textLabel.Location = new Point(0, 0);

            MsgBox.YesButton.Location = new Point(MsgBox.Size.Width / 2 - (MsgBox.YesButton.Width + 10), MsgBox.Size.Height - 30);
            MsgBox.YesButton.Show();

            MsgBox.NoButton.Location = new Point(MsgBox.Size.Width / 2 + 10, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Show();
            MsgBox.NoButton.TabIndex = 0;

            MsgBox.ShowDialog();

            return MsgBox.result;
        }

        /// <summary>
        /// Show a custom message box with a Yes and No Button with a custom size out from the cancel lessons with a text to a instructor
        /// </summary>
        /// <param name="text">Text that is displayed</param>
        /// <param name="caption">Text that is shown in the title</param>
        /// <param name="cancelLessons">All the lessons that have to be displayed</param>
        /// <param name="symbol">Symbol shown next to text</param>
        /// <returns>Returns the results which is the button the user clicked on</returns>
        public static DialogResult ShowYesNoInstructor(string text, string caption, List<Lesson> cancelLessons, Image symbol)
        {
            int extraHeight = cancelLessons.Count * 20 + 90;
            int extraWidth = 150;
            StringBuilder lessons = new StringBuilder();

            lessons.AppendLine($"Canceling this lesson will result in the cancelation\n of all other lessons for students this date,\nas this lesson is a requirement for furture lessons.\n");
            lessons.AppendLine($"You will be canceling these {cancelLessons.Count} lessons below:\n");
            foreach (var lesson in cancelLessons) {
                lessons.AppendLine($"Date: {lesson.StartDate:dd/MM}    {lesson.StartDate:t} - {lesson.EndDate:t}    {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lesson.LessonTemplate.Title.ToLower())}");
            }

            lessons.AppendLine($"\nDo you want to proceed?");

            CustomMessageForm MsgBox = new CustomMessageForm(text, caption, symbol);
            MsgBox.Size = new Size(MsgBox.Size.Width + extraWidth, MsgBox.Size.Height + extraHeight);
            MsgBox.topBar.Size = new Size(MsgBox.topBar.Width + extraWidth, MsgBox.topBar.Height);
            MsgBox.closeButton.Location = new Point(MsgBox.closeButton.Location.X + extraWidth, MsgBox.closeButton.Location.Y);

            MsgBox.textboxPanel.Size = new Size(MsgBox.textboxPanel.Size.Width + extraWidth, MsgBox.textboxPanel.Size.Height + extraHeight);
            MsgBox.textLabel.Size = new Size(MsgBox.textLabel.Size.Width + extraWidth, MsgBox.textLabel.Size.Height + extraHeight);


            MsgBox.textLabel.Text = lessons.ToString();
            MsgBox.textLabel.Location = new Point(0, 0);

            MsgBox.YesButton.Location = new Point(MsgBox.Size.Width / 2 - (MsgBox.YesButton.Width + 10), MsgBox.Size.Height - 30);
            MsgBox.YesButton.Show();

            MsgBox.NoButton.Location = new Point(MsgBox.Size.Width / 2 + 10, MsgBox.Size.Height - 30);
            MsgBox.NoButton.Show();
            MsgBox.NoButton.TabIndex = 0;

            MsgBox.ShowDialog();

            return MsgBox.result;
        }

        /// <summary>
        /// Show a custom message box with a Confirm Button with a custom size
        /// </summary>
        /// <param name="text">Text that is displayed</param>
        /// <param name="caption">Text that is shown in the title</param>
        /// <param name="symbol">Symbol shown next to text</param>
        /// <param name="extraHeight">The extra height in the custom message box</param>
        /// <returns>Returns the results which is the button the user clicked on</returns>
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
