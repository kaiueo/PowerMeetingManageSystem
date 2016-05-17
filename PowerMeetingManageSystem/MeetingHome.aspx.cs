using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class MeetingHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            moreOption.Visible = false;
            string meetingId = Request.QueryString["id"];

            conf_name.InnerText = "会议不存在";
            conf_subject.InnerText = "会议不存在";
            conf_time.InnerText = "会议不存在";
            conf_add.InnerText = "会议不存在";
            conf_organization.InnerText = "会议不存在";
            if (meetingId != null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getMeetingInfo = new SqlCommand();
                getMeetingInfo.CommandText = "select conf_name, conf_subject, conf_time, conf_add, conf_organization from conference where conf_id = "+meetingId;
                getMeetingInfo.Connection = sqlConnection;
                SqlDataReader result = getMeetingInfo.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        conf_name.InnerText = result[0].ToString();
                        conf_subject.InnerText = result[1].ToString();
                        conf_time.InnerText = result[2].ToString();
                        conf_add.InnerText = result[3].ToString();
                        conf_organization.InnerText = result[4].ToString();
                    }

                    editMeeting.NavigateUrl = "ManageMeeting.aspx?type=edit&id=" + meetingId;
                    deleteMeeting.NavigateUrl = "ManageMeeting.aspx?type=del&id=" + meetingId;
                    manageConfConv.NavigateUrl = "ManageConventioner.aspx?id=" + meetingId;
                    viewConfInf.NavigateUrl = "ShowMeetingAttendStatus.aspx?id=" + meetingId;
                    manageFeedback.NavigateUrl = "ManageQuestions.aspx?id=" + meetingId;
                    viewFeedback.NavigateUrl = "ViewFeedbackResult.aspx?id=" + meetingId;

                    moreOption.Visible = true;
                }
               
            }
        }
    }
}