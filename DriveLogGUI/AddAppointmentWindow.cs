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
        }

        private void SetWindowPosition()
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(openWindowPosition.X - this.Width, openWindowPosition.Y - this.Height);
        }

        private void UpdateTitle()
        {
            TitleLabel.Text = $"Add apointment to {date.ToShortDateString().Replace('/', '-')}";
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
    }
}
