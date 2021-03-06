﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageQuestions.aspx.cs" Inherits="PowerMeetingManageSystem.ManageQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>反馈表管理</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body background ="imgs/background.jpg">
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
                <div class="col-md-6 column" id="d1" runat="server">
                    <asp:HyperLink class="btn btn-primary" ID="addQuestion" runat="server">添加问题</asp:HyperLink>
                    <asp:HyperLink class="btn btn-primary" ID="previewFeedbackQuestions" runat="server">预览反馈表</asp:HyperLink>
                    <asp:Button class="btn btn-primary" ID="generateFeedbackAddress" runat="server" Text="生成反馈表链接" OnClick="generateFeedbackAddress_Click" />
                    <br />
                    <br />

                    <table class="table table-striped table-hover" id="questionsTable" runat="server">
                        <thead>
                            <tr>
                                <th>编号</th>
                                <th>内容</th>
                                <th></th>
                                <th></th>
                            </tr>
                        </thead>

                    </table>

                    <div id="feedbackAddDiv" runat="server">
                        <label>反馈表链接：</label>

                    </div>

                    <div>
                        <br />

                        <br />

                        <asp:HyperLink class="btn btn-primary" ID="returnMeetingHome" runat="server">返回</asp:HyperLink>
                    </div>
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
