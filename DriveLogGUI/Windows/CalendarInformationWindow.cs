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
    public partial class CalendarInformationWindow : Form
    {
        private Point _lastClick;

        public CalendarInformationWindow()
        {
            InitializeComponent();

            AddStuff(panel1);
            AddStuff(panel2);
            AddStuff(panel3);
            AddStuff(panel4);
            AddStuff(panel5);
            AddStuff(panel6);
            AddStuff(panel7);
            AddStuff(panel8);
            AddStuff(panel9);
            AddStuff(panel10);
            AddStuff(panel11);
            AddStuff(panel12);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Adds stuff onto the picture, this is to make sure that objects can be transparent onto the Control
        /// </summary>
        /// <param name="panel">A control that should be added onto the panel</param>
        private void AddStuff(Control panel)
        {
            pictureBoxCalendarInformation.Controls.Add(panel);
            panel.Location = new Point(panel.Location.X, panel.Location.Y - 22);
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
    }
}
