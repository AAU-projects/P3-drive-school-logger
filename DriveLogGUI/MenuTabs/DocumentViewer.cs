using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;
using Spire.Pdf;
using Spire.PdfViewer.Forms;

namespace DriveLogGUI.MenuTabs
{
    public partial class DocumentViewer : UserControl
    {
        public DocumentViewer()
        {
            InitializeComponent();
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
            PdfDocument document = new PdfDocument(documentPath);
            TitleLabel.Text = document.DocumentInformation.Title;
            DateLabel.Text = document.DocumentInformation.CreationDate.ToString(CultureInfo.InvariantCulture);
            document.Dispose();
            viewer.LoadFromFile(documentPath);
            viewer.SetZoom(ZoomMode.FitWidth);
            DateLabel.Location = new Point(TitleLabel.Width + TitleLabel.Location.X + 5, DateLabel.Location.Y);

        }

        public void SetType(string type)
        {
            ClearDocument();
            _documentType = type;
            _documentName = $"{Session.LoggedInUser.Fullname} - {_documentType}";
        }

        private void ClearDocument()
        {
            viewer.CloseDocument();
            TitleLabel.Text = "No Document";
            DateLabel.Text = string.Empty;
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

        internal void DisposePdf()
        {
            viewer.Dispose();
        }

        private void DocumentViewer_VisibleChanged(object sender, EventArgs e)
        {
            ClearDocument();
        }
    }
}
