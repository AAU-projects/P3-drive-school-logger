using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogGUI
{
    static class CustomMsgBoxIcon
    {
        public static Image Warrning {
            get { return Image.FromFile("Ressources/icons8-attention.png"); }
        }

        public static Image Error {
            get { return Image.FromFile("Resources/icons8-close-window.png"); }
        }

        public static Image Complete {
            get { return Image.FromFile("Resources/icons8-checkmark.png"); }
        }
    }
}
