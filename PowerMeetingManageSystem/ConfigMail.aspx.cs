using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class ConfigMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand getConfigInfo = new SqlCommand();
            getConfigInfo.Connection = sqlConnection;
            getConfigInfo.CommandText = "select smtp_server, email_user, email_psw, web_address from configuration where config_id = 1";
            SqlDataReader result = getConfigInfo.ExecuteReader();
            result.Read();
            string smtp_server = result[0].ToString();
            string email_user = result[1].ToString();
            string email_psw = result[2].ToString();
            string web_address = result[3].ToString();
            smtpServer.Text = smtp_server;
            emailUser.Text = email_user;
            emailPassword.Text = email_psw;
            if (web_address == "")
            {
                webURL.Text = "http://";
            }
            else
            {
                webURL.Text = web_address;
            }

        }

        protected void saveEmailButton_Click(object sender, EventArgs e)
        {
            string smtp_server = Request.Form["smtpServer"];
            string email_user = Request.Form["emailUser"];
            string email_psw = Request.Form["emailPassword"];
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand updateEmailAccount = new SqlCommand();
            updateEmailAccount.Connection = sqlConnection;
            updateEmailAccount.CommandText = "update configuration set smtp_server = @smtp_server, email_user = @email_user, email_psw = @email_psw where config_id = 1";
            updateEmailAccount.Parameters.Add("@smtp_server", SqlDbType.VarChar).Value = smtp_server;
            updateEmailAccount.Parameters.Add("@email_user", SqlDbType.VarChar).Value = email_user;
            updateEmailAccount.Parameters.Add("@email_psw", SqlDbType.VarChar).Value = email_psw;
            updateEmailAccount.ExecuteNonQuery();
            Response.Write("<script>alert('修改成功!');window.location.href='ConfigMail.aspx'</script>");


        }

        protected void saveURLButton_Click(object sender, EventArgs e)
        {
            string web_address = Request.Form["webURL"];
            if (web_address.EndsWith("/"))
            {
                web_address = web_address.Substring(0, web_address.Length - 1);
            }
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand updateWebAddress = new SqlCommand();
            updateWebAddress.Connection = sqlConnection;
            updateWebAddress.CommandText = "update configuration set web_address = @web_address where config_id = 1";
            updateWebAddress.Parameters.Add("@web_address", SqlDbType.VarChar).Value = web_address;
            updateWebAddress.ExecuteNonQuery();
            Response.Write("<script>alert('修改成功!');window.location.href='ConfigMail.aspx'</script>");
        }
    }
}