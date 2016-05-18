<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="PowerMeetingManageSystem.SendMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发送邮件</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body>
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
                <form role="form" runat="server" class="form-horizontal">

                    <div class="form-group">
                        <label class="col-sm-2 control-label">主题</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="subject" class="form-control" placeholder="主题" />
                        </div>


                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">正文</label>
                        <div class="col-sm-10">
                            <textarea runat="server" id="content" class="form-control" rows="10"></textarea>
                        </div>


                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:Button CssClass="btn btn-default" runat="server" Text="发送" ID="sendButton" OnClick="sendButton_Click" />
                            <asp:Button CssClass="btn btn-default" runat="server" Text="重置" ID="resetButton" OnClick="resetButton_Click" />
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:HyperLink class="btn btn-primary" ID="returnMeetingList" runat="server">返回</asp:HyperLink>
                        </div>
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


