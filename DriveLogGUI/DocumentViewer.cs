using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
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

        private bool _haveDocument = false;

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
            Viewer.Show();
            _haveDocument = true;
            TitleLabel.Text = document.Title;
            DateLabel.Text = document.UploadDate.ToShortDateString();
        }

        public void Clear()
        {
            Viewer.Hide();
            _haveDocument = false;
            TitleLabel.Text = "No Document";
            DateLabel.Text = "";
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (_haveDocument)
            {
                
            }
            else
            {
                Image file;

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PDF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PDF";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        using (Stream reader = fileDialog.OpenFile())
                        {
                            file = new Bitmap(reader);
                        }

                        UploadHandler uploader = new UploadHandler();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }

            }
        }
    }
}
