﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="StudentManager.View.ChangePwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/AdminLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
        <div id="sysTitle">
            喜科堂学员管理系统-修改登录密码
        </div>
        <div id="loginImg">
            <img src="../Images/login.png" />
        </div>
        <div id="loginInput">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtNewPwd" Display="None" ErrorMessage="请输入新密码!"></asp:RequiredFieldValidator>
            <div class="loginItem">
                原密码：<asp:TextBox ID="txtOldPwd" 
                    runat="server" TextMode="Password" Width="150px"></asp:TextBox>
            </div>
            <div class="loginItem">
                新密码：<asp:TextBox ID="txtNewPwd" 
                    CssClass="loginItemText" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
            </div>
            <div class="loginItem">
                <asp:Button ID="btnChangePwd" runat="server" Text="修改密码" onclick="btnChangePwd_Click" 
                    />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtOldPwd" Display="None" ErrorMessage="请输入原密码!"></asp:RequiredFieldValidator>
          
        </div>
    </div>
    </form>
</body>
</html>
