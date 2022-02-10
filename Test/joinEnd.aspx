<%@ Page Title="About" Language="C#" MasterPageFile="~/NotLogin.Master" AutoEventWireup="true" CodeBehind="joinEnd.aspx.cs" Inherits="joinEnd.joinEnd" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="min-height:150px; text-align:center;">
        <h2 style="line-height:150px;">회원가입이 완료되었습니다.</h2><hr />
        <asp:LinkButton PostBackUrl="/login" runat="server">로그인하러가기</asp:LinkButton>
    </div>
</asp:content>


