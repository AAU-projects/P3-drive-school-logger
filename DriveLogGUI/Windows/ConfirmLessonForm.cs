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

        /// <summary>
        /// Class constructor. Initializes component and information
        /// </summary>
        /// <param name="lessons">A list of lessons to complete</param>
        public ConfirmLessonForm(List<Lesson> lessons)
        {
            _lessonList = lessons;
            InitializeComponent();
            UpdateInfo();
        }

        /// <summary>
        /// Updates information and adds the info to the listview
        /// </summary>
        private void UpdateInfo()
        {
            lessonTitleLabel.Text = "Lesson Type: " + _lessonList[0].LessonTemplate.Type;
            dateLabel.Text = $"Date: {_lessonList[0].StartDate} to {_lessonList[0].EndDate}";
            foreach (Lesson l in _lessonList)
            {
                string[] subitems = {DatabaseParser.GetUserById(l.StudentId).Fullname, l.LessonTemplate.Title};
                attendingStudentsList.Items.Add("").SubItems.AddRange(subitems);
                attendingStudentsList.Items[attendingStudentsList.Items.Count - 1].Checked = true;
            }

        }

        /// <summary>
        /// Saves the location of the last click
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The MouseEventArgs</param>
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The MouseEventArgs</param>
        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        /// <summary>
        /// Disposes of the form if close button is clicked
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Completes or denies lessons and closes the form
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Are you sure you want to complete the lesson with the following attendees?");
            text.AppendLine();
            text.AppendLine("Attended:");
            // Lists All the students who attended the lesson
            for (int i = 0; i < attendingStudentsList.Items.Count; i++)
            {
                if (attendingStudentsList.Items[i].Checked)
                    text.AppendLine(attendingStudentsList.Items[i].SubItems[1].Text);
            }
            text.AppendLine();
            text.AppendLine("Did Not Attend:");
            // Lists All the students who did not attend the lesson
            for (int i = 0; i < attendingStudentsList.Items.Count; i++)
            {
                if (!attendingStudentsList.Items[i].Checked)
                    text.AppendLine(attendingStudentsList.Items[i].SubItems[1].Text);
            }

            // Show the dialog and save result
            DialogResult result = CustomMsgBox.ShowConfirm(text.ToString(), "Confirm Attendees", CustomMsgBoxIcon.Complete, 20 * attendingStudentsList.Items.Count + 80);

            if (result == DialogResult.OK)
            {
                for (int i = 0; i < attendingStudentsList.Items.Count; i++)
                {
                    // If row is checked then complete lesson else deny lesson
                    if (attendingStudentsList.Items[i].Checked)
                        DatabaseParser.SetLessonToStatus(_lessonList[i].StudentId, _lessonList[i].AppointmentID,
                            _lessonList[i].Progress, true);
                    else
                    {
                        List<Lesson> deleteList = DatabaseParser.CancelLesson(_lessonList[i].TemplateID,
                            _lessonList[i].Progress, _lessonList[i].StudentId);
                        DatabaseParser.DeleteLessons(deleteList);
                    }
                }
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
