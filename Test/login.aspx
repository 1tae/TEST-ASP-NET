<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="min-height:300px; max-width:100%; min-width:50%; padding-top:10%;">
            <div style="left:40%; position:relative;">
                <h1>Log In</h1>
            </div>
            <div style="left:40%; position:relative;">
                <asp:Label runat="server" >아이디&nbsp;&nbsp;&nbsp; : </asp:Label><asp:TextBox runat="server" ID="userId"></asp:TextBox>
            </div>
                <br />
            <div style="left:40%; position:relative;">
                <asp:Label runat="server" >패스워드 : </asp:Label><asp:TextBox runat="server" ID="userPwd" TextMode="Password"></asp:TextBox>
            </div>
                <br />
            <div style="left:40%; position:relative;">
                <asp:LinkButton runat="server" PostBackUrl="/signUp" text="sing up"/>
                <asp:button runat="server" ID="loginBtn" text="log in" OnClick="LoginClick"/>
            </div>
        </div>
    </form>
</body>
</html>
