<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditQuestions.aspx.cs" Inherits="PowerMeetingManageSystem.AddEditQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理问题</title>
<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
</head>
<body>

    <nav class="navbar navbar-default navbar-inverse navbar-static-top" role="navigation">
  <div class="navbar-header">
    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
    <a class="navbar-brand" href="#">Power</a></div>
  <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
    <ul class="nav navbar-nav">
      <li> <a href="MeetingList.aspx">Meeting List</a></li>
      <li class="active"> <a href="#">Meeting Home</a></li>
      <li> <a href="ConfigMail.aspx">邮件及网站配置</a></li>
      
    </ul>
    
    <ul class="nav navbar-nav navbar-right">
      <li> <a href="SignOut.aspx">登出</a></li>
    </ul>
  </div>
</nav>
<div class="col-md-12 column">
<div class="row clearfix">
    <div class="col-md-2 column"></div>
    <div class="col-md-6 column">
       <form role="form" runat="server">
           
        <div class="form-group" id="editForm">
          <label>问题内容:</label>
          <input class="form-control" id="content" runat="server" />
        </div>
        <div class="form-group">
          <label>选项A:</label>
          <input  class="form-control" id="A" runat="server" />
        </div>
           <div class="form-group">
          <label>选项B:</label>
          <input  class="form-control" id="B" runat="server" />
        </div>
           <div class="form-group">
          <label>选项C:</label>
          <input  class="form-control" id="C" runat="server" />
        </div>
           <div class="form-group">
          <label>选项D:</label>
          <input  class="form-control" id="D" runat="server" />
        </div>
           <div class="form-group" runat="server" id="add">
        
        <asp:button type="submit" ID="addButton" runat="server" class="btn btn-default" text="保存" OnClick="addButton_Click" />
         <asp:button type="submit" ID ="cancelButton1" runat="server" class="btn btn-default" text="取消" OnClick="cancelButton1_Click"/>
               </div>
           <div class="form-group" runat="server" id="edit">
        
        <asp:button type="submit" ID="saveButton" runat="server" class="btn btn-default" text="保存" OnClick="saveButton_Click" />
         <asp:button type="submit" ID ="cancelButton2" runat="server" class="btn btn-default" text="取消" OnClick="cancelButton2_Click"/>
               </div>
           
      </form>
       
    </div>

   
    <div class="col-md-4 column"></div>
  </div>
</div>
<div class="container">
	<div class="row clearfix"> </div>
</div>
</body>
</html>
