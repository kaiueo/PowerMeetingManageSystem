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
    public partial class ManageConventioner : System.Web.UI.Page
    {
        string meetingId;
        protected void Page_Load(object sender, EventArgs e)
        {

            meetingId = Request.QueryString["id"];
            if (meetingId != null)
            {
                returnMeetingHome.NavigateUrl = "MeetingHome.aspx?id=" + meetingId;
                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getConventioners1 = new SqlCommand();//除了参加该会议以外的所有人员
                getConventioners1.Connection = sqlConnection;
                getConventioners1.CommandText = "select conv_name, conv_dept from conventioner where conv_id not in(select sign_conv_id from signform where sign_conf_id=" + meetingId + ")";
                SqlDataReader conventioners1 = getConventioners1.ExecuteReader();
                while (conventioners1.Read())
                {
                    string name = conventioners1[0].ToString() + "(" + conventioners1[1].ToString() + ")";
                    ListItem li = new ListItem();
                    li.Text = name;
                    leftSelect.Items.Add(li);
                }
                conventioners1.Close();

                SqlCommand getConventioners2 = new SqlCommand();//参加该会议以外的所有人员
                getConventioners1.Connection = sqlConnection;
                getConventioners1.CommandText = "select conv_name, conv_dept from conventioner where conv_id in(select sign_conv_id from signform where sign_conf_id=" + meetingId + ")";
                SqlDataReader conventioners2 = getConventioners1.ExecuteReader();
                while (conventioners2.Read())
                {
                    string name = conventioners2[0].ToString() + "(" + conventioners2[1].ToString() + ")";
                    ListItem li = new ListItem();
                    li.Text = name;
                    rightSelect.Items.Add(li);
                }
                conventioners2.Close();
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string rawNamesAndDept = Request.Form["leftSelect"];
            string[] nameAndDepts = rawNamesAndDept.Split(',');
            foreach (string nameAndDept in nameAndDepts)
            {
                string[] rawInfo = nameAndDept.Split('(');
                string name = rawInfo[0];
                string dept = rawInfo[1].Substring(0, rawInfo[1].Length - 1);

                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getConventionerId = new SqlCommand();
                getConventionerId.Connection = sqlConnection;
                getConventionerId.Connection = sqlConnection;
                getConventionerId.CommandText = "select conv_id from conventioner where conv_name = @name and conv_dept = @dept";
                getConventionerId.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                getConventionerId.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
                SqlDataReader result = getConventionerId.ExecuteReader();
                result.Read();
                int conv_id = (int)result[0];
                result.Close();

                SqlCommand addConventioners = new SqlCommand();
                addConventioners.Connection = sqlConnection;
                addConventioners.CommandText = "insert into signform (sign_conv_id, sign_conf_id, sign_status) values (@conv_id, @conf_id, 0)";
                addConventioners.Parameters.Add("@conv_id", SqlDbType.Int).Value = conv_id;
                addConventioners.Parameters.Add("@conf_id", SqlDbType.Int).Value = meetingId;

                addConventioners.ExecuteNonQuery();
            }

            Response.Redirect("ManageConventioner.aspx?id=" + meetingId);
        }

        protected void delButton_Click(object sender, EventArgs e)
        {
            string rawNamesAndDept = Request.Form["rightSelect"];
            string[] nameAndDepts = rawNamesAndDept.Split(',');
            foreach (string nameAndDept in nameAndDepts)
            {
                string[] rawInfo = nameAndDept.Split('(');
                string name = rawInfo[0];
                string dept = rawInfo[1].Substring(0, rawInfo[1].Length - 1);

                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getConventionerId = new SqlCommand();
                getConventionerId.Connection = sqlConnection;
                getConventionerId.Connection = sqlConnection;
                getConventionerId.CommandText = "select conv_id from conventioner where conv_name = @name and conv_dept = @dept";
                getConventionerId.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                getConventionerId.Parameters.Add("@dept", SqlDbType.VarChar).Value = dept;
                SqlDataReader result = getConventionerId.ExecuteReader();
                result.Read();
                int conv_id = (int)result[0];
                result.Close();

                SqlCommand delConventioners = new SqlCommand();
                delConventioners.Connection = sqlConnection;
                delConventioners.CommandText = "delete from signform where sign_conv_id = @conv_id and sign_conf_id = @conf_id";
                delConventioners.Parameters.Add("@conv_id", SqlDbType.Int).Value = conv_id;
                delConventioners.Parameters.Add("@conf_id", SqlDbType.Int).Value = meetingId;

                delConventioners.ExecuteNonQuery();
            }

            Response.Redirect("ManageConventioner.aspx?id=" + meetingId);
        }
    }
}