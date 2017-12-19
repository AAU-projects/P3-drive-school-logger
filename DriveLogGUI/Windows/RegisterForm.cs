using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DriveLogCode;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogGUI.CustomControls;

namespace DriveLogGUI.Windows
{
    public partial class RegisterForm : Form
    {
        // Used to check the validity of the different fields.
        private bool _isUsernameOk;
        private bool _isPasswordOk;
        private bool _isVerifyPasswordOk;
        private bool _isFirstnameOk;
        private bool _isLastnameOk;
        private bool _isPhoneOk;
        private bool _isEmailOk;
        private bool _isCprOk;
        private bool _isAdressOk;
        private bool _isCityOk;
        private bool _isZipOk;
        private bool _isSignatureOk;
        private Image _signatureImage = null;

        // A reference to the LoginForm
        private readonly LoginForm _loginForm;

        private Point _lastClick;
        private readonly IUploadHandler _uploader;

        public Image ProfileImage { get; set; } = null;

        /// <summary>
        /// Initializes the RegisterForm and creates a new instance of UploadHandler
        /// </summary>
        /// <param name="login">A reference to the LoginForm</param>
        public RegisterForm(LoginForm login)
        {
            _loginForm = login;
            InitializeComponent();

            HideAllStatusLabels();
            _uploader = new UploadHandler();
        }

        /// <summary>
        /// Returns to the loginform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerCancelHyperLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Show();
            this.Dispose();
        }

        /// <summary>
        /// Returns to the loginform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginForm.Show();
            this.Dispose();
        }

        /// <summary>
        /// Occurs when the user leaves the Username field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerUsernameBox_Leave(object sender, EventArgs e)
        {
            //Check if username is unique in SQL - Error message: Username taken!
            bool verify = RegisterVerification.UsernameVerifacation(registerUsernameBox.Text);

            ChangeBackColorTextBox(registerUsernameBox, verify);
            _isUsernameOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the Firstname field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerFirstnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerFirstnameBox.Text);

            ChangeBackColorTextBox(registerFirstnameBox, verify);
            _isFirstnameOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the Lastname field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerLastnameBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.InputOnlyLettersVerification(registerLastnameBox.Text);

            ChangeBackColorTextBox(registerLastnameBox, verify);
            _isLastnameOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the City field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerCityBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.CityVerification(registerCityBox.Text);

            ChangeBackColorTextBox(registerCityBox, verify);
            _isCityOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the Adress field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerAdressBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.AdressVerification(registerAdressBox.Text);

            ChangeBackColorTextBox(registerAdressBox, verify);
            _isAdressOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the Email field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerEmailBox_Leave(object sender, EventArgs e)
        {
            //Check if email is unique in SQL - Error message: Email taken!
            bool verify = RegisterVerification.EmailVerification(registerEmailBox.Text);

            ChangeBackColorTextBox(registerEmailBox, verify);
            _isEmailOk = verify;
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
            _isCprOk = verify;
        }

        /// <summary>
        /// Occurs when the text in the Password field is changed.
        /// Checks strength and validity of the password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (registerPasswordBox.Text != registerPasswordBox.defaultText)
                registerPasswordBox.PasswordChar = '*';
            else
                registerPasswordBox.PasswordChar = '\0';

            bool usernameNotSameAsPassword = registerPasswordBox.Text != registerUsernameBox.Text;
            bool verify = RegisterVerification.PasswordVertification(registerPasswordBox.Text) && usernameNotSameAsPassword;

            ChangeBackColorTextBox(registerPasswordBox, verify);
            _isPasswordOk = verify;

            VerifyPassword();

            if (!usernameNotSameAsPassword)
            {
                passwordStatusLabel.Text = "Password can not be the same as your username";
                passwordStatusLabel.ForeColor = ColorScheme.MainWarningColor;
            }
            else
            {
                int strength = RegisterVerification.PasswordStrength(registerPasswordBox.Text);

                if (strength == 0)
                    passwordStatusLabel.Text = "";
                else if (strength < 12)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Weak", ColorScheme.MainWarningColor);
                else if (strength < 22)
                    ChangeLabelTextAndColor(passwordStatusLabel, "Medium", Color.FromArgb(229, 200, 3));
                else
                    ChangeLabelTextAndColor(passwordStatusLabel, "Strong", ColorScheme.MainThemeColorLight);
            }
        }

        /// <summary>
        /// When the text changes in the Password field.
        /// Toggles the passwordchar depending on what text is in the field.
        /// Passwordchar is set to * if the text is not the default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verifyPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (verifyPasswordBox.Text != verifyPasswordBox.defaultText)
                verifyPasswordBox.PasswordChar = '*';
            else
                verifyPasswordBox.PasswordChar = '\0';

            VerifyPassword();
        }

        /// <summary>
        /// Verifies the password
        /// </summary>
        private void VerifyPassword()
        {
            bool verify = registerPasswordBox.Text == verifyPasswordBox.Text && registerPasswordBox.Text.Length != 0;

            ChangeBackColorTextBox(verifyPasswordBox, verify);
            _isVerifyPasswordOk = verify;
        }

        /// <summary>
        /// Occurs when the user leaves the Zipcode field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerZipBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.ZipVerifacation(registerZipBox.Text);

            ChangeBackColorTextBox(registerZipBox, verify);
            _isZipOk = verify;

            if (verify)
            {
                registerCityBox.Text = JSONReader.GetCity(int.Parse(registerZipBox.Text));
            }
        }

        /// <summary>
        /// Occurs when the user leaves the Phone field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerPhoneBox_Leave(object sender, EventArgs e)
        {
            bool verify = RegisterVerification.PhoneVerifacation(registerPhoneBox.Text);

            ChangeBackColorTextBox(registerPhoneBox, verify);
            _isPhoneOk = verify;
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

        /// <summary>
        /// Sets the correct backgroundcolor depending on the text.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="verify"></param>
        private void ChangeBackColorTextBox(TextboxBorderColor textBox, bool verify)
        {
            if (textBox.Text == textBox.defaultText)
            {
                textBox.BackColor = ColorScheme.MainNeutralColor;
                textBox.ForeColor = Color.DarkGray;
            }

            if (verify && textBox.Text != textBox.defaultText)
            {
                textBox.BackColor = ColorScheme.MainThemeColorLight;
                textBox.ForeColor = ColorScheme.MainPanelColor;
            }
                

            else if (textBox.Text != textBox.defaultText && textBox.Text != textBox.defaultText)
            {
                textBox.BackColor = ColorScheme.MainWarningColor;
                textBox.ForeColor = Color.Black;
            }
                
        }

        /// <summary>
        /// Registers the given user in the system, if all fields are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerCreateNewUserButton_Click(object sender, EventArgs e)
        {
            if (_isFirstnameOk && _isLastnameOk && _isPhoneOk && _isEmailOk && _isCprOk && _isAdressOk &&
                _isCityOk && _isZipOk && _isUsernameOk && _isPasswordOk && _isVerifyPasswordOk && _isSignatureOk)
            {
                
                bool UserCreated = DatabaseParser.AddUser(registerFirstnameBox.Text, registerLastnameBox.Text,
                    registerPhoneBox.Text, registerEmailBox.Text,
                    registerCprBox.Text, registerAdressBox.Text, registerZipBox.Text, registerCityBox.Text,
                    registerUsernameBox.Text, registerPasswordBox.Text, _uploader.SaveProfilePicture(ProfileImage, Properties.Settings.Default["PictureUpload"].ToString()), 
                    _uploader.SavePicture(_signatureImage, Properties.Settings.Default["PictureUpload"].ToString()));

                if (UserCreated)
                {
                    CustomMsgBox.ShowOk("You have succesfully created a user", "Sucess", CustomMsgBoxIcon.Complete);
                    this.Dispose();
                    _loginForm.Show();
                }
                else
                {
                    CustomMsgBox.ShowOk("Failed to create new user, please try again later!", "Failed",
                        CustomMsgBoxIcon.Error);
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

        /// <summary>
        /// Changes the text and color of a label.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        private void ChangeLabelTextAndColor(Label label, string text, Color color)
        {
            label.Text = text;
            label.ForeColor = color;
        }

        /// <summary>
        /// Opens the UploadProfilePicForm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerUploadPhotoButton_Click(object sender, EventArgs e)
        {
            UploadProfilePicForm uploadPictureForm = new UploadProfilePicForm(this);
            this.Hide();
            uploadPictureForm.ShowDialog();
            registerPicture.Image = ProfileImage;
        }

        /// <summary>
        /// Hides akk the status labels of the form.
        /// </summary>
        private void HideAllStatusLabels()
        {
            passwordStatusLabel.Text = null;
            vertifyPasswordStatusLabel.Text = null;
        }

        /// <summary>
        /// The click function for the Firstname textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerFirstnameBox_Click(object sender, EventArgs e)
        {
            if (registerFirstnameBox.Text == "Firstname")
                registerFirstnameBox.Text = "";
            
        }

        /// <summary>
        /// The click function for the Lastname textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerLastnameBox_Click(object sender, EventArgs e)
        {
            if (registerLastnameBox.Text == "Lastname")
                registerLastnameBox.Text = "";
        }

        /// <summary>
        /// The click function for the Phone textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerPhoneBox_Click(object sender, EventArgs e)
        {
            if (registerPhoneBox.Text == "Phone Number")
                registerPhoneBox.Text = "";
        }

        /// <summary>
        /// The click function for the CPR textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerCprBox_Click(object sender, EventArgs e)
        {
            if (registerCprBox.Text == "CPR")
                registerCprBox.Text = "";
        }

        /// <summary>
        /// The click function for the Email textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerEmailBox_Click(object sender, EventArgs e)
        {
            if (registerEmailBox.Text == "Email Address")
                registerEmailBox.Text = "";
        }

        /// <summary>
        /// The click function for the Adress textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerAdressBox_Click(object sender, EventArgs e)
        {
            if (registerAdressBox.Text == "Address")
                registerAdressBox.Text = "";
        }

        /// <summary>
        /// The click function for the Zipcode textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerZipBox_Click(object sender, EventArgs e)
        {
            if (registerZipBox.Text == "Zip Code")
                registerZipBox.Text = "";
        }

        /// <summary>
        /// The click function for the City textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerCityBox_Click(object sender, EventArgs e)
        {
            if (registerCityBox.Text == "City")
                registerCityBox.Text = "";
        }

        /// <summary>
        /// The click function for the Username textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerUsernameBox_Click(object sender, EventArgs e)
        {
            if (registerUsernameBox.Text == "Username")
                registerUsernameBox.Text = "";
        }

        /// <summary>
        /// The click function for the Password textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerPasswordBox_Click(object sender, EventArgs e)
        {
            if (registerPasswordBox.Text == "Password")
                registerPasswordBox.Text = "";
        }

        /// <summary>
        /// The click function for the Verfy Password textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void verifyPasswordBox_Click(object sender, EventArgs e)
        {
            if (verifyPasswordBox.Text == "Verify Password")
                verifyPasswordBox.Text = "";
        }

        /// <summary>
        /// The click function for the statusbar minimize button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// The click function for the statusbar close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// When the user holds down the mouse button, while hovering above the statusbar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        /// <summary>
        /// When the user hovers the mouse cursor above the statusbar.
        /// Allows the users to drag the statusbar around.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        /// <summary>
        /// The click function for the signature button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signatureButton_Click(object sender, EventArgs e)
        {
            SignatureEdit signatureEditForm = new SignatureEdit();

            signatureEditForm.ShowDialog();
            _signatureImage = signatureEditForm.SignatureImage;
            if (_signatureImage != null)
                _isSignatureOk = true;
            signatureEditForm.Dispose();
            signatureBox.Image = _signatureImage;
        }

        /// <summary>
        /// The paint function for the statusbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topBarPanel_Paint(object sender, PaintEventArgs e)
        {
            topBarPanel.BackColor = ColorScheme.MainTopPanelColor;
        }
    }
}