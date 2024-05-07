<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllYourOrders.aspx.cs" Inherits="AllYourOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
    if (Session["Option"]==null || (int)Session["Option"] < 2)
        Response.Redirect("~/Homepage.aspx");
     %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div></div>
    <asp:Label ID="Label2" runat="server" Text="ההזמנות שלך לקנות או לבטל"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView   ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal"  OnRowDeleting= "GridView1_RowDeleting" >
        <AlternatingRowStyle  BackColor="#F7F7F7" />
        <FooterStyle  BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle  BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle  BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
 <Columns>
 <asp:BoundField    DataField="DateId" HtmlEncode="false"    SortExpression="DateId"    HeaderText="DateId" />
<asp:ButtonField   ButtonType="Button" CommandName="Delete" Text="מחק "  HeaderText="מחק" /> 
<asp:HyperLinkField NavigateUrl="/users/BuyNow.aspx" Text="קנה" />
</Columns>
    </asp:GridView>
    <asp:TextBox  ID="TextBox1"  disabled="disabled" runat="server"></asp:TextBox>
      <asp:TextBox  ID="TextBox2"  disabled="disabled" runat="server"></asp:TextBox>
    <a href="/users/BuyNow.aspx">לעבור לעמוד בו כל ההזמנות שלך ומצבן</a>
</asp:Content>

