using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //登录
        protected void signinButton_Click(object sender, EventArgs e)
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand getNameAndPassword = new SqlCommand();
            getNameAndPassword.CommandText = "select * from organizer";
            getNameAndPassword.Connection = sqlConnection;
            SqlDataReader result = getNameAndPassword.ExecuteReader();
            bool isCorrect = false;
            while (result.Read())
            {
                if(username == (string)result[0] && password == (string)result[1])
                {
                    isCorrect = true;
                    break;
                }
            }

            //授权并跳转至MeetingList.aspx
            if (isCorrect)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                String redirectionUrl = FormsAuthentication.GetRedirectUrl(username, false);
                redirectionUrl = "MeetingList.aspx";
                Response.Redirect(redirectionUrl);
            }else
            {
                Response.Write("<script>alert('用户名或密码错误');</script>");

            }
        }
    }
}