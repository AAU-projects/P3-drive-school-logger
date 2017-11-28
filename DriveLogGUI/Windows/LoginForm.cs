using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;

namespace DriveLogGUI.Windows
{
    public partial class LoginForm : Form
    {
        private Point lastClick;
        public LoginForm()
        {
            InitializeComponent();
            Select();
        }

        public void ResetInformation(bool failLogin = false)
        {
            UsernameBox.Text = "Username";
            PasswordBox.Text = "Password";
            PasswordBox.PasswordChar = '\0';
        }

        private void createNewUserLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.ShowDialog(this);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            // TODO remove else when program is done
            if (UsernameBox.Text != "Username")
            {
                DataTable user = MySql.GetUserByName(UsernameBox.Text);
                if (user == null || user.Rows[0][10].ToString() != PasswordBox.Text) {
                    CustomMsgBox.Show("Wrong username or password", "Error", CustomMsgBoxIcon.Error);

                    // resets password with false login information
                    if (PasswordBox.Text != "Password") {
                        PasswordBox.Clear();
                    }
                    return;
                }

                Session.LoadUserFromDataTable(user);

            }
            else
            {
                Session.LoadUserFromDataTable(MySql.GetUserByName("luke"));
            }

            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog(this);

            // resets information after logout
            ResetInformation();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = ColorScheme.MainTopPanelColor;
        }
    }
}
