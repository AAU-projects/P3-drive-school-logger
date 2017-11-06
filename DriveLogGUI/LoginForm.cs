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
        private Point lastClick;
        public LoginForm()
        {
            InitializeComponent();
            Select();
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void UsernameBox_Leave(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "")
                UsernameBox.Text = "Username";
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "")
            {
                PasswordBox.Text = "Password";
                PasswordBox.PasswordChar = '\0';
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "Password")
                PasswordBox.Text = "";

            PasswordBox.PasswordChar = '*';
        }

        private void UsernameBox_Enter(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "Username")
                UsernameBox.Text = "";
        }

        private void Unfocus_MouseClick(object sender, EventArgs e)
        {
            this.ActiveControl = loginFormLable;
        }
    }
}
