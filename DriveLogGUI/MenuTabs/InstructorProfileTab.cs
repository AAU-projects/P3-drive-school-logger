using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class InstructorProfileTab : ProfileTab
    {
        private User _user;
        private bool _search;
        internal event SubPageNotification SubPageCreated;
        internal override event NoParametersEvent BackButtonClicked;

        private List<AppointmentStructure> instructorAppointments = new List<AppointmentStructure>();
        private Dictionary<AppointmentStructure, List<Lesson>> lessonsForAppointments = new Dictionary<AppointmentStructure, List<Lesson>>();

        private RichTextBox lessonInformation;
        private RichTextBox studentsForLesson;
        private RichTextBox lessonData;

        /// <summary>
        /// The constructor for the InstructorProfileTab
        /// </summary>
        /// <param name="user"></param>
        /// <param name="search"></param>
        public InstructorProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;
            UpdateLayout();
            UpdateInfo();

            FormatAppointmentInformationPanel();
            CreateAppointmentInfoContent();
        }

        /// <summary>
        /// Updates the layout if the profile was accessed from the search window.
        /// </summary>
        private void UpdateLayout()
        {
            if(_search)
            {
                backButton.Enabled = true;
                backButton.Visible = true;
                logoutButton.Enabled = false;
                logoutButton.Visible = false;
            }
        }

        /// <summary>
        /// Updates the user information with data from session class
        /// </summary>
        public override void UpdateInfo()
        {
            profileHeaderLabel.Text = "Profile: " + _user.Username;
            nameOutputLabel.Text = _user.Fullname;
            phoneOutputLabel.Text = _user.Phone;
            cprOutputLabel.Text = _user.Cpr;
            emailOutputLabel.Text = _user.Email;
            addressOutputLabel.Text = _user.Address;
            cityOutputLabel.Text = $"{_user.City}, {_user.Zip}";

            if (!string.IsNullOrEmpty(_user.PicturePath) || _user.PicturePath != "")
            {
                ProfilePicture.Load(_user.PicturePath);
            }
        }

        /// <summary>
        /// The click function for the edit button.
        /// Opens a new EditUserInfoForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editButton_Click(object sender, EventArgs e)
        {
            EditUserInfoForm editForm = new EditUserInfoForm(_user);

            editForm.ShowDialog(this);
            UpdateInfo();
        }

        /// <summary>
        /// The click function for the back button.
        /// Goes back to the search tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Find("userSearchTab", false)[0].Show();
            BackButtonClicked?.Invoke();
            this.Dispose();
        }

        /// <summary>
        /// Formats the AppointmentInformationPanel with the correct location, width and height. 
        /// </summary>
        private void FormatAppointmentInformationPanel()
        {
            // Create overlay panel, for when the user clicks on an appointment.
            appointmentInformationPanel.Width = upcommingLessonsBackPanel.Width;
            appointmentInformationPanel.Height = upcommingLessonsBackPanel.Height;
            appointmentInformationPanel.Location = new Point(0, 0);

            upcommingLessonsBackPanel.Controls.Add(appointmentInformationPanel);

            // Create subpanels and labels for the overlay panel.

            // Create back button.
            Button informationPanelBackButton = new Button
            {
                Text = "Back",
                ForeColor = Color.White,
                BackColor = ColorScheme.MainThemeColorLighter,
                Width = 80,
                Height = 40,
                Left = appointmentInformationPanel.Width - 92,
                Top = appointmentInformationPanel.Height - 50,
                FlatStyle = FlatStyle.Flat
            };
            informationPanelBackButton.Click += (s, e) => OnInfoPanelBackButtonClicked();
            appointmentInformationPanel.Controls.Add(informationPanelBackButton);

            appointmentInformationPanel.BringToFront();
            appointmentInformationPanel.Hide();
        }

        /// <summary>
        /// Click function for the InfoPanel back button.
        /// Clears the text in all the textboxes and hides the panel.
        /// </summary>
        private void OnInfoPanelBackButtonClicked()
        {
            foreach (Control control in appointmentInformationPanel.Controls)
            {
                if (control is RichTextBox)
                {
                    RichTextBox textBox = control as RichTextBox;
                    textBox.Clear();
                }
            }
            appointmentInformationPanel.Hide();
        }

        /// <summary>
        /// The paint function for the upcoming lessons panel.
        /// Draws up to 10 appointments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelContainingUpcomingLessons_Paint(object sender, PaintEventArgs e)
        {
            lessonsForAppointments.Clear();
            int widthForEachDay = panelContainingUpcomingLessons.Width / 4;
            int heightForEachDay = panelContainingUpcomingLessons.Height / 10;
            int locationForRow = 0;

            // Takes a maximum of 10 appointments from the current instructor, and saves all lessons from that appointment, but removes duplicates for each student ID.
            int counter = 0;
            foreach (AppointmentStructure userAppointment in _user.InstructorAppointments)
            {
                if (counter < 10)
                {
                    List<Lesson> listOfLessonsForCurrentAppointment = _user.InstructorLessons
                        .Where(l => l.AppointmentID == userAppointment.Id).GroupBy(x => x.StudentId).Select(y => y.First()).ToList();

                    lessonsForAppointments.Add(userAppointment, listOfLessonsForCurrentAppointment);
                    counter++;
                }
            }

            foreach (KeyValuePair<AppointmentStructure,List<Lesson>> currentAppointment in lessonsForAppointments)
            {
                Panel appointmentPanel = new Panel
                {
                    Width = panelContainingUpcomingLessons.Width,
                    Height = heightForEachDay,
                    Location = new Point(0, locationForRow),
                    Cursor = Cursors.Hand
                };

                Label dateLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay + 30,
                    Left = 0
                };

                Label timeLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay / 2,
                    Left = widthForEachDay + 30
                };

                Label typeLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay,
                    Left = timeLabel.Left + timeLabel.Width + 10
                };

                Label statusLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay,
                    Left = typeLabel.Left + widthForEachDay + 10
                };

                locationForRow += heightForEachDay;

                // Add Controls.
                appointmentPanel.Controls.Add(statusLabel);
                appointmentPanel.Controls.Add(typeLabel);
                appointmentPanel.Controls.Add(timeLabel);
                appointmentPanel.Controls.Add(dateLabel);

                panelContainingUpcomingLessons.Controls.Add(appointmentPanel);

                // Set values of labels.
                dateLabel.Text = $@"{currentAppointment.Key.StartTime.Date:dd/MM} {currentAppointment.Key.StartTime.DayOfWeek}";
                timeLabel.Text = $@"{currentAppointment.Key.StartTime:HH:mm}";
                typeLabel.Text = $@"{currentAppointment.Key.LessonType}";
                

                // Get amount of booked students.
               /* List<Lesson> listOfLessonsForCurrentAppointment = Session.LoggedInUser.InstructorLessons
                    .Where(l => l.AppointmentID == appointment.Id).GroupBy(x => x.StudentId).Select(y => y.First()).ToList();*/
                statusLabel.Text = $@"{currentAppointment.Value.Count} / 24";

                // Panel hover.
                foreach (Label label in appointmentPanel.Controls)
                {
                    label.MouseClick += (s, eventArgs) => OnAppointmentClícked(currentAppointment);
                    label.MouseEnter += (s, eventArgs) => OnAppointmentPanelEnter(appointmentPanel);
                    label.MouseLeave += (s, eventArgs) => OnAppointmentPanelLeave(appointmentPanel);
                }
            }
        }

        /// <summary>
        /// Creates the textboxes for the appointment information panel.
        /// </summary>
        private void CreateAppointmentInfoContent()
        {
            lessonInformation = new RichTextBox
            {
                AutoSize = false,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                Multiline = true,
                ReadOnly = true,
                ForeColor = ColorScheme.MainFontColor,
                BackColor = ColorScheme.MainBackgroundColor,
                BorderStyle = BorderStyle.None,
                Width = appointmentInformationPanel.Width - 20,
                Height = appointmentInformationPanel.Height / 2 - 20,
                Left = 10,
                Top = 10
            };

            studentsForLesson = new RichTextBox
            {
                AutoSize = false,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                Multiline = true,
                ReadOnly = true,
                ForeColor = ColorScheme.MainFontColor,
                BackColor = ColorScheme.MainBackgroundColor,
                BorderStyle = BorderStyle.None,
                Width = appointmentInformationPanel.Width / 2 - 20,
                Height = appointmentInformationPanel.Height / 2 - 10,
                Left = 10,
                Top = lessonInformation.Bottom + 10
            };

            lessonData = new RichTextBox
            {
                AutoSize = false,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                Multiline = true,
                ReadOnly = true,
                ForeColor = ColorScheme.MainFontColor,
                BackColor = ColorScheme.MainBackgroundColor,
                BorderStyle = BorderStyle.None,
                Width = appointmentInformationPanel.Width / 2 - 10,
                Height = appointmentInformationPanel.Height / 2 - 60,
                Left = studentsForLesson.Width + 20,
                Top = lessonInformation.Bottom + 10,
                ScrollBars = RichTextBoxScrollBars.None
            };

            appointmentInformationPanel.Controls.Add(lessonData);
            appointmentInformationPanel.Controls.Add(studentsForLesson);
            appointmentInformationPanel.Controls.Add(lessonInformation);
        }

        /// <summary>
        /// The click function for an appointment, in the appointment overview panel.
        /// Gets the necessary information about the appointment and draws the panel.
        /// </summary>
        /// <param name="appointmentLessonPair"></param>
        private void OnAppointmentClícked(KeyValuePair<AppointmentStructure, List<Lesson>> appointmentLessonPair)
        {
            // Sets the fontstyle to bold for the title of the textboxes, and changes it back to normal afterwards.
            lessonInformation.SelectionFont = new Font(lessonInformation.Font, FontStyle.Bold);
            lessonInformation.AppendText("Lesson information:" + Environment.NewLine);
            lessonInformation.SelectionFont = new Font("Calibri Light", 10F, FontStyle.Regular);

            studentsForLesson.SelectionFont = new Font(studentsForLesson.Font, FontStyle.Bold);
            studentsForLesson.AppendText("Booked students:" + Environment.NewLine);
            studentsForLesson.SelectionFont = new Font("Calibri Light", 10F, FontStyle.Regular);

            lessonData.SelectionFont = new Font(studentsForLesson.Font, FontStyle.Bold);
            lessonData.AppendText("Appointment information:" + Environment.NewLine);
            lessonData.SelectionFont = new Font("Calibri Light", 10F, FontStyle.Regular);

            lessonData.AppendText($"Lesson date: {appointmentLessonPair.Key.StartTime:MM/dd/yyyy}" + Environment.NewLine);
            lessonData.AppendText($"Lesson time: {appointmentLessonPair.Key.StartTime:HH:mm} - {appointmentLessonPair.Key.StartTime.AddMinutes(45 * appointmentLessonPair.Key.AvailableTime):HH:mm}" + Environment.NewLine);
            DateTime availableTime = new DateTime();
            availableTime = availableTime.AddMinutes(45 * appointmentLessonPair.Key.AvailableTime);
            lessonData.AppendText($"Allocated time: {availableTime:HH}h{availableTime:mm}min" + Environment.NewLine);
            lessonData.AppendText($"Lessontype: {appointmentLessonPair.Key.LessonType}" + Environment.NewLine);
            lessonData.AppendText($"Booked students: {appointmentLessonPair.Value.Count} / 24" + Environment.NewLine);

            // Checks if any students have booked the appointment.
            if (appointmentLessonPair.Value.Count == 0)
            {
                lessonInformation.AppendText("The lesson template will be updated when a student books this lesson.");
                studentsForLesson.AppendText("No users have booked this lesson yet.");
            }
            else
            {
                // Set the template description for the lessonInformation textbox.
                lessonInformation.AppendText(appointmentLessonPair.Value[0].LessonTemplate.Description);

                // Add student names to studentsForLesson textbox.
                List<int> studentIds = appointmentLessonPair.Value.Select(i => i.StudentId).ToList();
                List<User> studentsForAppointment = DatabaseParser.GetAllUsersFromMultipleUserIds(studentIds);
                
                foreach (User student in studentsForAppointment)
                {
                    studentsForLesson.AppendText($"{student.Firstname} {student.Lastname}" + Environment.NewLine);
                }
            }
            appointmentInformationPanel.Show();
        }

        /// <summary>
        /// The enter function for an appointmentpanel
        /// Changes the color to indicate a clickable object.
        /// </summary>
        /// <param name="appointmentPanel"></param>
        private void OnAppointmentPanelEnter(Panel appointmentPanel)
        {
            appointmentPanel.BackColor = ColorScheme.MainThemeColorLighter;
            foreach (Label label in appointmentPanel.Controls)
                label.ForeColor = Color.White;
        }

        /// <summary>
        /// The leave function for an appointmentpanel
        /// Changes the color back to the default.
        /// </summary>
        /// <param name="appointmentPanel"></param>
        private void OnAppointmentPanelLeave(Panel appointmentPanel)
        {
            appointmentPanel.BackColor = Color.White;
            foreach (Label label in appointmentPanel.Controls)
                label.ForeColor = ColorScheme.MainFontColor;
        }
    }
}
