using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class RegisterForm : Form
    {
        private LoginForm _loginForm;
        public RegisterForm(LoginForm login)
        {
            _loginForm = login;
            InitializeComponent();
        }

        private void registerTitleLabel_Click(object sender, EventArgs e)
        {

        }

        private void registerCancelHyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Show();
            this.Dispose();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Show();
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
