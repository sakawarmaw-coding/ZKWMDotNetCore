using ZKWMDotNetCore.Shared;

namespace ZKWMDotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Select();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string query = $"SELECT * FROM Tbl_User where Email = '{txtEmail.Text.Trim()}' and Password ='{txtPassword.Text.Trim()}' ";
            string query = $"SELECT * FROM Tbl_User where Email = @Email and Password = @Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });

            if (model is null)
            {
                MessageBox.Show("User doesn't exist.");
                return;
            }

            MessageBox.Show("Is Admin :" + model.Email);
        }

    }

    public class UserModel 
    { 
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }

}
