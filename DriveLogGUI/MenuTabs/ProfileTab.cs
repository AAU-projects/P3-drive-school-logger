using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI.MenuTabs
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<ProfileTab, UserControl>))]
    public abstract class ProfileTab : UserControl
    {
        internal virtual event SubPageNotification SubPageCreated;

        public virtual event EventHandler LogOutButtonClick;

        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }
    }
}

    
