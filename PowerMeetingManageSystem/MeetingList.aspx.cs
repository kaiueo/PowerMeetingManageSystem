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
    public partial class MeetingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            addMeeting.NavigateUrl = "ManageMeeting.aspx?type=add";
            addMeeting.Font.Underline = false;
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand getMeetingList = new SqlCommand();
            getMeetingList.CommandText = "select conf_id, conf_name from conference";
            getMeetingList.Connection = sqlConnection;

            SqlDataReader result = getMeetingList.ExecuteReader();
            while (result.Read())
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell(); //空白间隔，美观
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                HyperLink hl1 = new HyperLink();
                HyperLink hl2 = new HyperLink();
                HyperLink hl3 = new HyperLink();
                hl1.Text = (string)result[1];
                hl1.NavigateUrl = "MeetingHome.aspx?id=" + result[0].ToString();
                hl1.Font.Underline = false; //取消超链接中的下划线
                hl2.Text = "发送参会通知";
                hl2.NavigateUrl = "SendMail.aspx?id=" + result[0].ToString()+"&type=notice";
                hl2.Font.Underline = false;
                hl3.Text = "&nbsp;发送填写反馈表通知";
                hl3.NavigateUrl = "SendMail.aspx?id=" + result[0].ToString() + "&type=feedback";
                hl3.Font.Underline = false;
                tc1.Controls.Add(hl1);
                tc2.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                tc3.Controls.Add(hl2);
                tc4.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";
                tc5.Controls.Add(hl3);
                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc3);
                tr.Controls.Add(tc4);
                tr.Controls.Add(tc5);
                meetingListTable.Rows.Add(tr);

            }
        }
    }
}