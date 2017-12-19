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

        /// <summary>
        /// Resets the text shown in the Username and Password box.
        /// </summary>
        /// <param name="failLogin">A bool the check if the login has failed</param>
        public void ResetInformation(bool failLogin = false)
        {
            UsernameBox.Text = "Username";
            PasswordBox.Text = "Password";
            PasswordBox.PasswordChar = '\0';
        }

        /// <summary>
        /// Opens the registerform.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void createNewUserLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm(this);
            registerForm.ShowDialog(this);
        }

        /// <summary>
        /// Logs into the system if the username and password match.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            // TODO remove else when program is done
            if (UsernameBox.Text != "Username")
            {
                User user = DatabaseParser.GetUserByUsername(UsernameBox.Text);
                if (user == null || user.Password != PasswordBox.Text) {
                    CustomMsgBox.ShowOk("Wrong username or password", "Error", CustomMsgBoxIcon.Error);

                    // resets password with false login information
                    if (PasswordBox.Text != "Password") {
                        PasswordBox.Clear();
                    }
                    return;
                }

                Session.LoadUser(user);
            }
            else
            {
                Session.LoadUser(DatabaseParser.GetUserByUsername("luke"));
            }

            this.Hide();
            MainWindow main = new MainWindow();
            main.ShowDialog(this);
            Session.LogOut();
            // resets information after logout
            ResetInformation();
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// The Event for when the mouse is pressed down, while the mouse is hovering the statusbar.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        /// <summary>
        /// The Event for when then mouse is hovering above the statusbar.
        /// Used to move the window.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        /// <summary>
        /// The Event for minimizing the program
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// The Event for exiting the LoginForm
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// The Event for when the user leaves the UsernameBox
        /// Resets the text in the box if the user didn't give an input
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void UsernameBox_Leave(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "")
                UsernameBox.Text = "Username";
        }

        /// <summary>
        /// The Event for when the user leaves the PasswordBox
        /// Resets the text in the box if the user didn't give an input
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "")
            {
                PasswordBox.Text = "Password";
                PasswordBox.PasswordChar = '\0';
            }
        }

        /// <summary>
        /// Clears the text in the PasswordBox, when the user enters it.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (PasswordBox.Text == "Password")
                PasswordBox.Text = "";

            PasswordBox.PasswordChar = '*';
        }

        /// <summary>
        /// Clears the text in the UsernameBox, when the user enters it.
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void UsernameBox_Enter(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "Username")
                UsernameBox.Text = "";
        }

        /// <summary>
        /// Sets the activecontrol as the title label, this ensures that the user will go to the Username Box when clicking Tab
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void Unfocus_MouseClick(object sender, EventArgs e)
        {
            this.ActiveControl = loginFormLable;
        }
    }
}
