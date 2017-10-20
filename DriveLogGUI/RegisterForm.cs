﻿using System;
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

        private void registerEmailBox_Leave(object sender, EventArgs e)
        {
            //Check if email is unique in SQL - Error message: Email taken!

            if (RegisterVerification.EmailVerification(registerEmailBox.Text))
            {
                registerEmailBox.BackColor = Color.Chartreuse;
                isEmailOk = true;
            }
            else
            {
                registerEmailBox.BackColor = Color.Crimson;
                isEmailOk = false;
            }
        }
    }
}
