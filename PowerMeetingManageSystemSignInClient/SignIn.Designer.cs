namespace PowerMeetingManageSystemSignInClient
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.meetingListComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.signInInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // meetingListComboBox
            // 
            this.meetingListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meetingListComboBox.FormattingEnabled = true;
            this.meetingListComboBox.Location = new System.Drawing.Point(84, 23);
            this.meetingListComboBox.Name = "meetingListComboBox";
            this.meetingListComboBox.Size = new System.Drawing.Size(266, 20);
            this.meetingListComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "会议列表";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(369, 21);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "确定";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // signInInfoPanel
            // 
            this.signInInfoPanel.AutoScroll = true;
            this.signInInfoPanel.ColumnCount = 2;
            this.signInInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.02343F));
            this.signInInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.97657F));
            this.signInInfoPanel.Location = new System.Drawing.Point(18, 75);
            this.signInInfoPanel.Name = "signInInfoPanel";
            this.signInInfoPanel.RowCount = 1;
            this.signInInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.signInInfoPanel.Size = new System.Drawing.Size(426, 533);
            this.signInInfoPanel.TabIndex = 3;
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 620);
            this.Controls.Add(this.signInInfoPanel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.meetingListComboBox);
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签到系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SignIn_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox meetingListComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TableLayoutPanel signInInfoPanel;
    }
}