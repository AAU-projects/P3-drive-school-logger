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
    internal delegate void SubPageNotification(UserControl origin);
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<OverviewTab, UserControl>))]
    public abstract class OverviewTab : UserControl
    {
        public virtual event EventHandler LogOutButtonClick;
        
        internal virtual event EventHandler IconPictureButtonClickEvent;

        internal virtual event SubPageNotification SubPageCreated;
        public List<CalendarData> listOfDays = new List<CalendarData>();

        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }

        public abstract void UpdateInfo();
    }
}
