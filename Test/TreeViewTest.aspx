<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TreeViewTest.aspx.cs" Inherits="TreeViewTest.TreeViewTest" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
    <div style="margin-top:20px;">
        <asp:TreeView ID="tree1" ExpandDepth="0" runat="server">
            <Nodes>
                <asp:TreeNode Text="하위메뉴 열기" SelectAction="Expand">
                    <asp:TreeNode text="메뉴1" />
                    <asp:TreeNode text="메뉴2" />
                    <asp:TreeNode text="메뉴3" SelectAction="Expand">
                        <asp:TreeNode text="메뉴 3-1"/>
                        <asp:TreeNode text="메뉴 3-2"/>
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </div>
</asp:Content>

