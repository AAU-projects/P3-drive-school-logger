using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class UserSearchTab : UserControl
    {
        public UserSearchTab()
        {
            InitializeComponent();
        }

        private List<User> _usersFoundList = new List<User>();
        private List<Panel> _userPanelList = new List<Panel>();

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            _usersFoundList = DatabaseParser.UserSearchList(searchBox.Text);

            _userPanelList.Clear();
            resultsPanel.Controls.Clear();

            for (int i = 0; i < _usersFoundList.Count; i++)
            {
               GenerateUserPanel(_usersFoundList[i], i);
            }

            foreach (Panel panel in _userPanelList)
            {
                resultsPanel.Controls.Add(panel);
            }
        }

        private void GenerateUserPanel(User user, int index)
        {
            Panel tempPanel = new Panel();
            tempPanel.Size = new Size(397, 74);
            tempPanel.BackColor = Color.White;

            if (index % 2 == 0)
                tempPanel.Location = new Point(22, 13 + (13 + tempPanel.Height * (index / 2)) * (index / 2));
            else
                tempPanel.Location = new Point(454, 13 + (13 + tempPanel.Height * (index / 2)) * (index / 2));

            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Load(user.PicturePath);
            profilePictureBox.Location = new Point(5,5);
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tempPanel.Controls.Add(profilePictureBox);

            _userPanelList.Add(tempPanel);
        }
    }
}
