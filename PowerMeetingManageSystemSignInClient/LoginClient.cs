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
    public partial class LoginClient : Form
    {
        public LoginClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = Configuration.SqlConnection;
            SqlCommand getUserAndPassword = new SqlCommand();
            getUserAndPassword.Connection = sqlConnection;
            getUserAndPassword.CommandText = "select * from organizer";
            SqlDataReader result = getUserAndPassword.ExecuteReader();
            result.Read();
            string username = result[0].ToString();
            string password = result[1].ToString();

            if(usernameTextBox.Text==username&&passwordTextBox.Text==password)
            {
                MessageBox.Show("登录成功");
                result.Close();
                new SignIn().Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                result.Close();
            }

        }

        private void LoginClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
