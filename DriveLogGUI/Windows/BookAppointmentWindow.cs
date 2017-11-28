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
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;

namespace DriveLogGUI.Windows
{
    public partial class BookAppointmentWindow : Form
    {
        private Point _lastClick;
        private Point _openWindowPosition;
        private readonly Appointment _appointment;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private Lesson curentLesson;
        private bool addedFirstLesson;


        public BookAppointmentWindow(Appointment appointment, Point mousePosition)
        {
            InitializeComponent();

            this._openWindowPosition = mousePosition;
            this._appointment = appointment;
            this.startDateTime = appointment.StartTime;
            this.endDateTime = appointment.ToTime;
            CheckForFirstLessons();
            curentLesson = Session.GetLastLessonFromType(_appointment.LessonType);

            SetWindowPosition();
            UpdateData();

            FillTimeComboBox(StartTimecomboBox);
            FillComboBox(lessonsComboBox, 4);
        }

        private void CheckForFirstLessons()
        {
            // if a user does not already have a lesson in lessontype a temp lesson is created before first lesson is added to database
            if (Session.LastTheoraticalLesson == null && _appointment.LessonType == LessonTypes.Theoretical) {
                Session.LastTheoraticalLesson = new Lesson(_appointment.InstructorName, "", _appointment.Id, 1, 0, _appointment.StartTime, _appointment.StartTime.AddMinutes(45), true, null, null);
                Session.LastTheoraticalLesson.LessonTemplate = DatabaseParser.GetLessonTemplateFromID(Session.LastTheoraticalLesson.TemplateID);
                addedFirstLesson = true;
            }

            if (Session.LastPracticalLesson == null && _appointment.LessonType == LessonTypes.Practical) {
                Session.LastPracticalLesson = new Lesson(_appointment.InstructorName, "", _appointment.Id, 4, 0, _appointment.StartTime, _appointment.StartTime.AddMinutes(45), true, null, null);
                Session.LastPracticalLesson.LessonTemplate = DatabaseParser.GetLessonTemplateFromID(Session.LastPracticalLesson.TemplateID);
                addedFirstLesson = true;
            }
        }

        private void FillTimeComboBox(ComboBox comboBox)
        {
            DateTime time = new DateTime();
            time = time.AddHours(_appointment.StartTime.Hour);
            int timeSpan15= (int) ((_appointment.ToTime.TimeOfDay.TotalMinutes - _appointment.StartTime.TimeOfDay.TotalMinutes) / 15);

            for (int i = 0; i < timeSpan15 - 2; i++) {
                comboBox.Items.Add(time.ToString("HH:mm"));
                time = time.AddMinutes(15);
            }
        }

        private void FillComboBox(ComboBox comboBox, int lessons)
        {
            int maxLessonsToBook = curentLesson.LessonTemplate.Time - Session.GetLastLessonFromType(_appointment.LessonType).Progress;

            if (maxLessonsToBook == 0) // when users have completed a different lesson type and the next lesson type have to start
            {
                curentLesson.LessonTemplate = DatabaseParser.GetNextLessonTemplateFromID(curentLesson.LessonTemplate.Id, _appointment.LessonType);
                curentLesson.Progress = 0;
                curentLesson.TemplateID = curentLesson.LessonTemplate.Id;
                maxLessonsToBook = curentLesson.LessonTemplate.Time;
            }

            if (curentLesson.LessonTemplate.Type != DatabaseParser.GetLessonTemplateFromID(curentLesson.LessonTemplate.Id + 1).Type)
            {
                lessons = maxLessonsToBook < lessons ? maxLessonsToBook : lessons; // always make sure that the you can only book the required lessons to complete a lesson type
            }
            else
            {
                lessons = 4 < lessons ? 4 : lessons; // if type is diferent 
            }

            lessonsComboBox.Items.Clear();
            for (int i = 0; i < lessons; i++) {
                comboBox.Items.Add(i + 1);
            }
        }

        private void SetComboBoxTimeDifference()
        {
            if (StartTimecomboBox.Text != String.Empty & lessonsComboBox.Text != String.Empty) {
                startDateTime = DateTime.Parse(StartTimecomboBox.Text);
                endDateTime = startDateTime.AddMinutes(45 * (int)lessonsComboBox.SelectedItem);

                TimeSpan timeDifference = endDateTime - startDateTime;

                if (timeDifference.Hours <= 0)
                    timeDifferenceLabel.Text = $"{timeDifference.Minutes} minutes";
                else
                    timeDifferenceLabel.Text = $"{timeDifference.Hours} hours {timeDifference.Minutes} minutes";
            }
        }

        private void UpdateData()
        {
            TitleDateLabel.Text = $"Book appointment at {_appointment.DateShortFormat()}";
            TitleTimeLabel.Text = $"{_appointment.FromTimeToTime()}";
            instructorLabel.Text = $"{_appointment.InstructorName}";
            lessonTypeLabel.Text = $"{_appointment.LessonType}";
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SetWindowPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(_openWindowPosition.X - this.Width, _openWindowPosition.Y - this.Height);
        }

        private void StartTimecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lessonsComboBox.Text = String.Empty;

            SetComboBoxTimeDifference();
            TimeSpan span = _appointment.ToTime.TimeOfDay - DateTime.Parse(StartTimecomboBox.Text).TimeOfDay;
            int avaiableTime = (int) span.TotalMinutes / 45;
            FillComboBox(lessonsComboBox, avaiableTime);
            lessonsComboBox.SelectedItem = lessonsComboBox.Items.Count;
        }

        private void lessonsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboBoxTimeDifference();
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(lessonsComboBox.Text) && !String.IsNullOrWhiteSpace(StartTimecomboBox.Text))
            {

                bool result = AddLesson();

                if (result)
                {
                    CustomMsgBox.Show("Successfully booked!", "Sucess", CustomMsgBoxIcon.Complete);
                    _appointment.AppointmentBooked();
                    this.Dispose();
                    Session.GetProgress();
                }
                else
                {
                    CustomMsgBox.Show("Error connecting to database", "Failure", CustomMsgBoxIcon.Error);
                }
            }
            else
            {
                    CustomMsgBox.Show("Please select a timeperiod you wish to book your appointment", "Warning", CustomMsgBoxIcon.Warrning);
            }
        }

        private bool AddLesson()
        {
            int numberOfLessons = lessonsComboBox.SelectedIndex + 1;
            bool result = true;

            if (addedFirstLesson)
            {
                numberOfLessons -= 1;

                Lesson firstLesson = Session.GetLastLessonFromType(_appointment.LessonType);
                firstLesson.Progress = 1;
                result = DatabaseParser.AddLessonToUserID(
                    Session.LoggedInUser.Id, 
                    _appointment.Id,
                    firstLesson.TemplateID,
                    firstLesson.Progress, 
                    startDateTime, 
                    startDateTime = startDateTime.AddMinutes(45), 
                    true);

                curentLesson.Progress = firstLesson.Progress;

            }
            for (int i = 0; i < numberOfLessons; i++)
            {
                if (!result) {
                    return result;
                }

                int timeRequeiredForCurrentTemplate = curentLesson.LessonTemplate.Time;

                if (timeRequeiredForCurrentTemplate > Session.GetLastLessonFromType(_appointment.LessonType).Progress) {
                    curentLesson.Progress += 1;
                } else {
                    curentLesson.TemplateID = DatabaseParser.GetNextLessonTemplateFromID(curentLesson.TemplateID, _appointment.LessonType).Id;
                    curentLesson.Progress = 1;
                }

                result = DatabaseParser.AddLessonToUserID(
                    Session.LoggedInUser.Id, 
                    _appointment.Id,
                    curentLesson.TemplateID, 
                    curentLesson.Progress, 
                    startDateTime, 
                    startDateTime = startDateTime.AddMinutes(45), 
                    false);

            }
            return true;

        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            topPanel.BackColor = ColorScheme.MainTopPanelColor;
        }
    }
}
