<%@ Page Title="About" Language="C#" MasterPageFile="~/NotLogin.Master" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="SignUp.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <ASP:HiddenField id="hdnCheckID" runat="server" />
    아이디
    <ASP:TextBox id="txtID" runat="server" />
    <ASP:Button id="btnCheck" runat="server" text="중복체크" OnClick="btnCheck_Click" />
    <ASP:Label id="lblCheckResult" runat="server" />
    
    <br> 
    비밀번호
    <ASP:TextBox id="txtPass" textmode="password" runat="server" />

    <br> 
    닉네임
    <ASP:TextBox id="txtNick"  runat="server" />

    <br> 
    <ASP:Button id="btnJoin" runat="server" text="회원가입하기" OnClick="btnJoin_Click" />

    <br>
    <ASP:Label id="lblJoinResult" runat="server" />
    <asp:LinkButton PostBackUrl="/joinEnd" runat="server">test</asp:LinkButton>
</asp:Content>    

