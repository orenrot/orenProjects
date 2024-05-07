<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupplierRegistrartion.aspx.cs" Inherits="SupplierRegistrartion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
 if (Session["Option"]==null  || ((int)(Session["Option"]) < 3)   )//בדיקה שהאדם רשאי להיכנס לעמוד זה שהוא ספק  שהאפשרות של האפשרות באתר לא ריקה וגם האפשרות גדולה מ 3
        Response.Redirect("~/Homepage.aspx");
     %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="SupplierHarshama"  method="post" action="register.aspx" >
<table>
<tr>
<td>
    <asp:Label ID="lblSuppierId" runat="server" Text="SuppierId"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtSuppierId" runat="server"></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckSuppierId"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox>
</td>
<td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSuppierId" ValidationGroup="SupplierVal" runat="server" ErrorMessage="!!!!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtSuppierId" ValidationExpression="^[a-z]{2,160}$"  ValidationGroup="SupplierVal" runat="server" ErrorMessage="הכנס ספק יחודי באותיות קטנות באנגלית בלבד"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblRegisterDate" runat="server" Text="RegisterDate"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtRegisterDate" runat="server"  disabled="disabled" ></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckRegisterDate"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckRemarks"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox>
</td>
<td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtRemarks" ValidationGroup="SupplierVal" runat="server" ErrorMessage="!!!!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtRemarks" ValidationExpression="^[\u0590-\u05FF]{2,160}$" runat="server" ValidationGroup="SupplierVal" ErrorMessage="  ללא רווחים הכנס הערות בעברית בין 2 ל 160 תווים"></asp:RegularExpressionValidator>
   
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblSupplierCompany" runat="server" Text="SupplierCompany"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtSupplierCompany" runat="server"></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckSupplierCompany"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox>
</td>
<td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtSupplierCompany" ValidationGroup="SupplierVal" runat="server" ErrorMessage="!!!!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="SupplierVal" ValidationExpression="^[a-z]{2,100}$" ControlToValidate="txtSupplierCompany"  runat="server" ErrorMessage="הכנס שם ספק באנגלית מעל 2 תווים ועד 100 תווים"></asp:RegularExpressionValidator>
    
</td>
</tr>
<!--<tr>
<td>
    <asp:Label ID="lblSupplierCost" runat="server" Text="Label"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtSupplierCost" runat="server"></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckSupplierCost"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox><!-- מחיר שילוח -->
<!--</td>
</tr>-->
<tr>
<td>
    <asp:Label ID="lblShipmentTime" runat="server" Text="ShipmentTime"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtShipmentTime" runat="server"></asp:TextBox>
</td>
<td>
       <asp:TextBox id="mCheckShipmentTime"  runat="server" Text=" "  disabled="disabled"  Width="350px"></asp:TextBox><!-- זמן מישולח -->
</td>
<td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtShipmentTime" ValidationGroup="SupplierVal" runat="server" ErrorMessage="!!!!"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtShipmentTime" Type="Integer"  MinimumValue="1" MaximumValue="65" ValidationGroup="SupplierVal"  runat="server" ErrorMessage="הכנס זמן משלוח בין יום אחד ל 65 יום"></asp:RangeValidator>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblUserID" runat="server" Text="UserId"></asp:Label>
</td>
<td>
    <asp:TextBox ID="TxtId" disabled="disabled" runat="server"></asp:TextBox>
</td>
</tr>
</tr>
<tr>
<td>
    <asp:Button id="ButRSupplieregister" ValidationGroup="SupplierVal" CausesValidation="true" runat="server" Text="Register"   onclick="ButRSupplieregister_Click"   />
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
</td>
</tr>
</table>
</form>
</asp:Content>

