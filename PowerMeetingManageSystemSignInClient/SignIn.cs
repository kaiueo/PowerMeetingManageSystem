using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerMeetingManageSystemSignInClient
{
    public partial class SignIn : Form
    {
        string conf_id;
        public SignIn()
        {
            InitializeComponent();
            SqlConnection sqlConnection = Configuration.SqlConnection;
            SqlCommand getMeetingList = new SqlCommand();
            getMeetingList.Connection = sqlConnection;
            getMeetingList.CommandText = "select conf_id, conf_name from conference";
            SqlDataReader result = getMeetingList.ExecuteReader();
            Dictionary<string, string> meetingList = new Dictionary<string, string>();
            while (result.Read())
            {
                meetingList.Add(result[0].ToString(), result[1].ToString());
            }
            result.Close();

            BindingSource bs = new BindingSource();
            bs.DataSource = meetingList;
            meetingListComboBox.DataSource = bs;
            meetingListComboBox.ValueMember = "Key";
            meetingListComboBox.DisplayMember = "Value";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            signInInfoPanel.Controls.Clear();
            conf_id = meetingListComboBox.SelectedValue.ToString();
            SqlCommand getSignInInfo = new SqlCommand();
            getSignInInfo.Connection = Configuration.SqlConnection;
            getSignInInfo.CommandText = "select conv_name, conv_dept, sign_status, conv_id from conventioner join signform on conventioner.conv_id = signform.sign_conv_id where sign_conf_id = " + conf_id;
            SqlDataReader result = getSignInInfo.ExecuteReader();
            while (result.Read())
            {
                Label nameAndDept = new Label();
                string name = result[0].ToString();
                string dept = result[1].ToString();
                string status = result[2].ToString();
                string id = result[3].ToString();
                nameAndDept.Text = string.Format("{0}( {1} )", name, dept);
                nameAndDept.Font = new Font("黑体",13);
                Button signInButton = new Button();
                signInButton.Name = id;
                if (status == "0")
                {
                    signInButton.Text = "签到";
                    signInButton.Click += signInButton_Click;
                }
                else
                {
                    signInButton.Text = "已签到";
                    signInButton.Enabled = false;
                }
                signInInfoPanel.RowCount++;
                signInInfoPanel.Controls.Add(signInButton);
                signInInfoPanel.Controls.Add(nameAndDept);
            }
            result.Close();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            string conv_id = thisButton.Name;
            SqlCommand signIn = new SqlCommand();
            signIn.Connection = Configuration.SqlConnection;
            signIn.CommandText = "update signform set sign_status = 1 where sign_conv_id = " + conv_id + " and sign_conf_id = " + conf_id;
            try
            {
                signIn.ExecuteNonQuery();
                thisButton.Enabled = false;
                thisButton.Text = "已签到";
            }
            catch
            {
                MessageBox.Show("遇到未知错误");
            }
            
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
