using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public class CalendarData
    {
        public Panel Panel { get; set; }
        public Label Label { get; set; }

        public CalendarData(Panel inputPanel, Label inputLabel)
        {
            Panel = inputPanel;
            Label = inputLabel;
        }
    }
}
