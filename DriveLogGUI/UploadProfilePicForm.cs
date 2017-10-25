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
        public UploadProfilePicForm(RegisterForm registerForm)
        {
            _registerForm = registerForm;
            InitializeComponent();
            this.AllowDrop = true;
        }

        private static RegisterForm _registerForm;
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            _registerForm.Show();
        }
    }
}
