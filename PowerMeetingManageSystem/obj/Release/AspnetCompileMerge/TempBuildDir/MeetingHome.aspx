<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingHome.aspx.cs" Inherits="PowerMeetingManageSystem.MeetingHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>会议详情</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body background ="imgs/background.jpg">

    <nav class="navbar navbar-default navbar-inverse navbar-static-top" role="navigation">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"><span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
            <a class="navbar-brand" href="#">Power</a>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li><a href="MeetingList.aspx">Meeting List</a></li>
                <li class="active"><a href="#">Meeting Home</a></li>
                <li><a href="ConfigMail.aspx">邮件及网站配置</a></li>

            </ul>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="SignOut.aspx">登出</a></li>
            </ul>
        </div>
    </nav>
    <div class="col-md-12 column">
        <div class="row clearfix">
            <div class="col-md-2 column"></div>
            <div class="col-md-6 column">
                <form role="form" runat="server">
                    <div class="form-group" id="viewForm">
                        <label>会议名称:</label>
                        <label class="form-control" id="conf_name" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>会议主题:</label>
                        <label class="form-control" id="conf_subject" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>会议时间:</label>
                        <label class="form-control" id="conf_time" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>会议地点:</label>
                        <label class="form-control" id="conf_add" runat="server" />
                    </div>
                    <div class="form-group">
                        <label>主办方:</label>
                        <label class="form-control" id="conf_organization" runat="server" />
                    </div>




                    <div class="form-group" runat="server" id="moreOption">
                        <asp:HyperLink class="btn" ID="editMeeting" runat="server">编辑</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:HyperLink class="btn" ID="deleteMeeting" runat="server">删除</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
               
           
               <asp:HyperLink class="btn" ID="viewConfInf" runat="server">查看参会信息</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:HyperLink class="btn" ID="manageConfConv" runat="server">管理参会人员</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:HyperLink class="btn" ID="manageFeedback" runat="server">管理反馈表问题</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:HyperLink class="btn" ID="viewFeedback" runat="server">查看反馈结果</asp:HyperLink>
                    </div>

                    <div class="form-group">
                            <asp:HyperLink class="btn btn-primary" ID="returnMeetingList" runat="server">返回</asp:HyperLink>
                    </div>

                </form>

            </div>


            <div class="col-md-4 column"></div>
        </div>
    </div>
    <div class="container">
        <div class="row clearfix"></div>
    </div>
</body>
</html>
