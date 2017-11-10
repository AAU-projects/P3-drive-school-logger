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
using Spire.Pdf;

namespace DriveLogGUI
{
    public partial class DocumentViewer : UserControl
    {
        public DocumentViewer()
        {
            InitializeComponent();
        }

        private bool HaveDocument()
        {
            return true;
        }

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

        private void LoadDocument(string documentPath)
        {
            viewer.LoadFromFile(documentPath);
            DateLabel.Location = new Point(TitleLabel.Width + TitleLabel.Location.X + 5, DateLabel.Location.Y);

        }

        public void SetType(string type)
        {
            _documentType = type;
            _documentName = $"{Session.LoggedInUser.Fullname} - {_documentType}";
        }

        private void OpenFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "E:\\Dokumenter";
            fileDialog.Filter = "Files(*.BMP;*.JPG;*.JPEG;*.PDF)|*.BMP;*.JPG;*.JPEG;*.PDF";

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
                            LoadFirstAid(Session.LoggedInUser);
                        }
                        else
                        {
                            CustomMsgBox.Show("Unable to upload document", "Error", CustomMsgBoxIcon.Error);
                        }
                    }
                    else if (_documentType == Session.TypeDoctorsNote)
                    {
                        if (uploader.UploadDoctorsNote(_documentName, fileDialog.FileName,
                            Properties.Settings.Default["DocumentUpload"].ToString()))
                        {
                            LoadDoctorsNote(Session.LoggedInUser);
                        }
                        else
                        {
                            CustomMsgBox.Show("Unable to upload document", "Error", CustomMsgBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    CustomMsgBox.Show("File does not exist", "Warrning!", CustomMsgBoxIcon.Warrning);
                }
            }
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }
    }
}
