<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigMail.aspx.cs" Inherits="PowerMeetingManageSystem.ConfigMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>邮件及网站配置</title>
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
                <li><a href="#">Meeting Home</a></li>
                <li class="active"><a href="#">邮件及网站配置</a></li>

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
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <label class="col-sm-2 control-label">邮箱设置</label>
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">SMTP服务器</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="smtpServer" class="form-control" placeholder="SMTP服务器" />
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">用户名</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="emailUser" class="form-control" placeholder="Email" />
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">密码</label>
                        <div class="col-sm-10">
                            <asp:TextBox type="password" runat="server" ID="emailPassword" class="form-control" placeholder="Password" />
                        </div>

                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:Button CssClass="btn btn-default" runat="server" Text="保存" ID="saveEmailButton" OnClick="saveEmailButton_Click" />
                        </div>
                    </div>
                    <br />
                    <br />

                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <label class="col-sm-2 control-label">网址配置</label>
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label">URL</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" ID="webURL" class="form-control" />
                        </div>

                    </div>

                    <div class="form-group">
                        <label class="col-sm-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:Button CssClass="btn btn-default" runat="server" Text="保存" ID="saveURLButton" OnClick="saveURLButton_Click" />

                        </div>
                    </div>

                </form>
            </div>
        </div>


        <div class="col-md-4 column"></div>
    </div>

    <div class="container">
        <div class="row clearfix"></div>
    </div>


</body>
</html>


