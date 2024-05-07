<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditCard.aspx.cs" Inherits="CreditCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%
    if (Session["Option"]==null  || ((int)(Session["Option"])) < 2)
      Response.Redirect("~/Homepage.aspx");//לתקיית שורש לתקייה 
//    int a = (int)Session["Option"];
 //   Console.WriteLine(a);
 //   Label3.Text = a.ToString();
     %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="Buyer"  method="post" action="CreditCard.aspx">
    <table>
    <tr>
<td>
    <asp:Label id="LblCreditCard" runat="server" Text="CreditCard"></asp:Label>
</td><td>
    <asp:TextBox id="txtCreditCard"    runat="server"></asp:TextBox></td>
    <td class="style1">
        <asp:TextBox id="mCheckCreditCard"  runat="server" Text=" "  disabled="disabled"    Width="350px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CreditCardVal" ControlToValidate="txtCreditCard" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ValidationGroup="CreditCardVal" ControlToValidate="txtCreditCard" ValidationExpression="^[\0-9]{2,160}$" ID="RegularExpressionValidator1" runat="server" ErrorMessage= " הכנס כרטיס אשראי תקין עם מספרים ויחודי"></asp:RegularExpressionValidator>
 </td>
</tr>
<tr>
<td>
    <asp:Label id="LblCardNumber" runat="server" Text="CardNumber"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtCardNumber"   runat="server"> </asp:TextBox> </td>
    <td>
        <asp:TextBox id="mCheckCardNumber" runat="server"  disabled="disabled"  Width="350px"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="CreditCardVal"  ControlToValidate="txtCardNumber"  runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator  ValidationGroup="CreditCardVal"  ControlToValidate="txtCardNumber" ValidationExpression="^[\0-9]{2,160}$" ID="RegularExpressionValidator2" runat="server" ErrorMessage="הכנס כרטיס אשראי תקין עם מספרים"></asp:RegularExpressionValidator><!--  בדיקה שזה רק מספרים עם מינימום של 2 מספרים-->
   </td>
</tr>
<tr>
<td>
    <asp:Label id="lblExpirationDate" runat="server" Text="ExpirationDate"></asp:Label>
</td>
<td>
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
    </td>
<td>
        <asp:TextBox id="mCheckExpirationDate" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="LblSecurityCode" runat="server" Text="SecurityCode"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtSecurityCode" runat="server"></asp:TextBox>
</td>
<td class="style1">
        <asp:TextBox id="mCheckSecurityCode" runat="server" Text="" disabled="disabled" 
            Width="350px"></asp:TextBox>
    </td>
     <td>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="CreditCardVal"  ControlToValidate="txtSecurityCode" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator  ValidationGroup="CreditCardVal"  ControlToValidate="txtSecurityCode" ValidationExpression="^[\0-9]{3}$" ID="RegularExpressionValidator3" runat="server" ErrorMessage=" הכנס קודי סודי תקין בן 3 ספרות"></asp:RegularExpressionValidator><!--  בדיקה שהקוד הסודי הוא רק 3 ספרות-->
</td>
</tr>
<tr>
<td>
    <asp:Label id="LblId" runat="server" Text="Id"></asp:Label>
</td><td>
    <asp:TextBox id="txtId"  disabled="disabled"  runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>
    <asp:Button id="ButRegister" runat="server" Text="enter Credit Card"   ValidationGroup="CreditCardVal" CausesValidation="true" onclick="ButRegister_Click"  />
</td>
</tr>
</table >
</form>
    <asp:Label id="lblmessage" runat="server" Text=""></asp:Label>
        <asp:Button id="Butclear" runat="server" Text="clear"  onclick="Butclear_Click"  />
</asp:Content>

