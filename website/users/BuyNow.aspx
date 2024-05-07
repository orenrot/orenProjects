<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuyNow.aspx.cs" Inherits="BuyNow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<% if (Session["Option"]==null || (int)Session["Option"] < 2)
        Response.Redirect("~/Homepage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div></div>
    <h1>ההזמנות בשלב לפני קנייה </h1>
    <asp:GridView ID="GridView1" runat="server" BackColor="White"  
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" style="margin-top: 0px"   OnRowEditing="GridView1_RowEditing"   OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_UpdateCommand">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField />
            <asp:CommandField   ShowEditButton="True" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
  
    </asp:GridView>
  
     <asp:DataList ID="DataList1" runat="server" BackColor="White"  
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal"
    OnEditCommand="DataList1_EditCommand"   OnCancelCommand="DataList1_CancelCommand"   OnUpdateCommand="DataList1_UpdateCommand"  >
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
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="buy"> </asp:LinkButton>
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
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Update" Text="Buy"> </asp:LinkButton>
<asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
</EditItemTemplate>
    </asp:DataList>
      <h2>הזמנות בשלבים מתקדמים יותר</h2>
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>

    <asp:DataList ID="DataList2" runat="server" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyField="DateId" 
        DataSourceID="SqlDataSource1" ForeColor="Black"   OnEditCommand="DataList2_EditCommand"  >
        <AlternatingItemStyle BackColor="PaleGoldenrod" />
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <ItemTemplate>
            DateId:
            <asp:Label ID="DateIdLabel" runat="server" Text='<%# Eval("DateId") %>' />
            <br />
            BuyerId:
            <asp:Label ID="BuyerIdLabel" runat="server" Text='<%# Eval("BuyerId") %>' />
            <br />
            ProductId:
            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
            <br />
            amount:
            <asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
            <br />
            StartPrice:
            <asp:Label ID="StartPriceLabel" runat="server" 
                Text='<%# Eval("StartPrice") %>' />
            <br />
            SalePerrcent:
            <asp:Label ID="SalePerrcentLabel" runat="server" 
                Text='<%# Eval("SalePerrcent") %>' />
            <br />
            StatusOffer:
            <asp:Label ID="StatusOfferLabel" runat="server" 
                Text='<%# Eval("StatusOffer") %>' />
            <br />
            StatusDescription:
            <asp:Label ID="StatusDescriptionLabel" runat="server" 
                Text='<%# Eval("StatusDescription") %>' />
                
            <br />
<br />
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
        </ItemTemplate>
       
        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <EditItemTemplate>
        <asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Update" Text="Buy"> </asp:LinkButton>
        <asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
        </EditItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
        SelectCommand="SELECT * FROM [OfferForPrice] WHERE ([BuyerId] = @BuyerId)" 
        DeleteCommand="DELETE FROM [OfferForPrice] WHERE [DateId] = @original_DateId AND [BuyerId] = @original_BuyerId AND [ProductId] = @original_ProductId" 
        InsertCommand="INSERT INTO [OfferForPrice] ([DateId], [BuyerId], [ProductId], [amount], [StartPrice], [SalePerrcent], [StatusOffer], [StatusDescription]) VALUES (@DateId, @BuyerId, @ProductId, @amount, @StartPrice, @SalePerrcent, @StatusOffer, @StatusDescription)" 
        OldValuesParameterFormatString="original_{0}" 
        
        UpdateCommand="UPDATE [OfferForPrice] SET [amount] = @amount, [StartPrice] = @StartPrice, [SalePerrcent] = @SalePerrcent, [StatusOffer] = @StatusOffer, [StatusDescription] = @StatusDescription WHERE [DateId] = @original_DateId AND [BuyerId] = @original_BuyerId AND [ProductId] = @original_ProductId">
        <DeleteParameters>
            <asp:Parameter Name="original_DateId" Type="DateTime" />
            <asp:Parameter Name="original_BuyerId" Type="String" />
            <asp:Parameter Name="original_ProductId" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="DateId" Type="DateTime" />
            <asp:Parameter Name="BuyerId" Type="String" />
            <asp:Parameter Name="ProductId" Type="String" />
            <asp:Parameter Name="amount" Type="Int32" />
            <asp:Parameter Name="StartPrice" Type="String" />
            <asp:Parameter Name="SalePerrcent" Type="String" />
            <asp:Parameter Name="StatusOffer" Type="String" />
            <asp:Parameter Name="StatusDescription" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="null" Name="BuyerId" 
                SessionField="username" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="amount" Type="Int32" />
            <asp:Parameter Name="StartPrice" Type="String" />
            <asp:Parameter Name="SalePerrcent" Type="String" />
            <asp:Parameter Name="StatusOffer" Type="String" />
            <asp:Parameter Name="StatusDescription" Type="String" />
            <asp:Parameter Name="original_DateId" Type="DateTime" />
            <asp:Parameter Name="original_BuyerId" Type="String" />
            <asp:Parameter Name="original_ProductId" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

