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
        internal virtual event EventHandler IconPictureButtonClickEvent;
    }
}
