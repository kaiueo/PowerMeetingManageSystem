<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageConventioner.aspx.cs" Inherits="PowerMeetingManageSystem.ManageConventioner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理参会人员</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="lib/google-code-prettify/prettify.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
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
                <div class="col-md-6 column" runat="server">
                    <div>
                        <br />
                        <br />
                        <br />
                    </div>
                    <div>

                        <div class="row">
                            <div class="col-xs-5">
                                未添加的人员
		<select id="leftSelect" name="from" class="form-control" size="8" multiple="true" runat="server">
        </select>
                            </div>

                            <div class="col-xs-2">
                                <br />
                                <br />
                                <br />


                                <asp:Button type="button" ID="addButton" class="btn btn-block" Text=">" runat="server" OnClick="addButton_Click" />
                                <asp:Button type="button" ID="delButton" class="btn btn-block" Text="<" runat="server" OnClick="delButton_Click" />

                            </div>

                            <div class="col-xs-5">
                                已添加的人员
		<select name="to" id="rightSelect" class="form-control" size="8" multiple="true" runat="server">
        </select>
                            </div>
                        </div>

                    </div>
                    <br />
                    <br />

                    <asp:HyperLink class="btn btn-primary" ID="returnMeetingHome" runat="server">返回</asp:HyperLink>

                </div>


                <div class="col-md-4 column"></div>
            </div>
        </div>
        <div class="container">
            <div class="row clearfix"></div>
        </div>
    </form>
</body>
</html>
