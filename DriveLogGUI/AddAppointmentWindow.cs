using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class AddAppointmentWindow : Form
    {
        private Point _lastClick;
        private Point openWindowPosition;
        private DateTime date;

        public AddAppointmentWindow(DateTime eDate, Point mousePosition)
        {
            InitializeComponent();
            openWindowPosition = mousePosition;
            date = eDate;
            UpdateTitle();
            SetWindowPosition();
            FillTimeComboBox(StartTimecomboBox);
            FillComboBox(EndTimecomboBox);
            timeDifferenceLabel.Text = "";
            AddAppointmentButton.Enabled = false;
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

        private void EndTimecomboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SetComboBoxTimeDifference();
        }

        private void SetComboBoxTimeDifference()
        {
            if (StartTimecomboBox.Text != String.Empty & EndTimecomboBox.Text != String.Empty)
            {
                DateTime startTime = DateTime.Parse(StartTimecomboBox.Text);
                DateTime endTime = startTime.AddMinutes(45 * (int)EndTimecomboBox.SelectedItem);

                TimeSpan timeDifference = endTime - startTime;

                if (timeDifference.Hours <= 0)
                    timeDifferenceLabel.Text = $"{timeDifference.Minutes} minutes";
                else
                    timeDifferenceLabel.Text = $"{timeDifference.Hours} hours {timeDifference.Minutes} minutes";
            }
        }
    }
}
