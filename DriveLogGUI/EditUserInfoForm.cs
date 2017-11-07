using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class EditUserInfoForm : Form
    {
        private User user = Session.LoggedInUser;
        public EditUserInfoForm()
        {
            InitializeComponent();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            usernameBox.Text = user.Username;
            firstnameBox.Text = user.Firstname;
            lastnameBox.Text = user.Lastname;
            phoneBox.Text = user.Phone;
            emailBox.Text = user.Email;
            addressBox.Text = user.Address;
            zipBox.Text = user.Zip;
            cityBox.Text = user.City;

            if (!string.IsNullOrEmpty(user.PicturePath) || user.PicturePath != "")
            {
                pictureBox.Load(user.PicturePath);
            }
        }

        private void verifyPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (verifyPasswordBox.Text != verifyPasswordBox.defaultText)
                verifyPasswordBox.PasswordChar = '*';
            else
                verifyPasswordBox.PasswordChar = '\0';

            if (verifyPasswordBox.Text == user.Password)
                ChangeEnableStatus(true);
            else
                ChangeEnableStatus(false);
        }

        private void ChangeEnableStatus(bool enabled)
        {
            usernameBox.ReadOnly = !enabled;
            editPasswordBox.ReadOnly = !enabled;
            verifyEditPasswordBox.ReadOnly = !enabled;
            firstnameBox.ReadOnly = !enabled;
            lastnameBox.ReadOnly = !enabled;
            phoneBox.ReadOnly = !enabled;
            emailBox.ReadOnly = !enabled;
            addressBox.ReadOnly = !enabled;
            zipBox.ReadOnly = !enabled;
            cityBox.ReadOnly = !enabled;

            editPictureButton.Enabled = enabled;
            saveChangesButton.Enabled = enabled;
        }
    }
}
