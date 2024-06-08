using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZKWMDotNetCore.Shared;
using ZKWMDotNetCore.WinFormsApp.Models;

namespace ZKWMDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;

        public FrmBlogList()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(Queries.BlogQuery.BlogList).ToList();
            dgv.DataSource = lst;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var blogId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);

            #region If Case

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmNewBlog frmNewBlog = new FrmNewBlog(blogId);
                frmNewBlog.ShowDialog();

                BlogList();
            }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;

                DeleteBlog(blogId);
            }

            #endregion

            #region Switch Case

            int index = e.ColumnIndex;
            EnumFormControlType enumFormControlType = (EnumFormControlType)index;
            switch (enumFormControlType)
            {
                case EnumFormControlType.Edit:
                    FrmNewBlog frmNewBlog = new FrmNewBlog(blogId);
                    frmNewBlog.ShowDialog();
                    BlogList();
                    break;
                case EnumFormControlType.Delete:
                    var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;
                    DeleteBlog(blogId);
                    break;
                case EnumFormControlType.None:
                default:
                    MessageBox.Show("Invalid Case");
                    break;
            }

            #endregion
        }

        private void DeleteBlog(int id)
        {
            var result = _dapperService.Execute(Queries.BlogQuery.BlogDelete, new BlogModel { BlogId = id });
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
