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
    public partial class ManageQuestions : System.Web.UI.Page
    {
        string meetingId;



        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string question_id = ((Button)sender).CommandArgument;
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand deleteQuestion = new SqlCommand();
            deleteQuestion.Connection = sqlConnection;
            deleteQuestion.CommandText = "delete from feedback where question_id = " + question_id;
            deleteQuestion.ExecuteNonQuery();
            Response.Redirect("ManageQuestions.aspx?id=" + meetingId);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            meetingId = Request.QueryString["id"];
            if (meetingId != null)
            {
                returnMeetingHome.NavigateUrl = "MeetingHome.aspx?id=" + meetingId;
                addQuestion.NavigateUrl = "AddEditQuestions.aspx?id=" + meetingId + "&&questionId=0";
                previewFeedbackQuestions.NavigateUrl = "PreviewFeedback.aspx?id=" + meetingId;
                feedbackAddress.NavigateUrl = "FillFeedback.aspx?id=" + meetingId;

                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getQuestions = new SqlCommand();
                getQuestions.Connection = sqlConnection;
                getQuestions.CommandText = "select question_id, question_content from feedback where question_conf_id = " + meetingId;
                SqlDataReader result = getQuestions.ExecuteReader();
                while (result.Read())
                {
                    string question_id = result[0].ToString();
                    string question_content = result[1].ToString();
                    HyperLink editQuestion = new HyperLink();
                    Button deleteQuestion = new Button();
                    editQuestion.Text = "编辑";
                    deleteQuestion.Text = "删除";
                    deleteQuestion.CommandArgument = question_id;
                    deleteQuestion.Command += deleteButton_Click;



                    editQuestion.NavigateUrl = "AddEditQuestions.aspx?id=" + meetingId + "&&questionId=" + question_id;
                    HtmlTableRow question = new HtmlTableRow();
                    HtmlTableCell id = new HtmlTableCell();
                    HtmlTableCell content = new HtmlTableCell();
                    HtmlTableCell edit = new HtmlTableCell();
                    HtmlTableCell delete = new HtmlTableCell();
                    id.InnerText = question_id;
                    content.InnerText = question_content;
                    edit.Controls.Add(editQuestion);
                    delete.Controls.Add(deleteQuestion);
                    question.Controls.Add(id);
                    question.Controls.Add(content);
                    question.Controls.Add(edit);
                    question.Controls.Add(delete);
                    questionsTable.Rows.Add(question);
                }

            }

        }

    }
}