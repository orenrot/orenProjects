<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeProduct.aspx.cs" Inherits="ChangeProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
 if (Session["Option"]==null  || ((int)(Session["Option"]) < 3)   )//בדיקה שהאדם רשאי להיכנס לעמוד זה שהוא ספק  שהאפשרות של האפשרות באתר לא ריקה וגם האפשרות גדולה מ 3
       Response.Redirect("~/Homepage.aspx");
     %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div></div>
    <h1>Change Product</h1>




 <asp:DataList   ID="DataList2" runat="server"  
        OnEditCommand="DataList2_EditCommand" 
        OnCancelCommand="DataList2_CancelCommand"  
        OnUpdateCommand="DataList2_UpdateCommand" OnDeleteCommand="DataList2_DeleteCommand" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" >
     <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
     <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
     <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <ItemTemplate>
    <span style="color:Blue">ProductId:</span>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label> <br/>
<span style="color:Blue">ProductType:</span>
<asp:Label ID="Label2" runat="server" Text='<%# Eval("ProductType") %>'></asp:Label> <br/>
<span style="color:Blue">ProductAmount:</span>
<asp:Label ID="Label3" runat="server" text ='<%# Eval("ProductAmount") %>'></asp:Label><br/>
<span style="color:Blue">CompanyName:</span>
<asp:Label ID="Label4" runat="server" text ='<%# Eval("CompanyName") %>'></asp:Label><br/>
<span style="color:Blue">Price:</span>
<asp:Label ID="Label5" runat="server" text ='<%# Eval("Price") %>'></asp:Label><br/>
<span style="color:Blue">ProductName:</span>
<asp:Label ID="Label6" runat="server" text ='<%# Eval("ProductName") %>'></asp:Label><br/>
<span style="color:Blue">ProductQuality:</span>
<asp:Label ID="Label8" runat="server" text ='<%# Eval("ProductQuality") %>'></asp:Label><br/>
<span style="color:Blue">Supplier:</span>
<asp:Label ID="Label9" runat="server" text ='<%# Eval("Supplier") %>'></asp:Label><br/>
<span style="color:Blue">Image:</span>
<asp:Label ID="Label7" runat="server" text ='<%# Eval("Image") %>'></asp:Label><br/>
<span style="color:Blue">ShipmentCoast:</span>
<asp:Label ID="Label10" runat="server" text ='<%# Eval("ShipmentCoast") %>'></asp:Label><br/>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Delete" Text="Delete"> </asp:LinkButton>
</ItemTemplate>
     <AlternatingItemStyle BackColor="#F7F7F7" />
 <EditItemTemplate>
     <span style="color:Blue">ProductId:</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label> <br/>
<span style="color:Blue">ProductType:</span>
<asp:TextBox ID="TextBox1" Text='<%# Eval("ProductType") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">ProductAmount:</span>
<asp:TextBox ID="TextBox2" Text='<%# Eval("ProductAmount") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">CompanyName:</span>
<asp:TextBox ID="TextBox3" Text='<%# Eval("CompanyName") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">Price:</span>
<asp:TextBox ID="TextBox4" Text='<%# Eval("Price") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">ProductName:</span>
<asp:TextBox ID="TextBox5" Text='<%# Eval("ProductName") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">ProductQuality:</span>
<asp:TextBox ID="TextBox6" Text='<%# Eval("ProductQuality") %>' runat="server"></asp:TextBox><br/>
<span style="color:Blue">Supplier:</span>
<asp:Label ID="Label9" runat="server" text ='<%# Eval("Supplier") %>'></asp:Label><br/>
<span style="color:Blue">Image:</span>
     <asp:Label ID="Label11" runat="server" Text='<%# Eval("Image") %>'></asp:Label><br/>
   
<span style="color:Blue">ShipmentCoast:</span>
<asp:TextBox ID="TextBox8" Text='<%# Eval("ShipmentCoast") %>' runat="server"></asp:TextBox><br/>
   <asp:FileUpload ID="FileUpload1" runat="server" />
<asp:LinkButton style="color:Black" ValidationGroup="ProductVal" CausesValidation="true" runat="server"  ID="LinkButton2"   CommandName="update" Text="Update"></asp:LinkButton>
<asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"></asp:LinkButton>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ProductVal" ControlToValidate="TextBox6" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ProductVal" ControlToValidate="TextBox8" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ProductVal" ControlToValidate="TextBox2" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ProductVal" ControlToValidate="TextBox4"  runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ProductVal" ControlToValidate="TextBox1" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ProductVal" ControlToValidate="TextBox3" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" ValidationGroup="ProductVal" Type="Integer" ControlToValidate="TextBox6"  MinimumValue="1" MaximumValue="5" runat="server" ErrorMessage="הכנס איכות בין 1 ל 5"></asp:RangeValidator>
     <asp:RangeValidator ID="RangeValidator2" ValidationGroup="ProductVal" Type="Integer" ControlToValidate="TextBox8"  MinimumValue="0" MaximumValue="100000000" runat="server" ErrorMessage="הכנס מחיר שילוח בין 0 ל 100000000"></asp:RangeValidator>
       <asp:RangeValidator ID="RangeValidator3" ValidationGroup="ProductVal" Type="Integer" ControlToValidate="TextBox2"  MinimumValue="0" MaximumValue="100000000" runat="server" ErrorMessage="הכנס כמות בין 0 ל 100000000"></asp:RangeValidator>
         <asp:RangeValidator ID="RangeValidator4" ValidationGroup="ProductVal" Type="Integer" ControlToValidate="TextBox4"  MinimumValue="0" MaximumValue="100000000" runat="server" ErrorMessage="הכנס מחיר למוצר בין 0 ל 100000000"></asp:RangeValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ProductVal" ControlToValidate="TextBox1" ValidationExpression="^[a-zA-Z]{2,150}$" runat="server" ErrorMessage="הכנס שם ספק באנגלית"></asp:RegularExpressionValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ProductVal" ControlToValidate="TextBox3" ValidationExpression="^[a-zA-Z]{2,150}$" runat="server" ErrorMessage="הכנס שם מוצר באנגלית"></asp:RegularExpressionValidator>
 </EditItemTemplate>
     <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:DataList>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

