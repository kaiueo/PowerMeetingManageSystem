using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class ShowMeetingAttendStatus : System.Web.UI.Page
    {
        string meetingId;
        protected void Page_Load(object sender, EventArgs e)
        {
            meetingId = Request.QueryString["id"];
            if (meetingId != null)
            {
                returnMeetingHome.NavigateUrl = "MeetingHome.aspx?id=" + meetingId;
                List<int> conv_ids = new List<int>();
                List<int> statuses = new List<int>();

                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getConvIdAndStatus = new SqlCommand();
                getConvIdAndStatus.Connection = sqlConnection;
                getConvIdAndStatus.CommandText = "select sign_conv_id, sign_status from signform where sign_conf_id = " + meetingId;
                SqlDataReader convIdAndStatus = getConvIdAndStatus.ExecuteReader();

                //得到参会人员的Id和status
                while (convIdAndStatus.Read())
                {
                    conv_ids.Add((int)convIdAndStatus[0]);
                    statuses.Add((int)convIdAndStatus[1]);
                }
                convIdAndStatus.Close();
                int num = 1;

                //得到参会人员的name和dept
                for (int i = 0; i < conv_ids.Count; i++)
                {
                    SqlCommand getConvNameAndDept = new SqlCommand();
                    getConvNameAndDept.Connection = sqlConnection;
                    getConvNameAndDept.CommandText = "select conv_name, conv_dept from conventioner where conv_id = @conv_id";
                    getConvNameAndDept.Parameters.Add("@conv_id", SqlDbType.Int).Value = conv_ids[i];
                    SqlDataReader convNameAndDept = getConvNameAndDept.ExecuteReader();
                    convNameAndDept.Read();
                    string name = convNameAndDept[0].ToString();
                    string dept = convNameAndDept[1].ToString();
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell numberCell = new HtmlTableCell();
                    HtmlTableCell nameCell = new HtmlTableCell();
                    HtmlTableCell deptCell = new HtmlTableCell();
                    HtmlTableCell statusCell = new HtmlTableCell();
                    numberCell.InnerText = num++.ToString();
                    nameCell.InnerText = name;
                    deptCell.InnerText = dept;
                    statusCell.InnerText = statusConvertor(statuses[i]);
                    tr.Controls.Add(numberCell);
                    tr.Controls.Add(nameCell);
                    tr.Controls.Add(deptCell);
                    tr.Controls.Add(statusCell);
                    statusTable.Rows.Add(tr);
                    convNameAndDept.Close();

                }
            }
        }

        private string statusConvertor(int status)
        {
            if (status == 0)
            {
                return "未到";
            }
            else
            {
                return "已到";
            }
        }
    }
}