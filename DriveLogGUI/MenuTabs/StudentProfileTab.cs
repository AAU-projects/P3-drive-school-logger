﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.CustomEventArgs;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class StudentProfileTab : ProfileTab
    {
        private User _user;
        private bool _search;
        internal override event SubPageNotification SubPageCreated;

        public Color PrevColor;
        private Panel _showInformation;

        public StudentProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;
            UpdateLayout();
            UpdateInfo();

            foreach (Control c in progressBarPanel.Controls)
            {
                c.MouseClick += progressBarPanel_Click;

                foreach (Control childControl in c.Controls)
                    childControl.MouseClick += progressBarPanel_Click;
            }
        }

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
        private void UpdateInfo()
        {
            profileHeaderLabel.Text = @"Profile: " + _user.Username;
            nameOutputLabel.Text = _user.Fullname;
            phoneOutputLabel.Text = _user.Phone;
            cprOutputLabel.Text = _user.Cpr;
            emailOutputLabel.Text = _user.Email;
            addressOutputLabel.Text = _user.Address;
            cityOutputLabel.Text = $@"{_user.City}, {_user.Zip}";
            theoreticalStatus.Text = _user.TheoreticalProgress + @"/24";
            practicalStatus.Text = _user.PracticalProgress + @"/14";

            theoreticalProgressFill.Size = new Size((theoreticalBar.Width / 24) * _user.TheoreticalProgress, theoreticalBar.Height);
            practicalProgressFill.Size = new Size((practicalBar.Width / 14) * _user.PracticalProgress, practicalBar.Height);

            if (!string.IsNullOrEmpty(_user.PicturePath) || _user.PicturePath != "")
            {
                ProfilePicture.Load(_user.PicturePath);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditUserInfoForm editForm = new EditUserInfoForm(_user);

            editForm.ShowDialog(this);
            UpdateInfo();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Find("userSearchTab", false)[0].Show();
            this.Dispose();
        }

        private void progressBarPanel_Click(object sender, EventArgs e)
        {
            if (!_search)
            {
                SubPageCreated?.Invoke(this);
            }
            else
            {
                this.Hide();
                DriveLogTab studentFoundDriveLogTab = new DriveLogTab(_user, true);
                studentFoundDriveLogTab.Location = this.Location;
                studentFoundDriveLogTab.Parent = this;
                this.Parent.Controls.Add(studentFoundDriveLogTab);
                studentFoundDriveLogTab.Show();
            }
        }

        private void panelContainingUpcomingLessons_Paint(object sender, PaintEventArgs eventArgs)
        {
            int widthForEachDay = panelContainingUpcomingLessons.Width;
            int heightForEachDay = panelContainingUpcomingLessons.Height / 10;
            int locationForRow = 0;
            List<Lesson> scheduledLessons = new List<Lesson>();
            backButtonInUpcomingLesson.Hide();

            foreach (Lesson lesson in Session.LessonsUser)
            {
                if (!lesson.Completed && scheduledLessons.Count <= 10)
                {
                    scheduledLessons.Add(lesson);
                }
            }

            foreach (Lesson lesson in scheduledLessons)
            {
                Label dateLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = panelContainingUpcomingLessons.Width / 3 - 10,
                    Left = 4
                };

                Label lessonInformationLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = panelContainingUpcomingLessons.Width / 3 - 40,
                    Left = panelContainingUpcomingLessons.Width / 3 - 10
                };

                Label lessonTitleAndPartLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = panelContainingUpcomingLessons.Width / 3 + 40,
                    Left = panelContainingUpcomingLessons.Width / 3 + panelContainingUpcomingLessons.Width / 3 - 40
                };

                CalendarData upcomingLessonData = new CalendarData(new Panel(), dateLabel, lessonInformationLabel, lessonTitleAndPartLabel, lesson)
                {
                    PanelForCalendarDay =
                    {
                        Width = widthForEachDay,
                        Height = heightForEachDay,
                        Location = new Point(0, locationForRow)
                    }
                };

                locationForRow += heightForEachDay;

                upcomingLessonData.PanelForCalendarDay.BackColor = Color.White;

                upcomingLessonData.PanelForCalendarDay.Controls.Add(upcomingLessonData.LabelLessonInformation);
                upcomingLessonData.PanelForCalendarDay.Controls.Add(upcomingLessonData.LabelLessonTitleAndPart);
                upcomingLessonData.PanelForCalendarDay.Controls.Add(upcomingLessonData.LabelForDate);

                upcomingLessonData.LabelForDate.Text = $@"{lesson.StartDate.Date:dd/MM} {lesson.StartDate.DayOfWeek}";
                upcomingLessonData.LabelLessonTitleAndPart.Text = $@"{lesson.LessonTemplate.Title} ({lesson.Progress}/{lesson.LessonTemplate.Time})";
                upcomingLessonData.LabelLessonInformation.Text = $@"{lesson.StartDate:HH:mm}  - {lesson.EndDate:HH:mm}";

                upcomingLessonData.ClickOnUpcomingLessonTriggered += ShowInformationAboutLesson;

                upcomingLessonData.PanelForCalendarDay.MouseEnter += (s, e) => ChangeCursorAndHoverEnter(upcomingLessonData);
                upcomingLessonData.LabelForDate.MouseEnter += (s, e) => ChangeCursorAndHoverEnter(upcomingLessonData);
                upcomingLessonData.LabelLessonInformation.MouseEnter += (s, e) => ChangeCursorAndHoverEnter(upcomingLessonData);
                upcomingLessonData.LabelLessonTitleAndPart.MouseEnter += (s, e) => ChangeCursorAndHoverEnter(upcomingLessonData);

                upcomingLessonData.PanelForCalendarDay.MouseLeave += (s, e) => ChangeCursorAndHoverLeave(upcomingLessonData);
                upcomingLessonData.LabelForDate.MouseLeave += (s, e) => ChangeCursorAndHoverLeave(upcomingLessonData);
                upcomingLessonData.LabelLessonInformation.MouseLeave += (s, e) => ChangeCursorAndHoverLeave(upcomingLessonData);
                upcomingLessonData.LabelLessonTitleAndPart.MouseLeave += (s, e) => ChangeCursorAndHoverLeave(upcomingLessonData);

                panelContainingUpcomingLessons.Controls.Add(upcomingLessonData.PanelForCalendarDay);
            }
        }

        private void ShowInformationAboutLesson(object sender, LessonClickEventArgs lesson)
        {
            _showInformation = new Panel
            {
                Width = panelContainingUpcomingLessons.Width,
                Height = panelContainingUpcomingLessons.Height,
                Location = panelContainingUpcomingLessons.Location,
                BackColor = Color.White
            };
            
            Label titleForLesson = new Label
            {
                AutoSize = false,
                Height = 40,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                ForeColor = ColorScheme.MainFontColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Text = lesson.Lesson.LessonTemplate.Title
            };

            TextBox descriptionForLesson = new TextBox()
            {
                AutoSize = false,
                Width = _showInformation.Width - 40,
                Height = 100,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                ForeColor = ColorScheme.MainFontColor,
                Dock = DockStyle.Top,
                Text = lesson.Lesson.LessonTemplate.Description
            };

            Label dateForLesson = new Label
            {
                AutoSize = false,
                Height = 40,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                ForeColor = ColorScheme.MainFontColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Text = $@"Date: {lesson.Lesson.StartDate:f}  - {lesson.Lesson.EndDate:t}"
            };

            Label readingForLesson = new Label
            {
                AutoSize = false,
                Height = 40,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                ForeColor = ColorScheme.MainFontColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Text = $@"Reading: {lesson.Lesson.LessonTemplate.Reading}"
            };

            Label instructorForLesson = new Label
            {
                AutoSize = false,
                Height = 40,
                Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                ForeColor = ColorScheme.MainFontColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Text = $@"Instructor for lesson: {lesson.Lesson.InstructorFullname}"
            };

            _showInformation.Controls.Add(instructorForLesson);
            _showInformation.Controls.Add(readingForLesson);
            _showInformation.Controls.Add(dateForLesson);
            _showInformation.Controls.Add(descriptionForLesson);
            _showInformation.Controls.Add(titleForLesson);
            panel1.Controls.Add(_showInformation);

            dateLabel.Hide();
            timelLabel.Hide();
            lessonLabel.Hide();
            panelContainingUpcomingLessons.Hide();

            backButtonInUpcomingLesson.Show();
        }

        private void ChangeCursorAndHoverEnter(CalendarData data)
        {
            PrevColor = data.PanelForCalendarDay.BackColor;

            data.LabelForDate.Cursor = Cursors.Hand;
            data.LabelForDate.BackColor = ColorScheme.MainThemeColorLighter;
            data.LabelForDate.ForeColor = Color.Black;

            data.LabelLessonInformation.Cursor = Cursors.Hand;
            data.LabelLessonInformation.BackColor = ColorScheme.MainThemeColorLighter;
            data.LabelLessonInformation.ForeColor = Color.Black;

            data.LabelLessonTitleAndPart.Cursor = Cursors.Hand;
            data.LabelLessonTitleAndPart.BackColor = ColorScheme.MainThemeColorLighter;
            data.LabelLessonTitleAndPart.ForeColor = Color.Black;

            data.PanelForCalendarDay.Cursor = Cursors.Hand;
            data.PanelForCalendarDay.BackColor = ColorScheme.MainThemeColorLighter;
        }

        private void ChangeCursorAndHoverLeave(CalendarData data)
        {
            data.LabelForDate.Cursor = Cursors.Default;
            data.LabelForDate.BackColor = Color.White;
            data.LabelForDate.ForeColor = ColorScheme.MainFontColor;

            data.LabelLessonInformation.Cursor = Cursors.Default;
            data.LabelLessonInformation.BackColor = Color.White;
            data.LabelLessonInformation.ForeColor = ColorScheme.MainFontColor;

            data.LabelLessonTitleAndPart.Cursor = Cursors.Default;
            data.LabelLessonTitleAndPart.BackColor = Color.White;
            data.LabelLessonTitleAndPart.ForeColor = ColorScheme.MainFontColor;

            data.PanelForCalendarDay.Cursor = Cursors.Hand;
            data.PanelForCalendarDay.BackColor = Color.White;
        }

        private void backButtonInUpcomingLesson_Click(object sender, EventArgs e)
        {
            _showInformation.Hide();
            panelContainingUpcomingLessons.Show();
            backButtonInUpcomingLesson.Hide();
            dateLabel.Show();
            timelLabel.Show();
            lessonLabel.Show();
        }
    }
}

