<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewer.aspx.cs" Inherits="viewer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
    if ((Session["Option"] == null || (int)(Session["Option"]) < 1) && Session["category"] != "admin")//כל מי שהוא משתמש וגם מנהל יוכל לגשת לעמוד וגם מנהל אחרת יעוף או לא יורשה לגשת לעמוד
     Response.Redirect("~/Homepage.aspx");
     %>
     <script  type="text/javascript">
    var a= [100];
    a[0]='https://www.youtube.com/embed/NRg2e6kY2wg';
     a[1]='https://www.youtube.com/embed/xHpH11hiWfg';
     a[2]='https://www.youtube.com/embed/mKxaIlbrTgA';
     a[3] = 'https://www.youtube.com/embed/Fxr4VIMLzAw';
     a[4] = 'https://www.youtube.com/embed/GibiNy4d4gc';
     a[5] = 'https://www.youtube.com/embed/hZ1Rb9hC4JY';
     a[6] = 'https://www.youtube.com/embed/ZSS5dEeMX64?list=PLdSMQMuTYK4A2e67n5JcmjQQODoRK4S-6';
     a[7] = 'https://www.youtube.com/embed/TrRbB-qUJfY';
     a[8] = 'https://www.youtube.com/embed/9ogQ0uge06o?list=PLdSMQMuTYK4A2e67n5JcmjQQODoRK4S-6';
     a[9] = 'https://www.youtube.com/embed/glDGAo9SIqs?list=PLdSMQMuTYK4A2e67n5JcmjQQODoRK4S-6';
     a[10] = 'https://www.youtube.com/embed/LKTU4AarZ7A?list=PLdSMQMuTYK4A2e67n5JcmjQQODoRK4S-6';
     a[11] = 'https://www.youtube.com/embed/_f46KqqPheU';
     a[12] = 'https://www.youtube.com/embed/rlTOGVkmh3c';
     a[13] = 'https://www.youtube.com/embed/-I4Afmo5N2Q';
     a[14] = 'https://www.youtube.com/embed/zc3MnoSS5Hw?list=PLdSMQMuTYK4A2e67n5JcmjQQODoRK4S-6';
    var s= Math.floor(Math.random() * 14) + 1;
         function Change() {
             document.getElementById("1").src = a[s];
             s = Math.floor(Math.random() * 14) + 1;
             document.getElementById("2").src = a[s];
             s = Math.floor(Math.random() *14) + 1;
             document.getElementById("3").src = a[s];
             s = Math.floor(Math.random() * 14) + 1;
             document.getElementById("4").src = a[s];
         }
     
     
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div></div>
    <table>
<tr>
<td>
 האם אתה מעוניין לחפש את הדירוג של סרטים דומים?
</td>
<td>
    <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" >
    <asp:ListItem Text="imdb" Value="imdb">imdb</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="TextSearch" runat="server" ></asp:TextBox>
    <!--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ControlToValidate="TextSearch" ValidationExpression="^[a-z]{2,160}$"   runat="server" ErrorMessage="הכנס מה שאתה מחפש באותיות קטנות באנגלית בלבד"></asp:RegularExpressionValidator>-->
    </td>
    <td>
        <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
    </td>
    </tr>
</table>
<iframe id= "1"  width="854" height="480" src="https://www.youtube.com/embed/mKxaIlbrTgA" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
<iframe id= "2" width="854" height="480" src="https://www.youtube.com/embed/Fxr4VIMLzAw" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
<iframe id="3" width="854" height="480" src="https://www.youtube.com/embed/YKWGQyz-oLw" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
<iframe id="4" width="854" height="480" src="https://www.youtube.com/embed/zyJBNu2B6ys" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen></iframe>
<label onclick="return Change()" >ChangeMovies</label>
</asp:Content>

