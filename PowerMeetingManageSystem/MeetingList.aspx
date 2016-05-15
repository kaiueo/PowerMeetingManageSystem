<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingList.aspx.cs" Inherits="PowerMeetingManageSystem.MeetingList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会议列表</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <nav class="navbar navbar-default navbar-inverse navbar-static-top" role="navigation">
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
    <a class="navbar-brand" href="#">Power</a></div>
  <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
    <ul class="nav navbar-nav">
      <li class="active"> <a href="#">Meeting List</a></li>
      <li> <a href="#">Meeting Home</a></li>
      
    </ul>
    
    <ul class="nav navbar-nav navbar-right">
      <li> <a href="#">邮件及网站配置</a></li>
    </ul>
  </div>
</nav>
<div class="col-md-12 column">
<div class="row clearfix">
    <div class="col-md-2 column"></div>
    <div class="col-md-6 column" runat="server">
       <br /><br /><br />
        <asp:HyperLink class="btn btn-primary" ID="addMeeting" runat="server">新建会议</asp:HyperLink>
        <br /><br />
       
        <asp:Table CssClass ="table" ID="meetingListTable" runat="server" BorderStyle="None"  >
        </asp:Table>
       
    </div>

   
    <div class="col-md-4 column"></div>
  </div>
</div>
<div class="container">
	<div class="row clearfix"> </div>
</div>
    </form>
</body>
</html>
