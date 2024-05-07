<%@ Page Title="home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Products</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<body>
    <asp:Button ID="Button1" runat="server" Text="users online" 
        onclick="butUsers_Click" />
    <asp:Label ID="LblUsers" runat="server" Text=" "></asp:Label>
  <a href="/generalInfo/Games.aspx">משחק</a>
    <div style="text-align:center; height:540px; width:100%">
    <h1  style="color:black; text-align:right"> ?למה וולט דיסני</h1>
   <h2  style="color:red"  >
 בגלל שעשה את סרט הקולנוע המונפש הראשון באורך מלא היה שלגיה ושבעת הגמדים
   </h2>
   <h3 style="color:Orange; font-size:72px">
   .צעצוע של סיפור - סרט ההנפשה הממוחשבת הראשון באורך מלא בו נעשה שימוש בטכניקות עבודה בתלת-ממד. בסרט זה נעשה שימוש ב-117 מחשבים נפרדים (פועלים במקביל) שכללו 294 מעבדים. פעולה זו ארכה, בחישוב כולל, כ-800,000 שעות מעבד
   </h3>
    <!--    <audio src="music/Sofia%20Reyes,%20Rita%20Ora,%20Anitta%20-%20R.%20I.%20P.%20Ringtone.mp3"  autoplay loop />-->
      
    <!--https://stackoverflow.com/questions/9157352/how-to-open-windows-form-control-in-a-web-page-->
    </div>
 
  
  <!-- <iframe  src="music/Sofia%20Reyes,%20Rita%20Ora,%20Anitta%20-%20R.%20I.%20P.%20Ringtone.mp3" allow="autoplay" id="audio" style="display:none"></iframe>-->
 
</body>
</asp:Content>

