using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DriveLogCode;
using System.Linq;
using System.Threading.Tasks;

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

        private void registerUsernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerUsernameBox_Leave(object sender, EventArgs e)
        {
            //Check if username is unique in SQL - Error message: Username taken!
            if (RegisterVerification.UsernameVerifacation(registerUsernameBox.Text))
            {
                registerUsernameBox.BorderColor = Color.Chartreuse;
                isUsernameOk = true;
            }
            else
            {
                isUsernameOk = false;
                ChangeBorderColorTextbox(registerUsernameBox);
            }
            
        }

        private void registerFirstnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerFirstnameBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.InputOnlyLettersVerification(registerFirstnameBox.Text))
            {
                registerFirstnameBox.BorderColor = Color.Chartreuse;
                isFirstnameOk = true;
            }
            else
            {
                isFirstnameOk = false;
                ChangeBorderColorTextbox(registerFirstnameBox);
            }
        }

        private void registerLastnameBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.InputOnlyLettersVerification(registerLastnameBox.Text))
            {
                registerLastnameBox.BorderColor = Color.Chartreuse;
                isLastnameOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerLastnameBox);
                isLastnameOk = false;
            }
        }

        private void registerCityBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.CityVerification(registerCityBox.Text))
            {
                registerCityBox.BorderColor = Color.Chartreuse;
                isCityOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerCityBox);
                isCityOk = false;
            }
        }

        private void registerAdressBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.AdressVerification(registerAdressBox.Text))
            {
                registerAdressBox.BorderColor = Color.Chartreuse;
                isAdressOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerAdressBox);
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
                ChangeBorderColorTextbox(registerEmailBox);
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
                registerCprBox.BorderColor = Color.Chartreuse;
                isCPROk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerCprBox);
                isCPROk = false;
            }
        }

        private void registerPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (RegisterVerification.PasswordVertification(registerPasswordBox.Text))
            {
                registerPasswordBox.BorderColor = Color.Chartreuse;
                isPasswordOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerPasswordBox);
                isPasswordOk = false;
            }
            VertifyPassword();

            int strength = RegisterVerification.PasswordStrength(registerPasswordBox.Text);

            if(strength == 0)
                passwordStrengthLabel.Text = "";
            else if (strength < 12)
                ChangeLabelTextAndColor(passwordStrengthLabel, "Weak", Color.Red);
            else if (strength < 22)
                ChangeLabelTextAndColor(passwordStrengthLabel, "Medium", Color.Blue);
            else
                ChangeLabelTextAndColor(passwordStrengthLabel, "Strong", Color.Green);
        }

        private void verifyPasswordBox_TextChanged(object sender, EventArgs e)
        {
            VertifyPassword();
        }

        private void VertifyPassword()
        {
            if (registerPasswordBox.Text == verifyPasswordBox.Text)
            {
                verifyPasswordBox.BorderColor = Color.Chartreuse;
                isVerifyPasswordOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(verifyPasswordBox);
                isVerifyPasswordOk = false;
            }
        }

        private void registerZipBox_Leave(object sender, EventArgs e)
        {
            if (RegisterVerification.ZipVerifacation(registerZipBox.Text))
            {
                registerCityBox.Text = JSONReader.GetCity(int.Parse(registerZipBox.Text));
                registerZipBox.BorderColor = Color.Chartreuse;
                isZipOk = true;
            }
            else
            {
                ChangeBorderColorTextbox(registerZipBox);
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
                ChangeBorderColorTextbox(registerPhoneBox);

                isPhoneOk = false;
            }
        }


        private void ChangeBorderColorTextbox(TextboxBorderColor textbox)
        {
            if (textbox.Text.Length == 0)
            {
                textbox.BorderColor = Color.Blue;
            }
            else
            {
                textbox.BorderColor = Color.Crimson;
            }
        }

        private void registerCreateNewUserButton_Click(object sender, EventArgs e)
        {
            if (isFirstnameOk && isLastnameOk && isPhoneOk && isEmailOk && isCPROk && isAdressOk &&
                isCityOk && isZipOk && isUsernameOk && isPasswordOk && isVerifyPasswordOk)
            {
                //Opret en ny bruger i databasen
                MessageBox.Show("You have succesfully crated a user");
                this.Dispose();
                _loginForm.Show();
            }
            else
            {
                foreach (TextboxBorderColor tb in this.Controls.OfType<TextboxBorderColor>())
                {
                    if (string.IsNullOrEmpty(tb.Text))
                        tb.BorderColor = Color.Crimson;
                }
            }
        }

        private void ChangeLabelTextAndColor(Label label, string text, Color color)
        {
            label.Text = text;
            label.ForeColor = color;
        }

        private void registerCityBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}