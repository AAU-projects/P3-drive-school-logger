using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI.Windows
{
    public partial class BookAppointmentWindow : Form
    {
        private Point _lastClick;
        private Point _openWindowPosition;
        private Appointment _appointment;

        public BookAppointmentWindow(Appointment appointment, Point mousePosition)
        {
            InitializeComponent();

            this._openWindowPosition = mousePosition;
            this._appointment = appointment;

            SetWindowPosition();
            UpdateData();
        }

        private void UpdateData()
        {
            TitleDateLabel.Text = $"Book appointment at {_appointment.DateShortFormat()}";
            TitleTimeLabel.Text = $"{_appointment.FromTimeToTime()}";
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
    }
}
