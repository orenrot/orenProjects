<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WhisList.aspx.cs" Inherits="WhisList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<% if (Session["category"] == "admin")
       Response.Redirect("~/Homepage.aspx");
   if ((Session["Option"] == null || ((int)(Session["Option"]) < 0)))//בודק אם המשתמש קיים ואו המשתמש עם אפשרות פחות מאפס אז לא יתן לו להיכנס
       Response.Redirect("~/Homepage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>רשימת המשאלות שלך</h1>
    <asp:GridView ID="GridView1" runat="server" BackColor="White" AutoGenerateColumns="false"
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
        <Columns>
        <asp:TemplateField>
        <ItemTemplate>
        <table>
        <tr>
        <th>Price:</th>
        <td>
        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
        </td>
         <th>ShipmentCost:</th>
        <td>
        <asp:Label ID="Label5" runat="server" Text='<%#Eval("ShipmentCoast") %>'></asp:Label>
        </td>
        <td>
          <img src="<%#Eval("ImageUse") %>"/>
        </td>
        <td>
           <a href="/generalInfo/BuyingProducts.aspx">make a order</a>
      <!--  <asp:LinkButton style="color:Black" runat="server" ID="LinkButton1"  CommandName="edit" Text="Make a order"></asp:LinkButton>-->
        </td>
        </tr>
        </table>
          
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

