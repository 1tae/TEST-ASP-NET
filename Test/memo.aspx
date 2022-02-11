<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="memo.aspx.cs" Inherits="Memo.Memo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <style>
        .memoList td {
            min-width : 250px;
            border : 1px solid lightgrey;
        }

        .memoList {
            margin-top : 15px;
        }

        .memoDescription {
            width : 200px;
            height : 150px;
        }

        .memoTitle {
            width : 200px;
            margin-bottom : 10px;
        }

        #tableArea th{
            border : 1px solid grey;
            border-bottom : 2px double black;
        }

        #tableArea td{
            border : 1px solid grey;
        }

        #tableArea{
            margin-top : 20px;
        }

        .searchArea{
            margin-top : 20px;
            width : 300px;
        }

        .saveBtn {
            margin-left : 200px;
        }
        
    </style>
    <div style="margin:50px;">
        <h3>메모 저장 및 메모조회</h3>
        <asp:Label id="test4" runat="server"></asp:Label>
        <p>
            제목 : <asp:TextBox ID="MemoTitle" runat="server" CssClass="memoTitle"></asp:TextBox><br />
            <span style="top:-130px; position:relative;">내용 : </span><asp:TextBox ID="Description" runat="server" TextMode="MultiLine"  CssClass="memoDescription"/>
            <br />
            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="저장" CssClass="saveBtn"/>
        </p>
        <hr />
        <div id="tableArea">
            <table style="width:800px;">
                <colgroup>
                    <col style="width:100px;" />
                    <col style="width:400px;" />
                    <col style="width:100px;" />
                    <col style="width:50px;" />
                </colgroup>
                <tr>
                    <th scope="col">제목</th>
                    <th scope="col">내용</th>
                    <th scope="col">작성자</th>
                    <th scope="col"></th>
                </tr>
                <asp:Repeater runat="server" ID="listData">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("제목") %></td>
                            <td><%# Eval("내용") %></td>
                            <td><%# Eval("작성자") %></td>
                            <td></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div>
                <asp:TextBox runat="server" id="searchText" placeholder="제목/내용/작성자 아이디 검색가능" CssClass="searchArea"/>
                <asp:Button runat="server" id="searchBtn" OnClick="Search" Text="검색"/>
            </div>
        </div>
    </div>
</asp:Content>
