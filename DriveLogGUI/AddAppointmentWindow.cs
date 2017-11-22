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
            FillComboBox(StartTimecomboBox);
            FillComboBox(EndTimecomboBox);
        }

        private void FillComboBox(ComboBox comboBox)
        {
            DateTime time = new DateTime();
            time = time.AddHours(6);

            for (int i = 0; i < 96; i++)
            {
                comboBox.Items.Add(time.ToString("HH:mm"));
                time = time.AddMinutes(15);
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
            EndTimecomboBox.Text = StartTimecomboBox.Items[StartTimecomboBox.SelectedIndex + 3].ToString();
        }
    }
}
