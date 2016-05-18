using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerMeetingManageSystemSignInClient
{
    public partial class LoginDatabse : Form
    {
        public LoginDatabse()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
            string serverName = serverNameTextBox.Text;
            string databasename = databaseNameTextBox.Text;
            string user = userTextBox.Text;
            string password = passwordTextBox.Text;

            connectionString = string.Format(connectionString, serverName, databasename, user, password);

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                Configuration.ConnectionString = connectionString;
                Configuration.SqlConnection = sqlConnection;
                (new LoginClient()).Show();
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("连接错误，请检查输入是否正确！！！");
            }
            


        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
