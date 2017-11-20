using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class DriveLogTab : UserControl
    {
        private User _user;
        private List<Panel> driveLogPanelList = new List<Panel>();
        private List<LessonTemplate> templateslist = new List<LessonTemplate>();
        private List<Lesson> lessonslist = new List<Lesson>();

        public DriveLogTab(User user)
        {
            InitializeComponent();
            driveLogHeaderLabel.Text = "Drive Log: " + user.Fullname;
            _user = user;
            templateslist = DatabaseParser.GetTemplatesList();

            for (int i = 0; i < templateslist.Count; i++)
            {
                GenerateDriveLogPanel(i, templateslist[i]);
            }

            foreach (Panel panel in driveLogPanelList)
            {
                backPanel.Controls.Add(panel);
            }

            lessonslist = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(user.Id);
        }

        private void GenerateDriveLogPanel(int idx, LessonTemplate lesson)
        {
            int labelWidth = backPanel.Width - 30;
            int labelHeight = 14;

            Panel driveLogPanel = new Panel();
            driveLogPanel.BackColor = Color.White;
            driveLogPanel.BorderStyle = BorderStyle.FixedSingle;

            if (idx == 0)
                driveLogPanel.Location = new Point(6, 13);
            else
            {
                driveLogPanel.Location = new Point
                    (6, driveLogPanelList[idx - 1].Location.Y + driveLogPanelList[idx - 1].Height + 13);
            }

            Label titleLabel = new Label();
            titleLabel.Location = new Point(5, 5);
            titleLabel.Font = new Font("Myanmar Text", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Size = new Size(labelWidth, labelHeight + 10);
            titleLabel.Text = lesson.Title;
            driveLogPanel.Controls.Add(titleLabel);

            Label dateCompletedLabel = new Label();
            dateCompletedLabel.Location = new Point(5, 5);
            dateCompletedLabel.Size = new Size(labelWidth, labelHeight);
            dateCompletedLabel.Text = "Date Completed: " + "N/A";
            driveLogPanel.Controls.Add(dateCompletedLabel);

            Label lessonDescriptionLabel = new Label();
            lessonDescriptionLabel.Location = new Point(5, titleLabel.Height + 10);
            lessonDescriptionLabel.MaximumSize = new Size(labelWidth, 0);
            lessonDescriptionLabel.AutoSize = true;
            lessonDescriptionLabel.Text ="Description:\n" + lesson.Description;
            driveLogPanel.Controls.Add(lessonDescriptionLabel);

            Label instructorNameLabel = new Label();
            instructorNameLabel.Location = new Point(5, lessonDescriptionLabel.Location.Y + lessonDescriptionLabel.Height + 10);
            instructorNameLabel.Size = new Size(labelWidth, labelHeight);
            instructorNameLabel.Text = "Instructor:" + "";
            driveLogPanel.Controls.Add(instructorNameLabel);   

            Label instructorSignLabel = new Label();
            instructorSignLabel.Location = new Point(backPanel.Width / 4 + 50, instructorNameLabel.Location.Y + 16);
            instructorSignLabel.Size = new Size(140, labelHeight * 4);
            instructorSignLabel.Text = "\n\n____________________\n     Instructor Signature";
            driveLogPanel.Controls.Add(instructorSignLabel);

            Label studentSignLabel = new Label();
            studentSignLabel.Location = new Point(backPanel.Width / 2 + 50, instructorNameLabel.Location.Y + 16);
            studentSignLabel.Size = new Size(140, labelHeight * 4);
            studentSignLabel.Text = "\n\n____________________\n      Student Signature";
            driveLogPanel.Controls.Add(studentSignLabel);

            driveLogPanel.Size = new Size(backPanel.Width - 30,  studentSignLabel.Location.Y + studentSignLabel.Height + 5);
            driveLogPanelList.Add(driveLogPanel);
        }
    }
}
