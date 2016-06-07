<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillFeedback.aspx.cs" Inherits="PowerMeetingManageSystem.FillFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>填写反馈表</title>
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
            <form role="form" runat="server">
                <div class="col-md-6 column">
                    <div id="d1" runat="server">
                    </div>

                    <div class="form-group" runat="server" id="add">
                        <br />
                        <br />

                        <asp:Button type="submit" ID="saveButton" runat="server" class="btn btn-default" Text="提交" OnClick="saveButton_Click" />
                    </div>


                </div>
            </form>


            <div class="col-md-4 column"></div>
        </div>
    </div>
    <div class="container">
        <div class="row clearfix"></div>
    </div>


</body>
</html>

