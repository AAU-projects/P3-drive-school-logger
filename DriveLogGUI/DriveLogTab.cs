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

        public DriveLogTab(User user)
        {
            InitializeComponent();
            driveLogHeaderLabel.Text = "Drive Log: " + user.Fullname;
            _user = user;

            for (int i = 0; i < 5; i++)
            {
                GenerateDriveLogPanel(i);
            }

            foreach (Panel panel in driveLogPanelList)
            {
                backPanel.Controls.Add(panel);
            }
        }

        private void GenerateDriveLogPanel(int idx)
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
            titleLabel.Size = new Size(labelWidth, labelHeight);
            titleLabel.Text = "Lesson title: ...";
            driveLogPanel.Controls.Add(titleLabel);

            Label dateCompletedLabel = new Label();
            dateCompletedLabel.Location = new Point(5, 5);
            dateCompletedLabel.Size = new Size(labelWidth, labelHeight);
            dateCompletedLabel.Text = "Date Completed: " + "N/A";
            driveLogPanel.Controls.Add(dateCompletedLabel);

            Label lessonNumberLabel = new Label();
            lessonNumberLabel.Location = new Point(5, 21);
            lessonNumberLabel.Size = new Size(labelWidth, labelHeight);
            lessonNumberLabel.Text = "Lesson Number: #/#";
            driveLogPanel.Controls.Add(lessonNumberLabel);

            Label lessonDescriptionLabel = new Label();
            lessonDescriptionLabel.Location = new Point(5, 37);
            lessonDescriptionLabel.MaximumSize = new Size(labelWidth, 0);
            lessonDescriptionLabel.AutoSize = true;
            lessonDescriptionLabel.Text ="Description:\n" + "Forberedelse til manøvre på køreteknisk anlæg. 9.1 Vejgreb og belæsning 9.2" +
            "Hastighed, centrifugalkraft, bremselængde og vejgrebets udnyttelse. 9.3 Hindringer på" +
            "vejen og slalom 9.4 Genvinde vejgreb efter udskridning 9.5 Bevare herredømmet efter" +
            "kørsel ud / ned over høj vejkant.";
            driveLogPanel.Controls.Add(lessonDescriptionLabel);

            Label instructorNameLabel = new Label();
            instructorNameLabel.Location = new Point(5, 53 + lessonDescriptionLabel.Height);
            instructorNameLabel.Size = new Size(labelWidth, labelHeight);
            instructorNameLabel.Text = "Instructor: Alecs Far";
            driveLogPanel.Controls.Add(instructorNameLabel);

            Label instructorSignLabel = new Label();
            instructorSignLabel.Location = new Point(backPanel.Width/3, instructorNameLabel.Location.Y + 16);
            instructorSignLabel.Size = new Size(labelWidth, labelHeight);
            instructorSignLabel.Text = "Instructor Signature: ";
            driveLogPanel.Controls.Add(instructorSignLabel);

            Label studentSignLabel = new Label();
            studentSignLabel.Location = new Point(backPanel.Width / 2, instructorNameLabel.Location.Y + 16);
            studentSignLabel.Size = new Size(labelWidth, labelHeight);
            studentSignLabel.Text = "Student Signature: ";
            driveLogPanel.Controls.Add(studentSignLabel);

            driveLogPanel.Size = new Size(backPanel.Width - 30,  studentSignLabel.Location.Y + studentSignLabel.Height + 5);
            driveLogPanelList.Add(driveLogPanel);
        }
    }
}
