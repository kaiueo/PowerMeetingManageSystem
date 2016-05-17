using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class ViewFeedbackResult : System.Web.UI.Page
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
                SqlCommand getStatistics = new SqlCommand();
                getStatistics.Connection = sqlConnection;
                getStatistics.CommandText = "select question_content, question_A, question_totalA, APercent,question_B, question_totalB, BPercent,question_C, question_totalC, CPercent,question_D, question_totalD, DPercent from feedbackStatistics where question_conf_id = " + meetingId;
                SqlDataReader result = getStatistics.ExecuteReader();
                int num = 1;
                while (result.Read())
                {
                    string question = result[0].ToString();
                    string questionA = result[1].ToString();
                    string numA = result[2].ToString();
                    string perA = result[3].ToString();
                    string questionB = result[4].ToString();
                    string numB = result[5].ToString();
                    string perB = result[6].ToString();
                    string questionC = result[7].ToString();
                    string numC = result[8].ToString();
                    string perC = result[9].ToString();
                    string questionD = result[10].ToString();
                    string numD = result[11].ToString();
                    string perD = result[12].ToString();
                    HtmlGenericControl resultDiv = makeResult(num++.ToString() + "." + question, questionA, questionB, questionC, questionD, numA, numB, numC, numD, perA, perB, perC, perD);
                    d1.Controls.Add(resultDiv);
                }

            }
        }

        private HtmlGenericControl makeResult(string question, string questionA, string questionB, string questionC, string questionD, string numA, string numB, string numC, string numD, string perA, string perB, string perC, string perD)
        {
            HtmlGenericControl result = new HtmlGenericControl("div");
            result.Attributes["class"] = "form-group";
            Label questionLabel = new Label();
            questionLabel.Text = question;
            questionLabel.Font.Bold = true;
            result.Controls.Add(questionLabel);
            HtmlGenericControl A = new HtmlGenericControl("div");
            HtmlGenericControl B = new HtmlGenericControl("div");
            HtmlGenericControl C = new HtmlGenericControl("div");
            HtmlGenericControl D = new HtmlGenericControl("div");
            A.InnerText = String.Format("{0} ({1}票 - {2}% )", questionA, numA, perA);
            B.InnerText = String.Format("{0} ({1}票 - {2}% )", questionB, numB, perB);
            C.InnerText = String.Format("{0} ({1}票 - {2}% )", questionC, numC, perC);
            D.InnerText = String.Format("{0} ({1}票 - {2}% )", questionD, numD, perD);
            result.Controls.Add(A);
            result.Controls.Add(B);
            result.Controls.Add(C);
            result.Controls.Add(D);
            return result;
        }
    }
}