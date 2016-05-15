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
    public partial class ManageMeeting : System.Web.UI.Page
    {
        string meetingId;
        protected void Page_Load(object sender, EventArgs e)
        {
            add.Visible = false;
            edit.Visible = false;
            string type = Request.QueryString["type"];
            meetingId = Request.QueryString["id"];
            if (type == "add")
            {
                add.Visible = true;
            }
            else if (type == "edit")
            {

                name.Value = "会议不存在";
                sub.Value = "会议不存在";
                time.Value = "会议不存在";
                address.Value = "会议不存在";
                organization.Value = "会议不存在";
                if (meetingId != null)
                {
                    edit.Visible = true;
                    string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand getMeetingInfo = new SqlCommand();
                    getMeetingInfo.CommandText = "select conf_name, conf_subject, conf_time, conf_add, conf_organization from conference where conf_id = " + meetingId;
                    getMeetingInfo.Connection = sqlConnection;
                    SqlDataReader result = getMeetingInfo.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            name.Value = result[0].ToString();
                            sub.Value = result[1].ToString();
                            time.Value = result[2].ToString();
                            address.Value = result[3].ToString();
                            organization.Value = result[4].ToString();
                        }

                    }
                }

            }
            else if (type == "del")
            {
                //TODO

            }
                
            
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand addMeeting = new SqlCommand();
            addMeeting.Connection = sqlConnection;
            addMeeting.CommandText = "insert into conference (conf_name, conf_add, conf_time, conf_subject, conf_organization) values(@name, @add, @time, @sub, @org)";
            string conf_name = Request.Form["name"];
            string conf_add = Request.Form["address"];
            string conf_time = Request.Form["time"];
            string conf_sub = Request.Form["sub"];
            string conf_organization = Request.Form["organization"];
            addMeeting.Parameters.Add("@name", SqlDbType.VarChar).Value = conf_name;
            addMeeting.Parameters.Add("@add", SqlDbType.VarChar).Value = conf_add;
            addMeeting.Parameters.Add("@time", SqlDbType.DateTime).Value = conf_time;
            addMeeting.Parameters.Add("@sub", SqlDbType.VarChar).Value = conf_sub;
            addMeeting.Parameters.Add("@org", SqlDbType.VarChar).Value = conf_organization;
            try
            {
                addMeeting.ExecuteNonQuery();
                Response.Write("<script>alert('添加成功!');window.location.href='MeetingList.aspx'</script>");
                //Response.Redirect("MeetingList.aspx");
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('请检查输入是否正确。日期格式：xxxx-xx-xx xx:xx:xx')</script>");
            }

        }

        protected void cancelButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeetingList.aspx");
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand addMeeting = new SqlCommand();
            addMeeting.Connection = sqlConnection;
            addMeeting.CommandText = "update conference set conf_name = @name, conf_add = @add, conf_time = @time, conf_subject = @sub, conf_organization = @org where conf_id = " + meetingId;
            string conf_name = Request.Form["name"];
            string conf_add = Request.Form["address"];
            string conf_time = Request.Form["time"];
            string conf_sub = Request.Form["sub"];
            string conf_organization = Request.Form["organization"];
            addMeeting.Parameters.Add("@name", SqlDbType.VarChar).Value = conf_name;
            addMeeting.Parameters.Add("@add", SqlDbType.VarChar).Value = conf_add;
            addMeeting.Parameters.Add("@time", SqlDbType.DateTime).Value = conf_time;
            addMeeting.Parameters.Add("@sub", SqlDbType.VarChar).Value = conf_sub;
            addMeeting.Parameters.Add("@org", SqlDbType.VarChar).Value = conf_organization;



            try
            {
                int a = addMeeting.ExecuteNonQuery();
                sqlConnection.Close();
                Response.Write("<script>alert('修改成功!');window.location.href='MeetingHome.aspx?id="+meetingId+"'</script>");
                //Response.Redirect("MeetingHome.aspx?id=" + meetingId);

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('请检查输入是否正确。日期格式：xxxx-xx-xx xx:xx:xx')</script>");
            }

        }

        protected void cancelButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeetingHome.aspx?id=" + meetingId);
        }
    }
}