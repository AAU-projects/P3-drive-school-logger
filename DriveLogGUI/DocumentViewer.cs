using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        private bool _haveDocument = false;
        private string _documentType = string.Empty;
        private string _documentName = string.Empty;

        public void LoadFirstAid(User user)
        {
            SetType(Session.TypeFirstAid);
            LoadDocument(DatabaseParser.GetFirstAid(user));
        }

        public void LoadDoctorsNote(User user)
        {
            SetType(Session.TypeDoctorsNote);
            LoadDocument(DatabaseParser.GetDoctorsNote(user));
        }

        private void LoadDocument(Document document)
        {
            Viewer.Navigate(document.Url);
            Viewer.Show();
            _haveDocument = true;
            TitleLabel.Text = document.Title;
            DateLabel.Text = document.UploadDate.ToShortDateString();
            DateLabel.Location = new Point(TitleLabel.Width + TitleLabel.Location.X + 5, DateLabel.Location.Y);

        }

        public void Clear()
        {
            _haveDocument = false;
            Viewer.Hide();
            TitleLabel.Text = "No Document";
            DateLabel.Text = "";
        }

        public void SetType(string type)
        {
            _documentType = type;
            _documentName = $"{Session.LoggedInUser.Fullname} - {_documentType}";
        }

        private void UpdateViewer()
        {
            LoadFirstAid(Session.LoggedInUser);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (_haveDocument)
            {
                LoadFirstAid(Session.LoggedInUser);
            }
            else
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = "E:\\Dokumenter";
                fileDialog.Filter = "Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PDF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PDF";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    IUploadHandler uploader = new UploadHandler();

                    if (fileDialog.CheckFileExists)
                    {
                        if (_documentType == Session.TypeFirstAid)
                        {
                            if (uploader.UploadFirstAid(_documentName, fileDialog.FileName,
                                Properties.Settings.Default["DocumentUpload"].ToString()))
                            {
                                UpdateViewer();
                            }
                            else
                            {
                                TitleLabel.Text = "Nope";
                            }
                        }
                    }
                }

            }
        }
    }
}
