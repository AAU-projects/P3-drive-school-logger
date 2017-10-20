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
                registerUsernameBox.BackColor = Color.Chartreuse;
                isUsernameOk = true;
            }
            else
            {
                registerUsernameBox.BackColor = Color.Crimson;
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
    }
}