<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReciveProduct.aspx.cs" Inherits="ReciveProduct" %>

<%@ Register src="WhichProductToWriteTheRevivew.ascx" tagname="WhichProductToWriteTheRevivew" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%
    if (Session["Option"]==null  || ((int)(Session["Option"]) < 2)   )//בדיקה שהאדם רשאי להיכנס לעמוד זה שהוא ספק  שהאפשרות של האפשרות באתר לא ריקה וגם האפשרות גדולה מ 3
       Response.Redirect("~/Homepage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Recived Item?"></asp:Label>
    <uc1:WhichProductToWriteTheRevivew ID="WhichProductToWriteTheRevivew1" runat="server" />
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem Value="yes" Text="yes"></asp:ListItem>
     <asp:ListItem Value="no" Text="no"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Recive Item" onclick="Button1_Click" />
    <asp:DataList ID="DataList1" runat="server" BackColor="White"  OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand" OnCancelCommand="DataList1_CancelCommand"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemTemplate>
      <span style="color:Blue">DateId :</span>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Text='<%# Eval("DateId") %>'></asp:Label> <br/>
<span style="color:Blue">BuyerId:</span>
<asp:Label ID="Label2" runat="server" Text='<%# Eval("BuyerId") %>'></asp:Label> <br/>
<span style="color:Blue">ProductId:</span>
<asp:Label ID="Label3" runat="server" text ='<%# Eval("ProductId") %>'></asp:Label><br/>
<span style="color:Blue">amount:</span>
<asp:Label ID="Label4" runat="server" text ='<%# Eval("amount") %>'></asp:Label><br/>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
</ItemTemplate>
        <AlternatingItemStyle BackColor="PaleGoldenrod" />
<EditItemTemplate>
<span style="color:Blue">DateId :</span>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label11" runat="server" Text='<%# Eval("DateId") %>'></asp:Label> <br/>
<span style="color:Blue">BuyerId:</span>
<asp:Label ID="Label22" runat="server" Text='<%# Eval("BuyerId") %>'></asp:Label> <br/>
<span style="color:Blue">ProductId:</span>
<asp:Label ID="Label33" runat="server" text ='<%# Eval("ProductId") %>'></asp:Label><br/>
<span style="color:Blue">amount:</span>
<asp:Label ID="Label44" runat="server" text ='<%# Eval("amount") %>'></asp:Label><br/>
<span style="color:Blue">StartPrice :</span>
<asp:Label ID="Label55" runat="server" Text='<%# Eval("StartPrice") %>'></asp:Label> <br/>
<span style="color:Blue">SalePerrcent:</span>
<asp:Label ID="Label66" runat="server" Text='<%# Eval("SalePerrcent") %>'></asp:Label> <br/>
<span style="color:Blue">StatusOffer:</span>
<asp:Label ID="Label77" runat="server" text ='<%# Eval("StatusOffer") %>'></asp:Label><br/>
<span style="color:Blue">StatusDescription:</span>
<asp:Label ID="Label88" runat="server" text ='<%# Eval("StatusDescription") %>'></asp:Label><br/>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Update" Text="Recive"> </asp:LinkButton>
<asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
</EditItemTemplate>
    </asp:DataList>
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>

</asp:Content>

