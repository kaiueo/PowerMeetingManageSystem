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
    public partial class FillFeedback : System.Web.UI.Page
    {
        string meetingId;

        private HtmlGenericControl makeQuestion(string content, string A, string B, string C, string D, string questionId, bool isPreview)
        {
            HtmlGenericControl div0 = new HtmlGenericControl("div");
            Label l0 = new Label();
            l0.Text = content;
            l0.Font.Bold = true;
            div0.Attributes["class"] = "form-group";
            div0.Controls.Add(l0);


            HtmlGenericControl div1 = new HtmlGenericControl("div");
            HtmlGenericControl div2 = new HtmlGenericControl("div");
            HtmlGenericControl div3 = new HtmlGenericControl("div");
            HtmlGenericControl div4 = new HtmlGenericControl("div");

            div1.Attributes["class"] = "radio";
            div2.Attributes["class"] = "radio";
            div3.Attributes["class"] = "radio";
            div4.Attributes["class"] = "radio";
            HtmlInputRadioButton r1 = new HtmlInputRadioButton();
            HtmlInputRadioButton r2 = new HtmlInputRadioButton();
            HtmlInputRadioButton r3 = new HtmlInputRadioButton();
            HtmlInputRadioButton r4 = new HtmlInputRadioButton();
            r1.Name = questionId;
            r2.Name = questionId;
            r3.Name = questionId;
            r4.Name = questionId;

            if (isPreview)
            {
                r1.Disabled = true;
                r2.Disabled = true;
                r3.Disabled = true;
                r4.Disabled = true;
            }

            r1.Value = "A";
            r2.Value = "B";
            r3.Value = "C";
            r4.Value = "D";
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();

            l1.Text = A;
            l2.Text = B;
            l3.Text = C;
            l4.Text = D;

            div1.Controls.Add(r1);
            div2.Controls.Add(r2);
            div3.Controls.Add(r3);
            div4.Controls.Add(r4);

            div1.Controls.Add(l1);
            div2.Controls.Add(l2);
            div3.Controls.Add(l3);
            div4.Controls.Add(l4);

            div0.Controls.Add(div1);
            div0.Controls.Add(div2);
            div0.Controls.Add(div3);
            div0.Controls.Add(div4);
            return div0;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            meetingId = Request.QueryString["id"];
            if (meetingId != null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getQuestions = new SqlCommand();
                getQuestions.Connection = sqlConnection;
                getQuestions.CommandText = "select question_content, question_A, question_B, question_C, question_D, question_id from feedback where question_conf_id=" + meetingId;
                SqlDataReader result = getQuestions.ExecuteReader();
                int num = 1;
                while (result.Read())
                {
                    string content = result[0].ToString();
                    string A = result[1].ToString();
                    string B = result[2].ToString();
                    string C = result[3].ToString();
                    string D = result[4].ToString();
                    string questionId = result[5].ToString();
                    d1.Controls.Add(makeQuestion(num++.ToString() + "." + content, A, B, C, D, questionId, false));
                }

            }



        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand getQuestionIds = new SqlCommand();
            getQuestionIds.Connection = sqlConnection;
            getQuestionIds.CommandText = "select question_id from feedback where question_conf_id = " + meetingId;
            SqlDataReader result = getQuestionIds.ExecuteReader();
            while (result.Read())
            {
                string questionId = result[0].ToString();
                string choice = Request.Form[questionId];
                makeIncress(questionId, choice);
            }
            Response.Write("<script>alert('提交成功!');window.location.href='FillFeedback.aspx?id=" + meetingId + "'</script>");
        }

        private void makeIncress(string questionId, string choice)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand incress = new SqlCommand();
            incress.Connection = sqlConnection;
            incress.CommandText = "update feedback set question_total" + choice + " = question_total" + choice + " + 1 where question_id = " + questionId;
            incress.ExecuteNonQuery();
        }
    }
}