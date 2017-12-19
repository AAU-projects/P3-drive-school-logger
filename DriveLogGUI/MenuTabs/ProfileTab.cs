using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI.MenuTabs
{
    public delegate void NoParametersEvent();
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<ProfileTab, UserControl>))]
    public abstract class ProfileTab : UserControl
    {
        internal virtual event NoParametersEvent BackButtonClicked;
        internal virtual event SubPageNotification SubPageCreated;

        public virtual event EventHandler LogOutButtonClick;

        /// <summary>
        /// The Event for when the logout button is clicked in the form.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }

        /// <summary>
        /// Updates the info shown on the profile.
        /// </summary>
        public abstract void UpdateInfo();

        internal virtual event EventHandler IconPictureButtonClickEvent;
    }
}

    
