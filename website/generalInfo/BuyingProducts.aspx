<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyingProducts.aspx.cs" Inherits="BuyingProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
 //   if (Session["Option"]==null || (int)Session["Option"] < 2)
  //      Response.Redirect("Homepage.aspx");
     %>
<script type="text/javascript">

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%       Session["SelecteValue"] = DropDownList1.SelectedItem.Value.ToString();%>
    
<div></div>
<table>
<tr>
<td>
 אם איזה חברה את\ה רוצים להשוות מחירים
</td>
<td>
    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    <asp:ListItem Text="aliexpress" Value="aliexpress">aliexpress</asp:ListItem>
        <asp:ListItem Text="ebay" Value="ebay">ebay</asp:ListItem>
       <asp:ListItem Text="amazon" Value="amazon">amazon</asp:ListItem>
        <asp:ListItem Text="gearbest" Value="gearbest">gearbest</asp:ListItem>
        <asp:ListItem Text="all" Value="all">all</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="TextSearch" runat="server" ></asp:TextBox>
    <!--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ControlToValidate="TextSearch" ValidationExpression="^[a-z]{2,160}$"   runat="server" ErrorMessage="הכנס מה שאתה מחפש באותיות קטנות באנגלית בלבד"></asp:RegularExpressionValidator>-->
    </td>
    <td>
        <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
    </td>
    </tr>
</table>

    <asp:Label ID="LblShowAll" runat="server" Text="Label"></asp:Label>
    <asp:Image ID="Image1"
        runat="server" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" style="height: 22px">
       
    </asp:DropDownList>

  <!--  <asp:ImageButton  ImageUrl="~/pic/a.jpg" ID="ImageButton1"  runat="server" />-->
    <asp:Button  ID="Button1" runat="server" Text="Click Here To see The product Info" onclick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="מיון לספקים ומחירים" OnClick="Button2_Click" />
      <asp:Button ID="Button3" runat="server" Text="מיון לפי ספק" OnClick="Button3_Click"  />
        <asp:GridView ID="GridView1"    runat="server"  AutoGenerateColumns="false" BackColor="White"  BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
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
                     <table style="background-color:aqua">
        <tr>
        <th>ProductId:</th>
        <td>
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
        <!--<asp:Label ID="Label2" runat="server" Text='<%#Eval("Price") %>'></asp:Label>-->
        </td>
         <th>Price:</th>
        <td>
            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
 
        </td>
        <td>
          <img src=" <%#Eval("ImageUse") %>"/>
        </td>
            </tr>
            </table>
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    

      <asp:GridView ID="GridView2" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
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
        <th>ProductId:</th>
        <td>
            <asp:Label ID="Label4" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
        <!--<asp:Label ID="Label2" runat="server" Text='<%#Eval("Price") %>'></asp:Label>-->
        </td>

         <th>Price:</th>
        <td>
            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
 
        </td>
        <td>
          <img src=" <%#Eval("ImageUse") %>"/>
        </td>
                 <th>ProductType:</th>
        <td>
            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductType") %>'></asp:Label>
        </td>
             <td></td>
                 <th>ProductAmount:</th>
        <td>
            <asp:Label ID="Label7" runat="server" Text='<%# Eval("ProductAmount") %>'></asp:Label>
            <td></td>
        </td>
                            <th>CompanyName:</th>
        <td>
    
            <asp:Label  ID="Label8" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
        </td>
            <td></td>
                            <th>ProductName:</th>
        <td>
            <asp:Label ID="Label9" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
        </td>
             <td></td>
                            <th>Supplier:</th>
        <td>
            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
        </td>
             <td></td>
                                     <th>ShipmentCoast:</th>
        <td>
            <asp:Label ID="Label11" runat="server" Text='<%# Eval("ShipmentCoast") %>'></asp:Label>
        </td>
            </tr>
            </table>
                       </ItemTemplate>
                          </asp:TemplateField>
                       </Columns>
    </asp:GridView>
</asp:Content>

