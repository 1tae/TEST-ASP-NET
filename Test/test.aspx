<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TestPage.TestPage" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <style>
        .testList td {
            min-width : 95px;
            border : 1px solid lightgrey;
        }

        .testList {
            margin-top : 15px;
        }

        #tableArea {
            margin-top : 10px;
        }

        .pageList .on {
            background-color : lightgrey;
        }

        .pageBtn {
            width : 10%;
        }

    </style>

    <h3>DB데이터 조회 테스트 입니다</h3>
    <h4>총 메뉴 개수 : <asp:Label ID="cnt1" runat="server">0</asp:Label></h4>
    <p><asp:Label ID="lblResult" runat="server">버튼 눌러보세요</asp:Label></p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="초기화" />
    <ASP:HiddenField id="lastPage" runat="server" Value="1"/>
    <div id="tableArea">
        <asp:Table ID="TestTable" runat="server" CssClass="testList"></asp:Table>
        <asp:Button Visible="false" Text="<" OnClick="beforePage" runat="server" ID="btnBefore"/>
        <asp:Label ID="nowPageInfo" runat="server" >1</asp:Label>
        <ASP:HiddenField id="nowPage" runat="server" Value="1"/>
        <asp:Button Text=">" OnClick="nextPage" runat="server" ID="btnNext"/>
    </div>
    
</asp:Content>
