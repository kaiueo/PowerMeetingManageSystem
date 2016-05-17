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
    public partial class AddEditQuestions : System.Web.UI.Page
    {

        string meetingId;
        string questionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            add.Visible = false;
            edit.Visible = false;

            meetingId = Request.QueryString["id"];
            questionId = Request.QueryString["questionId"];
            if (questionId == "0")
            {
                add.Visible = true;
            }
            else
            {

                if (meetingId != null)
                {
                    edit.Visible = true;
                    string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                    SqlConnection sqlConnection = new SqlConnection(connectionString);
                    sqlConnection.Open();
                    SqlCommand getMeetingInfo = new SqlCommand();
                    getMeetingInfo.CommandText = "select question_content, question_A, question_B, question_C, question_D from feedback where question_id = " + questionId;
                    getMeetingInfo.Connection = sqlConnection;
                    SqlDataReader result = getMeetingInfo.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            content.Value = result[0].ToString();
                            A.Value = result[1].ToString();
                            B.Value = result[2].ToString();
                            C.Value = result[3].ToString();
                            D.Value = result[4].ToString();
                        }

                    }
                }

            }


        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string meetingId = Request.QueryString["id"];
            if (meetingId != null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string question_content = Request.Form["content"];
                string question_A = Request.Form["A"];
                string question_B = Request.Form["B"];
                string question_C = Request.Form["C"];
                string question_D = Request.Form["D"];

                SqlCommand addQuestion = new SqlCommand();
                addQuestion.Connection = sqlConnection;
                addQuestion.CommandText = "insert into feedback (question_content, question_A, question_B, question_C, question_D, question_conf_id) values (@content, @A, @B, @C, @D, @conf_id)";
                addQuestion.Parameters.Add("@content", SqlDbType.VarChar).Value = question_content;
                addQuestion.Parameters.Add("@A", SqlDbType.VarChar).Value = question_A;
                addQuestion.Parameters.Add("@B", SqlDbType.VarChar).Value = question_B;
                addQuestion.Parameters.Add("@C", SqlDbType.VarChar).Value = question_C;
                addQuestion.Parameters.Add("@D", SqlDbType.VarChar).Value = question_D;
                addQuestion.Parameters.Add("@conf_id", SqlDbType.Int).Value = meetingId;
                try
                {
                    addQuestion.ExecuteNonQuery();
                    Response.Write("<script>alert('添加成功!');window.location.href='ManageQuestions.aspx?id=" + meetingId + "'</script>");
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('请检查输入!')</script>");
                }

            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand updateQuestion = new SqlCommand();
            updateQuestion.Connection = sqlConnection;
            updateQuestion.CommandText = "update feedback set question_content = @content, question_A = @A, question_B = @B, question_C = @C, question_D = @D where question_id = " + questionId;
            string question_content = Request.Form["content"];
            string question_A = Request.Form["A"];
            string question_B = Request.Form["B"];
            string question_C = Request.Form["C"];
            string question_D = Request.Form["D"];
            updateQuestion.Parameters.Add("@content", SqlDbType.VarChar).Value = question_content;
            updateQuestion.Parameters.Add("@A", SqlDbType.VarChar).Value = question_A;
            updateQuestion.Parameters.Add("@B", SqlDbType.VarChar).Value = question_B;
            updateQuestion.Parameters.Add("@C", SqlDbType.VarChar).Value = question_C;
            updateQuestion.Parameters.Add("@D", SqlDbType.VarChar).Value = question_D;
            int a = updateQuestion.ExecuteNonQuery();
            sqlConnection.Close();
            Response.Write("<script>alert('修改成功!');window.location.href='ManageQuestions.aspx?id=" + meetingId + "'</script>");
        }

        protected void cancelButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageQuestions.aspx?id="+meetingId);
        }

        protected void cancelButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageQuestions.aspx?id=" + meetingId);
        }
    }
}
