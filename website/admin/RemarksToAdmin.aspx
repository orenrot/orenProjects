<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RemarksToAdmin.aspx.cs" Inherits="RemarksToAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<% if (Session["category"] != "admin")
      Response.Redirect("~/Homepage.aspx"); %> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" OnDeleteCommand="DataList1_DeleteCommand"  >
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemTemplate>
        <span style="color:Blue">USER ID:</span>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label3" runat="server" Text='<%# Eval("id") %>'></asp:Label> <br/>
<span style="color:Blue">Remark:</span>
<asp:Label ID="Label4" runat="server" Text='<%# Eval("Remark") %>'></asp:Label> <br/>
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
            <asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Delete" Text="Delete all remarks for this user"> </asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:DataList ID="DataList2" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataSourceID="XmlDataSource1" GridLines="Horizontal">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:DataList>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
        DataFile="~/RemarksUsers.xml"></asp:XmlDataSource>
</asp:Content>

