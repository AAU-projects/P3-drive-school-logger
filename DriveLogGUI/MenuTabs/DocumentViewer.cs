using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;
using Spire.Pdf;
using Spire.PdfViewer.Forms;
using System.Linq;

namespace DriveLogGUI.MenuTabs
{
    public partial class DocumentViewer : UserControl
    {
        public DocumentViewer()
        {
            InitializeComponent();
            if (Session.LoggedInUser.Sysmin)
            {
                backButton.Visible = true;
                backButton.Enabled = true;
            }
        }

        private string _documentType = string.Empty;
        private string _documentName = string.Empty;


        /// <summary>
        /// Method to load the first aid document for the user
        /// </summary>
        /// <param name="user">This is the user that the first aid document will be loaded from</param>
        public void LoadFirstAid(User user)
        {
            SetType(Session.TypeFirstAid);
            LoadDocument(DatabaseParser.GetFirstAid(user));
        }

        /// <summary>
        /// Method to load the doctors note document for the user
        /// </summary>
        /// <param name="user">This is the user that the doctors note document will be loaded from</param>
        public void LoadDoctorsNote(User user)
        {
            SetType(Session.TypeDoctorsNote);
            string notePath = DatabaseParser.GetDoctorsNote(user);
            if (!String.IsNullOrEmpty(notePath))
                LoadDocument(notePath);
        }

        /// <summary>
        /// Method to load a document from a documentpath
        /// </summary>
        /// <param name="documentPath">The path to the pdf document</param>
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

        /// <summary>
        /// Method to display a title depending on the type
        /// </summary>
        /// <param name="type">The document type</param>
        public void SetType(string type)
        {
            ClearDocument();
            _documentType = type;
            if(type == Session.TypeDoctorsNote)
                _documentName = $"{Session.LoggedInUser.Fullname} - Doctors Note";
            else if (type == Session.TypeFirstAid)
                _documentName = $"{Session.LoggedInUser.Fullname} - First Aid";

        }

        /// <summary>
        /// Method to clear the documents from the viewer
        /// </summary>
        private void ClearDocument()
        {
            viewer.CloseDocument();
            TitleLabel.Text = "No Document";
            DateLabel.Text = string.Empty;
        }

        /// <summary>
        /// Method to Open a file dialog which can take a pdf or image file and upload it to the database.
        /// </summary>
        private void OpenFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                            CustomMsgBox.ShowOk("Unable to upload document", "Error", CustomMsgBoxIcon.Error);
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
                            CustomMsgBox.ShowOk("Unable to upload document", "Error", CustomMsgBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    CustomMsgBox.ShowOk("File does not exist", "Warrning!", CustomMsgBoxIcon.Warrning);
                }
            }
        }

        /// <summary>
        /// Method to open the file dialog
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        /// <summary>
        /// This method disposes the current viewed pdf
        /// </summary>
        internal void DisposePdf()
        {
            viewer.Dispose();
        }

        /// <summary>
        /// Method for when the visiblie have been changed that the document clears
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void DocumentViewer_VisibleChanged(object sender, EventArgs e)
        {
            ClearDocument();
        }

        /// <summary>
        /// Method for going back from the documentviewer
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Find("StudentProfileTab", true).Last().Show();
            DisposePdf();
            this.Dispose();
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
