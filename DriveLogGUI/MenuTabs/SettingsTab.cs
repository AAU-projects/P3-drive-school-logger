using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DriveLogCode.Objects;

namespace DriveLogGUI.MenuTabs
{
    public partial class SettingsTab : UserControl
    {
        private TemplateCreator _lessonCreator;
        private UserControl _currentPage;

        private bool _slidePage;
        private int _slideMovement = -1;
        
        public SettingsTab()
        {
            InitializeComponent();
            InitializeCommen();
            if (Session.LoggedInUser.Sysmin)
            {
                InitializeAdmin();
            }
            else
            {
                templateButton.Hide();
            }
        }

        private void InitializeCommen()
        {
            
        }

        private void InitializeAdmin()
        {
            // Create new instance and set parrent
            _lessonCreator = new TemplateCreator {Parent = this};

            // Subscribe to events
            _lessonCreator.ActivateSlide += SlidePage;

            // Set start location
            _lessonCreator.Location = new Point(sidePanel.Width,0);

            // Add to from controles
            this.Controls.Add(_lessonCreator);

            // Hide the instance
            _lessonCreator.Hide();

            // Bring to front
            _lessonCreator.BringToFront();
        }

        private void OpenPage(UserControl page)
        {
            if (_currentPage != page)
            {
                ClosePage();
                _currentPage = page;
                page.Show();
            }
        }

        private void ClosePage()
        {
            _currentPage?.Hide();
        }

        public void SlidePage()
        {
            _slidePage = true;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_slidePage) return;

            _currentPage.Location = new Point(_currentPage.Location.X + _slideMovement, _currentPage.Location.Y);
            if (_currentPage.Location.X <= 0 || _currentPage.Location.X >= sidePanel.Width)
            {
                _slidePage = false;
                _slideMovement = -_slideMovement;
            }
            else
            {
                Thread.Sleep(2);
                this.Invalidate();
            }
        }

        private void templateButton_Click(object sender, EventArgs e)
        {
            OpenPage(_lessonCreator);
        }
    }
}
