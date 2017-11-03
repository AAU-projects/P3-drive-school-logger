using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class overviewTab : UserControl
    {
        public event EventHandler LogOutButtonClick;
        public overviewTab()
        {
            InitializeComponent();
        }

        private void progressBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void todaysNotePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void theoreticalStatus_Click(object sender, EventArgs e)
        {

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.LogOutButtonClick != null)
                this.LogOutButtonClick(this, e);
        }

    }
}
