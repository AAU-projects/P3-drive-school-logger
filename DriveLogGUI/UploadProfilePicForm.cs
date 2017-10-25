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
    public partial class UploadProfilePicForm : Form
    {
        public UploadProfilePicForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
        }
    }
}
