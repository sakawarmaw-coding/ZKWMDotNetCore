using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZKWMDotNetCore.WinFormsApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void newBLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewBlog frm = new FrmNewBlog();
            frm.ShowDialog();
        }

        private void blogListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlogList frm = new FrmBlogList();
            frm.ShowDialog();
        }
    }
}
