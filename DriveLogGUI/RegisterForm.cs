using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class RegisterForm : Form
    {
        private bool isUsernameOk;
        private bool isPasswordOk;
        private bool isVerifyPasswordOk;
        private bool isFirstnameOk;
        private bool isLastnameOk;
        private bool isPhoneOk;
        private bool isEmailOk;
        private bool isCPROk;
        private bool isAdressOk;
        private bool isCityOk;
        private bool isZipOk;

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

        private void registerUsernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void registerUsernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerUsernameBox_Leave(object sender, EventArgs e)
        {
            //Check if username is unique in SQL - Error message: Username taken!

            if (RegisterVerification.UsernameVerifacation(registerUsernameBox.Text))
            {
                registerUsernameBox.BorderColor = Color.GreenYellow;
                isUsernameOk = true;
            }
            else
            {
                registerUsernameBox.BorderColor = Color.Crimson;
                isUsernameOk = false;
            }
        }

        private void registerFirstnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerFirstnameBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.InputOnlyLettersVerification(registerFirstnameBox.Text))
            {
                registerFirstnameBox.BackColor = Color.Chartreuse;
                isFirstnameOk = true;
            }
            else
            {
                registerFirstnameBox.BackColor = Color.Crimson;
                isFirstnameOk = false;
            }
        }

        private void registerLastnameBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.InputOnlyLettersVerification(registerLastnameBox.Text))
            {
                registerLastnameBox.BackColor = Color.Chartreuse;
                isLastnameOk = true;
            }
            else
            {
                registerLastnameBox.BackColor = Color.Crimson;
                isLastnameOk = false;
            }
        }

        private void registerCityBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.InputOnlyLettersVerification(registerCityBox.Text))
            {
                registerCityBox.BackColor = Color.Chartreuse;
                isCityOk = true;
            }
            else
            {
                registerCityBox.BackColor = Color.Crimson;
                isCityOk = false;
            }
        }

        private void registerAdressBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.AdressVerification(registerAdressBox.Text))
            {
                registerAdressBox.BackColor = Color.Chartreuse;
                isAdressOk = true;
            }
            else
            {
                registerAdressBox.BackColor = Color.Crimson;
                isAdressOk = false;
            }
        }

        private void registerEmailBox_Leave(object sender, EventArgs e)
        {
            //Check if email is unique in SQL - Error message: Email taken!

            if (RegisterVerification.EmailVerification(registerEmailBox.Text))
            {
                registerEmailBox.BorderColor = Color.Chartreuse;
                isEmailOk = true;
            }
            else
            {
                registerEmailBox.BorderColor = Color.Crimson;
                isEmailOk = false;
            }
        }

        /// <summary>
        /// Verification function for the Register CPR input
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The Event args</param>
        private void registerCprBox_Leave(object sender, EventArgs e)
        {
            //Check if CPR is already in SQL - Error message: CPR already exists!

            if (RegisterVerification.CPRVerification(registerCprBox.Text))
            {
                registerCprBox.BackColor = Color.Chartreuse;
                isCPROk = true;
            }
            else
            {
                registerCprBox.BackColor = Color.Crimson;
                isCPROk = false;
            }
        }

        private void registerZipBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.ZipVerifacation(registerZipBox.Text))
            {
                registerZipBox.BorderColor = Color.Chartreuse;
                isZipOk = true;
            }
            else
            {
                registerZipBox.BorderColor = Color.Crimson;
                isZipOk = false;
            }
        }

        private void registerPhoneBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.PhoneVerifacation(registerPhoneBox.Text))
            {
                registerPhoneBox.BorderColor = Color.Chartreuse;
                isPhoneOk = true;
            }
            else
            {
                registerPhoneBox.BorderColor = Color.Crimson;
                isPhoneOk = false;
            }
        }
    }

}