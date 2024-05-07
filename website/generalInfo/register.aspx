<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="NewRegisterWithValaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table >
    <tr>
<td>
    <asp:Label id="LblUsername" runat="server" Text="Username"></asp:Label>
</td><td>
    <asp:TextBox id="txtUsername"  runat="server"></asp:TextBox></td>
    <td>
    <asp:RequiredFieldValidator ControlToValidate="txtUsername" ValidationGroup="registerVal"   ID="RequiredFieldValidator7" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ValidationGroup="registerVal" ID="RegularExpressionValidator4" ControlToValidate="txtUsername"  ValidationExpression="^[\u0590-\u05FF]{2,160}$" runat="server" ErrorMessage="הכנס שם משתמש יותר משני תווים בעברית בלבד ללא רווחים "></asp:RegularExpressionValidator><!--  בודק שיש  בסיסמא שהיא אוכה יותר משלושה תווים -->
    </td>
   
</tr>
<tr>
<td>
    <asp:Label id="LblPassword" runat="server" Text="Password"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtpassword" TextMode="Password"  runat="server"> </asp:TextBox> </td>
   <td>
         <asp:RequiredFieldValidator ControlToValidate="txtpassword" ValidationGroup="registerVal"    ID="RequiredFieldValidator6" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator   ValidationGroup="registerVal" ID="RegularExpressionValidator3" ControlToValidate="txtpassword"  ValidationExpression="^\w{5,180}$" runat="server" ErrorMessage="בתויים ובאנגלית ומספרים בלבד הכנס סיסמא יותר מארבעה תווים"></asp:RegularExpressionValidator><!--  בודק שיש  \w יותר מארבע אותיות -->
    </td>
</tr>
<tr>
<td>
    <asp:Label id="lblemail" runat="server" Text="email"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtemail" runat="server"> </asp:TextBox>
</td>
           <td>
               <asp:RequiredFieldValidator ControlToValidate="txtemail" ValidationGroup="registerVal"   ID="RequiredFieldValidator5" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ValidationGroup="registerVal" ID="RegularExpressionValidator2" ControlToValidate="txtemail"  ValidationExpression="^\w+\@\w+\.\w+$" runat="server" ErrorMessage=" הכנס איימיל חוקי למשל a@gmail.com"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין-->
   </td>
</tr>
<tr>
<td>
    <asp:Label id="Lblfirstname" runat="server" Text="firstname"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtfirstname"   runat="server"></asp:TextBox>
</td>
    <td> 
  <asp:RequiredFieldValidator ControlToValidate="txtfirstname" ValidationGroup="registerVal"   ID="RequiredFieldValidator4" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ValidationGroup="registerVal"  ID="RegularExpressionValidator5" ControlToValidate="txtfirstname"  ValidationExpression="^[\{\u0590-\u05FF}]{2,200}$" runat="server" ErrorMessage="הכנס שם פרטי חוקי בעברית בלבד"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין      ^               : begining of string
           [\{\u0590-\u05FF} | \{ a-zA-Z}]{2,200}//עושה מילה אם אותיות באנגלית ועברית 
           לעשות  בסוף
    [             : start class character
      \p{Hebrew}  : a hebrew character
                  : a space
      a-zA-Z      : a latin letter
    ]             : end of class
    {2,15}        : previous chars 2 to 15 times
  $               : end of string      -->
   </td>
</tr>
<tr >
<td>
    <asp:Label id="LblName" runat="server" Text="LastName"></asp:Label>
</td><td>
    <asp:TextBox id="txtLastname"   runat="server"></asp:TextBox></td>
     <td> 
            <asp:RequiredFieldValidator ControlToValidate="txtLastname" ValidationGroup="registerVal"   ID="RequiredFieldValidator3" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ValidationGroup="registerVal" ID="RegularExpressionValidator6" ControlToValidate="txtLastname"  ValidationExpression="^[\{\u0590-\u05FF}]{2,150}$" runat="server" ErrorMessage=" הכנס שם משפחה חוקי בעברית בלבד ללא רווחים"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין      ^               : begining of string
    [             : start class character
      \p{Hebrew}  : a hebrew character
                  : a space
      a-zA-Z      : a latin letter
    ]             : end of class
    {2,15}        : previous chars 2 to 15 times
  $               : end of string      -->
   </td>
</tr>

<tr>
<td>
    <asp:Label id="LblYear" runat="server" Text="Year"></asp:Label>
</td><td>
   <asp:DropDownList id="ddlYear"  AutoPostBack="true"    runat="server" 
        onselectedindexchanged="ddlYear_SelectedIndexChanged" >
      
        </asp:DropDownList>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="lblmonth"  runat="server" Text="month"></asp:Label>
</td>
<td>
 <asp:DropDownList id="ddlmonth"  AutoPostBack="true"  runat="server" 
        onselectedindexchanged="ddlMonths_SelectedIndexChanged">
        </asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Label id="LblDay"  runat="server" Text="Day"></asp:Label>
</td>
<td>
           <asp:DropDownList id="ddlDay" AutoPostBack="true" runat="server" >
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
    <asp:Label id="lbladdress" runat="server" Text="address"></asp:Label>
</td>
<td>
    <asp:TextBox id="txtaddress"   runat="server"></asp:TextBox>
</td>
     <td> 
          <asp:RequiredFieldValidator ControlToValidate="txtaddress" ValidationGroup="registerVal"   ID="RequiredFieldValidator2" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator ValidationGroup="registerVal" ID="RegularExpressionValidator7" ControlToValidate="txtaddress"  ValidationExpression="^[\{\u0590-\u05FF}]{2,150}$" runat="server" ErrorMessage=" ללא רווחים  בעברית בלבד הכנס כתובת חוקית למשל חיפה תלאביב"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין      ^               : begining of string
    [             : start class character
      \p{Hebrew}  : a hebrew character
                  : a space
      a-zA-Z      : a latin letter
    ]             : end of class
    {2,15}        : previous chars 2 to 15 times
  $               : end of string      -->
   </td>
</tr>
<tr>
<td>
    <asp:Label id="Lblphone" runat="server" Text="phone Number"></asp:Label>
</td>
<td>
    <asp:TextBox id="Txtphone"   runat="server"></asp:TextBox>
</td>
       <td> <asp:RequiredFieldValidator ControlToValidate="Txtphone" ValidationGroup="registerVal"   ID="RequiredFieldValidator1" runat="server" ErrorMessage="!!!"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator    ValidationGroup="registerVal" ID="RegularExpressionValidator1" ControlToValidate="Txtphone"  ValidationExpression="^\d{3}-\d{3}-\d{4}$" runat="server" ErrorMessage="  הכנס מספר טלפון חוקי למשל 085-999-9999"></asp:RegularExpressionValidator><!--  בודק שיש 3 מספרים ראשונים ואז -  ולאחר מכן שלושה מספרים ואז - ועוד ארבעה מספרים-->
   </td>
</tr>
<tr>
<td>
    <asp:Button id="ButRegister" ValidationGroup="registerVal"   CausesValidation="true"     runat="server" Text="Register" OnClick="ButRegister_Click"     />
</td><!--  https://www.codeproject.com/Questions/125323/I-want-both-RequiredFieldValidator-and-onClientCli -->
</tr>
</table  >
    <asp:Label id="lblmessage"  runat="server" Text="" ></asp:Label>
        <asp:Button id="Butclear" runat="server" Text="clear"  onclick="Butclear_Click"  />
</asp:Content>

