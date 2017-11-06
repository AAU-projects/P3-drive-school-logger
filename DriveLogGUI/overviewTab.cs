using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class OverviewTab : UserControl
    {
        public event EventHandler LogOutButtonClick;
        public OverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = "Welcome " + Session.LoggedInUser.Firstname;
        }

        public void logoutButton_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.LogOutButtonClick != null)
                this.LogOutButtonClick(this, e);
        }

    }
}
