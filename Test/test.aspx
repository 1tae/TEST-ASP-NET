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
    
    <div id="tableArea">
        <asp:Button ID="Button2" runat="server"  CssClass="btn2" OnClick="Button2_Click" Text="메뉴 리스트 20개 가져오기" data-value="1"/>
        <asp:Table ID="TestTable" runat="server" CssClass="testList"></asp:Table>
        <asp:Table ID="PageTable" runat="server" CssClass="pageList" >
             <asp:TableRow>
                <asp:TableCell CssClass="pageBtn" data-value="1">1</asp:TableCell>      
                <asp:TableCell CssClass="pageBtn" data-value="2">2</asp:TableCell>      
                <asp:TableCell CssClass="pageBtn" data-value="3">3</asp:TableCell>      
                <asp:TableCell CssClass="pageBtn" data-value="4">4</asp:TableCell>      
             </asp:TableRow> 
        </asp:Table>
        
    </div>

    <script >
        var nowPage = 1;
        $(document).ready(function () {
            setBtnCss();

            $('.pageBtn').on('click', function () {
                nowPage = $(this).data('value');
                setBtnCss();
                $('.btn2').val(nowPage).click();
            });

        });

        var setBtnCss = function () {
            $('.pageBtn').removeClass('on');
            $('.pageBtn[data-value="' + nowPage + '"]').addClass('on');
        }


    </script>
</asp:Content>
