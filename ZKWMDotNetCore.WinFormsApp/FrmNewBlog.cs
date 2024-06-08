using ZKWMDotNetCore.Shared;
using ZKWMDotNetCore.WinFormsApp.Models;
using ZKWMDotNetCore.WinFormsApp.Queries;

namespace ZKWMDotNetCore.WinFormsApp
{
    public partial class FrmNewBlog : Form
    {
        private readonly DapperService _dapperService;
        private readonly int _blogId;
        public FrmNewBlog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        public FrmNewBlog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);

            var model = _dapperService.QueryFirstOrDefault<BlogModel>(Queries.BlogQuery.BlogEdit, new { BlogId = _blogId });

            txtTitle.Text = model.BlogTitle;
            txtAuthor.Text = model.BlogAuthor;
            txtContent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }

        private void FrmNewBlog_Load(object sender, EventArgs e)
        {
            txtTitle.Select();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text.Trim();

                int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
                string message = result > 0 ? "Saving Successful." : "Saving Failed.";

                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);

                if (result > 0)
                    ClearControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogId = _blogId,
                    BlogTitle = txtTitle.Text.Trim(),
                    BlogAuthor = txtAuthor.Text.Trim(),
                    BlogContent = txtContent.Text.Trim()
                };

                var result = _dapperService.Execute(Queries.BlogQuery.BlogUpdate,item);
                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                MessageBox.Show(message);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
