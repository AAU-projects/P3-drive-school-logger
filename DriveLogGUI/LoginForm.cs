using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void createNewUserLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.ShowDialog(this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            DataTable user = MySql.GetUser(UsernameBox.Text);
            if (user == null || user.Rows[0][10].ToString() != PasswordBox.Text) {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Session.LoadUserFromDataTable(user);

            this.Hide();
            MainWindowTab main = new MainWindowTab();
            main.ShowDialog(this);
        }
    }
}
