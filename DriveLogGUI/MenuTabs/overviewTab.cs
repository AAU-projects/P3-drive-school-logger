using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;

namespace DriveLogGUI.MenuTabs
{
    // Created a delegate for an event used when navigating so submenus through the Overview Tab
    internal delegate void SubPageNotification(UserControl origin);
    // Provides a type description for the abstract class, this enables further use of the designer
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<OverviewTab, UserControl>))]
    public abstract class OverviewTab : UserControl
    {
        // Event raised when clicking the Log out button
        public virtual event EventHandler LogOutButtonClick;
        
        // Event raised when clicking icons on the overview
        internal virtual event EventHandler IconPictureButtonClickEvent;

        // Event raised when navigating to subpages through the overview tab
        internal virtual event SubPageNotification SubPageCreated;

        // Instantiates a new list of CalendarData
        public List<CalendarData> listOfDays = new List<CalendarData>();

        /// <summary>
        /// Invokes the logOutButtonClick event when clicking the log out button
        /// </summary>
        /// <param name="sender">The object Sender</param>
        /// <param name="e">The EventArgs</param>
        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }

        // Updates the information contained in the current tab
        public abstract void UpdateInfo();
    }
}
