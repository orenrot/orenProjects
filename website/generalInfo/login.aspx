<%@ Page Title="login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<p>
התחברות
</p>
<table>
<tr>
<td>
         <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
</td>
<td>
         <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>   
</td>
    <td>
         <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" ControlToValidate="txtUsername" runat="server" ErrorMessage="חייב למלות"></asp:RequiredFieldValidator>
     <!--   <asp:RegularExpressionValidator Display="Dynamic"  ID="RegularExpressionValidator4" ControlToValidate="txtUsername"  ValidationExpression="^[\u0590-\u05FF]{2,160}$" runat="server" ErrorMessage="הכנס שם משתמש יותר משני תווים בעברית בלבד "></asp:RegularExpressionValidator><!--  בודק שיש  בסיסמא שהיא אוכה יותר משלושה תווים -->
    </td>
</tr>
<tr>
<td>
&nbsp;
</td>
</tr>
<tr>
<td>
             <asp:Label  ID="LblPassword" runat="server" Text="Password"></asp:Label>
</td>
<td>
             <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
</td>
    <td>
        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" ControlToValidate="txtpassword" runat="server" ErrorMessage="חייב למלות"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator  Display="Dynamic"   ID="RegularExpressionValidator3" ControlToValidate="txtpassword"  ValidationExpression="^\w{5,180}$" runat="server" ErrorMessage="בתויים ובאנגלית ומספרים בלבד הכנס סיסמא יותר מארבעה תווים"></asp:RegularExpressionValidator><!--  בודק שיש  \w יותר מארבע אותיות -->
    </td>
</tr>


</table>
    <asp:Button ID="ButLogin" runat="server" Text="Login"  onclick="ButLogin_Click" />
     <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
    <asp:Label ID="Lbltry" runat="server" Text=""></asp:Label>
</div>
</asp:Content>

