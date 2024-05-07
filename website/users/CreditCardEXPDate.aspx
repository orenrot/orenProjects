<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCardEXPDate.aspx.cs" Inherits="CreditCardEXPDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Label  id="lblYear" runat="server"  Text="Year"></asp:Label>
    <asp:DropDownList id="ddlYear"  AutoPostBack="True" runat="server" 
        onselectedindexchanged="ddlYear_SelectedIndexChanged" >
        <asp:ListItem Value="2018">2018</asp:ListItem>
    </asp:DropDownList>
       <asp:Label id="lblMonth" runat="server" Text="Month"></asp:Label>
           <asp:DropDownList id="ddlMonths" AutoPostBack="True" runat="server" 
        onselectedindexchanged="ddlMonths_SelectedIndexChanged">
    </asp:DropDownList>
        <asp:Label id="lblDay" runat="server" Text="Day"></asp:Label>
           <asp:DropDownList id="ddlDay2" AutoPostBack="True" runat="server" >
    </asp:DropDownList>
</asp:Content>

