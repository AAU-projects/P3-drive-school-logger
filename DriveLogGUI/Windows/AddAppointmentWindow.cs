using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;

namespace DriveLogGUI.Windows
{
    public partial class AddAppointmentWindow : Form
    {
        private Point _lastClick;
        private Point openWindowPosition;
        private DateTime date;
        private List<Appointment> _appointments;

        public AddAppointmentWindow(DateTime eDate, Point mousePosition, List<Appointment> appointments)
        {
            InitializeComponent();

            _appointments = appointments;
            openWindowPosition = mousePosition;
            date = eDate;

            UpdateTitle();
            SetWindowPosition();

            FillTimeComboBox(StartTimecomboBox);
            FillComboBox(lessonsComboBox);

            timeDifferenceLabel.Text = "";
            endTimeLabel.Text = "";
            lessonsComboBox.SelectedItem = 1;
        }

        private void FillTimeComboBox(ComboBox comboBox)
        {
            DateTime time = new DateTime();
            time = time.AddHours(6);

            for (int i = 0; i < 96; i++)
            {
                comboBox.Items.Add(time.ToString("HH:mm"));
                time = time.AddMinutes(15);
            }
        }

        private void FillComboBox(ComboBox comboBox)
        {
            for (int i = 0; i < 20; i++)
            {
                comboBox.Items.Add(i+1);
            }
        }

        private void SetWindowPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(openWindowPosition.X - this.Width, openWindowPosition.Y - this.Height);
        }

        private void UpdateTitle()
        {
            TitleLabel.Text = $"Add appointment to {date.ToShortDateString().Replace('/', '-')}";
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();;
        }

        private void CancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartTimecomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
           SetComboBoxTimeDifference();
        }

        private void LessonsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SetComboBoxTimeDifference();
        }

        private void SetComboBoxTimeDifference()
        {
            if (StartTimecomboBox.Text != String.Empty & lessonsComboBox.Text != String.Empty)
            {
                DateTime startTime = DateTime.Parse(StartTimecomboBox.Text);
                DateTime endTime = startTime.AddMinutes(45 * (int)lessonsComboBox.SelectedItem);

                TimeSpan timeDifference = endTime - startTime;

                if (timeDifference.Hours <= 0)
                    timeDifferenceLabel.Text = $"{timeDifference.Minutes} minutes";
                else
                    timeDifferenceLabel.Text = $"{timeDifference.Hours} hours {timeDifference.Minutes} minutes";

                endTimeLabel.Text = "to " + endTime.ToString("t");
            }
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LessonTypecomboBox.Text) && !String.IsNullOrEmpty(StartTimecomboBox.Text) && !String.IsNullOrEmpty(lessonsComboBox.Text))
            {
                TimeSpan startTime = TimeSpan.Parse(StartTimecomboBox.Text);
                DateTime dateToAdd = date.Date + startTime;

                bool appointmentAdded = DatabaseParser.AddAppointment(LessonTypecomboBox.Text, dateToAdd, (int)lessonsComboBox.SelectedItem,
                    Session.LoggedInUser.Id.ToString());

                if (appointmentAdded)
                {
                    CustomMsgBox.ShowOk("Succes", "Appointment succesfully added", CustomMsgBoxIcon.Complete);

                    AppointmentStructure appointmentStructure = 
                        new AppointmentStructure(-1, Session.LoggedInUser.Id,
                        dateToAdd, (int) lessonsComboBox.SelectedItem, LessonTypecomboBox.Text, false,
                        Session.LoggedInUser.Fullname);

                    _appointments.Add(new Appointment(appointmentStructure));
                    this.Dispose();
                }
                else
                    CustomMsgBox.ShowOk("Failure", "Appointment failed to upload", CustomMsgBoxIcon.Error);
            }
            else
                CustomMsgBox.ShowOk("Failure", "Some fields need to be filled", CustomMsgBoxIcon.Warrning);
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {
            topPanel.BackColor = ColorScheme.MainTopPanelColor;
        }
    }
}
