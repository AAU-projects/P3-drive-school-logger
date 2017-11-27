using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;

namespace DriveLogGUI.Windows
{
    public partial class ConfirmLessonForm : Form
    {
        private List<Lesson> _lessonList = new List<Lesson>();
        private Point _lastClick;
        public ConfirmLessonForm(List<Lesson> lessons)
        {
            _lessonList = lessons;
            InitializeComponent();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            lessonTitleLabel.Text = "Title: " + _lessonList[0].LessonTemplate.Title;
            dateLabel.Text = "Date: " + _lessonList[0].EndDate;
            foreach (Lesson l in _lessonList)
            {
                attendingStudentsList.Items.Add("").SubItems.Add(DatabaseParser.GetUserById(l.StudentId).Fullname);
                attendingStudentsList.Items[attendingStudentsList.Items.Count - 1].Checked = true;
            }

        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Are you sure you want to complete the lesson with the following attendees?");
            text.AppendLine();
            text.AppendLine("Attended:");
            for (int i = 0; i < attendingStudentsList.Items.Count; i++)
            {
                if (attendingStudentsList.Items[i].Checked)
                    text.AppendLine(attendingStudentsList.Items[i].SubItems[1].Text);
            }
            text.AppendLine();
            text.AppendLine("Did Not Attend:");
            for (int i = 0; i < attendingStudentsList.Items.Count; i++)
            {
                if (!attendingStudentsList.Items[i].Checked)
                    text.AppendLine(attendingStudentsList.Items[i].SubItems[1].Text);
            }

            DialogResult result = CustomMsgBox.Show(text.ToString(), "Confirm Attendees", CustomMsgBoxIcon.Complete, 20 * attendingStudentsList.Items.Count);

            if (result == DialogResult.OK)
            {
                for (int i = 0; i < attendingStudentsList.Items.Count; i++)
                {
                    if (attendingStudentsList.Items[i].Checked)
                        DatabaseParser.SetLessonToComplete(_lessonList[i].StudentId, _lessonList[i].EndDate, true);
                    else
                        DatabaseParser.DeleteLesson(_lessonList[i].StudentId, _lessonList[i].EndDate);
                }
            }
        }
    }
}
