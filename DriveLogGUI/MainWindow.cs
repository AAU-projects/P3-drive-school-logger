using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            OverviewForm overviewTab = new OverviewForm();
            overviewTab.MdiParent = this;

            overviewTab.FormBorderStyle = FormBorderStyle.None;
            overviewTab.StartPosition = FormStartPosition.Manual;
            overviewTab.Left = mainSidebar.Size.Width;

            overviewTab.Show();
        }
    }
}
