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
    public partial class DocumentViewer : UserControl
    {
        public DocumentViewer()
        {
            InitializeComponent();
        }

        public void LoadFirstAid(User user)
        {
            LoadDocument(DatabaseParser.GetFirstAid(user));
        }

        public void LoadDoctorsNote(User user)
        {
            LoadDocument(DatabaseParser.GetDoctorsNote(user));
        }

        private void LoadDocument(Document document)
        {
            Viewer.Url = document.Uri;
            TitleLabel.Text = document.Title;
            DateLabel.Text = document.UploadDate.ToShortDateString();
        }
    }
}
