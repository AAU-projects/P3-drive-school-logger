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
    public partial class OverviewForm : Form
    {
        public OverviewForm()
        {
            InitializeComponent();
        }

        private void OverviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form login = Application.OpenForms["LoginForm"];
            login.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // log out does not work...
            this.Dispose();
            Form login = Application.OpenForms["LoginForm"];
            login.Show();
        }
    }
}
