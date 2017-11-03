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

        private Color correctColor = Color.FromArgb(109, 144, 150);
        private Color wrongColor = Color.FromArgb(229, 187, 191);
        private Color neutralColor = Color.FromArgb(200, 212, 225);
        private Color whitetextColor = Color.FromArgb(251, 251, 251);

        private LoginForm _loginForm;

        private Point lastClick;

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

        private void registerUsernameBox_Leave(object sender, EventArgs e)
        {
            //Check if username is unique in SQL - Error message: Username taken!
            bool verify = RegisterVerification.UsernameVerifacation(registerUsernameBox.Text);

            ChangeBackColorTextBox(registerUsernameBox, verify);
            isUsernameOk = verify;
        }

        private void registerFirstnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerFirstnameBox.Text);

            ChangeBackColorTextBox(registerFirstnameBox, verify);
            isFirstnameOk = verify;
        }

        private void registerLastnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerLastnameBox.Text);

            ChangeBackColorTextBox(registerLastnameBox, verify);
            isLastnameOk = verify;
        }

        private void registerCityBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.CityVerification(registerCityBox.Text);

            ChangeBackColorTextBox(registerCityBox, verify);
            isCityOk = verify;
        }

        private void registerAdressBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.AdressVerification(registerAdressBox.Text);

            ChangeBackColorTextBox(registerAdressBox, verify);
            isAdressOk = verify;
        }

        private void registerEmailBox_Leave(object sender, EventArgs e)
        {
            //Check if email is unique in SQL - Error message: Email taken!
            bool verify = RegisterVerification.EmailVerification(registerEmailBox.Text);

            ChangeBackColorTextBox(registerEmailBox, verify);
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

            ChangeBackColorTextBox(registerCprBox, verify);
            isCPROk = verify;
        }

        private void registerPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (registerPasswordBox.Text != registerPasswordBox.defaultText)
                registerPasswordBox.PasswordChar = '*';
            else
                registerPasswordBox.PasswordChar = '\0';

            bool usernameNotSameAsPassword = registerPasswordBox.Text != registerUsernameBox.Text;
            bool verify = RegisterVerification.PasswordVertification(registerPasswordBox.Text) && usernameNotSameAsPassword;

            ChangeBackColorTextBox(registerPasswordBox, verify);
            isPasswordOk = verify;

            VertifyPassword();

            if (!usernameNotSameAsPassword)
            {
                passwordStatusLabel.Text = "Password can not be the same as your username";
                passwordStatusLabel.ForeColor = wrongColor;
            }
            else
            {
                int strength = RegisterVerification.PasswordStrength(registerPasswordBox.Text);

                if (strength == 0)
                    passwordStatusLabel.Text = "";
                else if (strength < 12)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Weak", wrongColor);
                else if (strength < 22)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Medium", Color.FromArgb(229, 200, 3));
                else
                    ChangeLabelTextAndColor(passwordStatusLabel, "Strong", correctColor);
            }
        }

        private void verifyPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (verifyPasswordBox.Text != verifyPasswordBox.defaultText)
                verifyPasswordBox.PasswordChar = '*';
            else
                verifyPasswordBox.PasswordChar = '\0';

            VertifyPassword();
        }

        private void VertifyPassword()
        {
            bool verify = registerPasswordBox.Text == verifyPasswordBox.Text && registerPasswordBox.Text.Length != 0;

            ChangeBackColorTextBox(verifyPasswordBox, verify);
            isVerifyPasswordOk = verify;
        }

        private void registerZipBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.ZipVerifacation(registerZipBox.Text);

            ChangeBackColorTextBox(registerZipBox, verify);
            isZipOk = verify;

            if (verify)
            {
                registerCityBox.Text = JSONReader.GetCity(int.Parse(registerZipBox.Text));
            }
        }

        private void registerPhoneBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.PhoneVerifacation(registerPhoneBox.Text);

            ChangeBackColorTextBox(registerPhoneBox, verify);
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

        private void ChangeBackColorTextBox(TextboxBorderColor textBox, bool verify)
        {
            if (textBox.Text == textBox.defaultText)
            {
                textBox.BackColor = neutralColor;
                textBox.ForeColor = Color.Black;
            }
                

            if (verify && textBox.Text != textBox.defaultText)
            {
                textBox.BackColor = correctColor;
                textBox.ForeColor = whitetextColor;
            }
                

            else if (textBox.Text != textBox.defaultText && textBox.Text != textBox.defaultText)
            {
                textBox.BackColor = wrongColor;
                textBox.ForeColor = Color.Black;
            }
                
        }


        private void registerCreateNewUserButton_Click(object sender, EventArgs e)
        {
            if (isFirstnameOk && isLastnameOk && isPhoneOk && isEmailOk && isCPROk && isAdressOk &&
                isCityOk && isZipOk && isUsernameOk && isPasswordOk && isVerifyPasswordOk)
            {
                bool UserCreated = MySql.AddUser(registerFirstnameBox.Text, registerLastnameBox.Text,
                    registerPhoneBox.Text, registerEmailBox.Text,
                    registerCprBox.Text, registerAdressBox.Text, registerZipBox.Text, registerCityBox.Text,
                    registerUsernameBox.Text, registerPasswordBox.Text);

                if (UserCreated)
                {
                    MessageBox.Show("You have succesfully created a user", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Dispose();
                    _loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Failed to create new user, please try again later!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            UploadProfilePicForm uploadPictureForm = new UploadProfilePicForm(this);
            this.Hide();
            uploadPictureForm.ShowDialog();
            /*
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
            */
        }

        private void registerPicture_Click(object sender, EventArgs e)
        {

        }

        private void registerCityBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HideAllStatusLabels()
        {
            passwordStatusLabel.Text = null;
            vertifyPasswordStatusLabel.Text = null;
        }

        private void registerFirstnameBox_Click(object sender, EventArgs e)
        {
            if (registerFirstnameBox.Text == "Firstname")
                registerFirstnameBox.Text = "";
            
        }

        private void registerLastnameBox_Click(object sender, EventArgs e)
        {
            if (registerLastnameBox.Text == "Lastname")
                registerLastnameBox.Text = "";
        }

        private void registerPhoneBox_Click(object sender, EventArgs e)
        {
            if (registerPhoneBox.Text == "Phone Number")
                registerPhoneBox.Text = "";
        }

        private void registerCprBox_Click(object sender, EventArgs e)
        {
            if (registerCprBox.Text == "CPR")
                registerCprBox.Text = "";
        }

        private void registerEmailBox_Click(object sender, EventArgs e)
        {
            if (registerEmailBox.Text == "Email Address")
                registerEmailBox.Text = "";
        }

        private void registerAdressBox_Click(object sender, EventArgs e)
        {
            if (registerAdressBox.Text == "Address")
                registerAdressBox.Text = "";
        }

        private void registerZipBox_Click(object sender, EventArgs e)
        {
            if (registerZipBox.Text == "Zip Code")
                registerZipBox.Text = "";
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void registerCityBox_Click(object sender, EventArgs e)
        {
            if (registerCityBox.Text == "City")
                registerCityBox.Text = "";
        }

        private void registerUsernameBox_Click(object sender, EventArgs e)
        {
            if (registerUsernameBox.Text == "Username")
                registerUsernameBox.Text = "";
        }

        private void registerPasswordBox_Click(object sender, EventArgs e)
        {
            if (registerPasswordBox.Text == "Password")
                registerPasswordBox.Text = "";
        }

        private void verifyPasswordBox_Click(object sender, EventArgs e)
        {
            if (verifyPasswordBox.Text == "Verify Password")
                verifyPasswordBox.Text = "";
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}