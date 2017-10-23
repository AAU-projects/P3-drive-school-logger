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
            mainOverviewTab.DrawItem += new DrawItemEventHandler(tabControlDrawHorizontalText_DrawItem);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
        }


        private void tabControlDrawHorizontalText_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = mainOverviewTab.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = mainOverviewTab.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Text color and background color
                SolidBrush textcolor = new SolidBrush(Color.Black);
                Brush backgroundcolor = Brushes.CornflowerBlue;

                _textBrush = textcolor;
                g.FillRectangle(backgroundcolor, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)12.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Owner.Visible)
            {
                this.Dispose();
            }
            else if (!Owner.Visible)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }
    }
}
