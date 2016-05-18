using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PowerMeetingManageSystem
{
    public partial class SendMail : System.Web.UI.Page
    {
        string meetingId;
        string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            meetingId = Request.QueryString["id"];
            type = Request.QueryString["type"];
            if (meetingId != null)
            {
                returnMeetingList.NavigateUrl = "MeetingList.aspx";
                string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand getMeetingInfo = new SqlCommand();
                getMeetingInfo.Connection = sqlConnection;
                getMeetingInfo.CommandText = "select conf_name, conf_time, conf_add from conference where conf_id = " + meetingId;
                SqlDataReader result = getMeetingInfo.ExecuteReader();
                result.Read();
                string meetingName = result[0].ToString();
                string meetingTime = result[1].ToString();
                string meetingAdd = result[2].ToString();
                result.Close();
                if (type == "notice")
                {
                    subject.Text = "“" + meetingName + "”" + "参会通知";
                    content.InnerText = "您好！请于" + meetingTime + "到" + meetingAdd + "参加" + meetingName + "。";
                }
                else if (type == "feedback")
                {

                    SqlCommand getWebAddress = new SqlCommand();
                    getWebAddress.Connection = sqlConnection;
                    getWebAddress.CommandText = "select web_address from configuration where config_id = 1";
                    SqlDataReader webAddReader = getWebAddress.ExecuteReader();
                    webAddReader.Read();
                    string webAddress = webAddReader[0].ToString();
                    subject.Text = "“" + meetingName + "”" + "会后反馈";
                    content.InnerText = "您好！非常感谢您参加了本次会议。\n\n为了更好的组织会议，希望您能在百忙之中抽出几分钟的时间填写本次会议的反馈问卷。\n\n点击以下链接填写反馈问卷：\n\n" + webAddress + "/FillFeedback.aspx?id=" + meetingId;
                }
            }

        }


        protected void sendButton_Click(object sender, EventArgs e)
        {

            string content = Request.Form["content"];
            string subject = Request.Form["subject"];
            string connectionString = ConfigurationManager.ConnectionStrings["pmms"].ConnectionString.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand getEmailConfig = new SqlCommand();
            getEmailConfig.Connection = sqlConnection;
            getEmailConfig.CommandText = "select smtp_server, email_user, email_psw from configuration where config_id = 1";
            SqlDataReader configs = getEmailConfig.ExecuteReader();
            configs.Read();
            string smtpServer = configs[0].ToString();
            string emailUser = configs[1].ToString();
            string emailPassword = configs[2].ToString();
            configs.Close();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = smtpServer;
            smtpClient.Credentials = new System.Net.NetworkCredential(emailUser, emailPassword);


            SqlCommand getConvEmails = new SqlCommand();
            getConvEmails.Connection = sqlConnection;
            getConvEmails.CommandText = "select conv_email from conventioner join signform on conventioner.conv_id = sign_conv_id where sign_conf_id = " + meetingId;
            SqlDataReader result = getConvEmails.ExecuteReader();
            while (result.Read())
            {
                string mailTo = result[0].ToString();
                MailMessage mailMessage = new MailMessage(emailUser, mailTo);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = false;
                mailMessage.Priority = MailPriority.Low;
                try
                {
                    smtpClient.Send(mailMessage); // 发送邮件
                    Response.Write("<script>alert('发送成功!');window.location.href='SendMail.aspx?id=" + meetingId + "&type=" + type + "'</script>");
                }
                catch (SmtpException ex)
                {
                    Response.Write("<script>alert('发送失败,请稍后再试!');window.location.href='SendMail.aspx?id=" + meetingId + "&type=" + type + "'</script>");
                }
            }
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('发送失败,请稍后再试!');window.location.href='WebForm11.aspx?id=" + meetingId + "&type=" + type + "'</script>");
            Response.Redirect("SendMail.aspx?id=" + meetingId + "&type=" + type);
        }
    }
}