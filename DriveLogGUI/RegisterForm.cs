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

            HideAllStatusLabels();
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
            bool verify = RegisterVerification.UsernameVerifacation(registerUsernameBox.Text);

            ChangeBorderColorTextbox(registerUsernameBox, usernameStatusLabel, verify);
            isUsernameOk = verify;
        }

        private void registerFirstnameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerFirstnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerFirstnameBox.Text);

            ChangeBorderColorTextbox(registerFirstnameBox, firstnameStatusLabel, verify);
            isFirstnameOk = verify;
        }

        private void registerLastnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerLastnameBox.Text);

            ChangeBorderColorTextbox(registerLastnameBox, lastnameStatusLabel, verify);
            isLastnameOk = verify;
        }

        private void registerCityBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.CityVerification(registerCityBox.Text);

            ChangeBorderColorTextbox(registerCityBox, cityStatusLabel, verify);
            isCityOk = verify;
        }

        private void registerAdressBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.AdressVerification(registerAdressBox.Text);

            ChangeBorderColorTextbox(registerAdressBox, adressStatusLabel, verify);
            isAdressOk = verify;
        }

        private void registerEmailBox_Leave(object sender, EventArgs e)
        {
            //Check if email is unique in SQL - Error message: Email taken!
            bool verify = RegisterVerification.EmailVerification(registerEmailBox.Text);

            ChangeBorderColorTextbox(registerEmailBox, emailStatusLabel, verify);
            isEmailOk = verify;
        }

        /// <summary>
        /// Verification function for the Register CPR input
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The Event args</param>
        private void registerCprBox_Leave(object sender, EventArgs e)
        {
            //Check if CPR is already in SQL - Error message: CPR already exists!
            bool verify = RegisterVerification.CPRVerification(registerCprBox.Text);

            ChangeBorderColorTextbox(registerCprBox, CPRStatusLabel, verify);
            isCPROk = verify;
        }

        private void registerPasswordBox_TextChanged(object sender, EventArgs e)
        {
            bool usernameNotSameAsPassword = registerPasswordBox.Text != registerUsernameBox.Text;
            bool verify = RegisterVerification.PasswordVertification(registerPasswordBox.Text) && usernameNotSameAsPassword;

            ChangeBorderColorTextbox(registerPasswordBox, passwordStatusLabel, verify);
            isPasswordOk = verify;

            VertifyPassword();

            if (!usernameNotSameAsPassword)
            {
                passwordStatusLabel.Text = "Password can not be the same as your username";
                passwordStatusLabel.ForeColor = Color.Red;
            }
            else
            {
                int strength = RegisterVerification.PasswordStrength(registerPasswordBox.Text);

                if (strength == 0)
                    passwordStatusLabel.Text = "";
                else if (strength < 12)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Weak", Color.Red);
                else if (strength < 22)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Medium", Color.FromArgb(229, 200, 3));
                else
                    ChangeLabelTextAndColor(passwordStatusLabel, "Strong", Color.Green);
            }
        }

        private void verifyPasswordBox_TextChanged(object sender, EventArgs e)
        {
            VertifyPassword();
        }

        private void VertifyPassword()
        {
            bool verify = registerPasswordBox.Text == verifyPasswordBox.Text && registerPasswordBox.Text.Length != 0;

            ChangeBorderColorTextbox(verifyPasswordBox, vertifyPasswordStatusLabel, verify);
            isVerifyPasswordOk = verify;
        }

        private void registerZipBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.ZipVerifacation(registerZipBox.Text);

            ChangeBorderColorTextbox(registerZipBox, zipcodeStatusLabel, verify);
            isZipOk = verify;

            if (verify)
            {
                registerCityBox.Text = JSONReader.GetCity(int.Parse(registerZipBox.Text));
            }
        }

        private void registerPhoneBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.PhoneVerifacation(registerPhoneBox.Text);

            ChangeBorderColorTextbox(registerPhoneBox, phoneStatusLabel, verify);
            isPhoneOk = verify;
        }


        private void ChangeBorderColorTextbox(TextboxBorderColor textbox, Label status, bool verify)
        {
            if (textbox.Text.Length == 0)
            {
                textbox.BorderColor = Color.Blue;
                status.Text = "";
            }
            else if (verify)
            {
                status.Text = "";
                textbox.BorderColor = Color.LawnGreen;
            }
            else
            {
                
                status.Text = "Invalid";
                status.ForeColor = Color.Crimson;
                textbox.BorderColor = Color.Crimson;
            }
        }


        private void registerCreateNewUserButton_Click(object sender, EventArgs e)
        {
            if (isFirstnameOk && isLastnameOk && isPhoneOk && isEmailOk && isCPROk && isAdressOk &&
                isCityOk && isZipOk && isUsernameOk && isPasswordOk && isVerifyPasswordOk)
            {
                //Opret en ny bruger i databasen
                MessageBox.Show("You have succesfully created a user", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.None);
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
        private void registerUploadPhotoButton_Click(object sender, EventArgs e)
        {
            string imageLocation = string.Empty;

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    registerPicture.ImageLocation = imageLocation;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerPicture_Click(object sender, EventArgs e)
        {

        }

        private void registerCityBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HideAllStatusLabels()
        {
            CPRStatusLabel.Text = null;
            adressStatusLabel.Text = null;
            cityStatusLabel.Text = null;
            emailStatusLabel.Text = null;
            firstnameStatusLabel.Text = null;
            lastnameStatusLabel.Text = null;
            passwordStatusLabel.Text = null;
            phoneStatusLabel.Text = null;
            usernameStatusLabel.Text = null;
            vertifyPasswordStatusLabel.Text = null;
            zipcodeStatusLabel.Text = null;
        }
    }
}