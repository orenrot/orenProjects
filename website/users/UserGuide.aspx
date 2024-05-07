<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserGuide.aspx.cs" Inherits="users_UserGuide" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <% if (Session["category"] == "admin")//אם מנהל
       Response.Redirect("~/Homepage.aspx");
   if ((Session["Option"] == null || ((int)(Session["Option"]) < 0)))//בודק אם המשתמש קיים ואו המשתמש עם אפשרות פחות מאפס אז לא יתן לו להיכנס
       Response.Redirect("~/Homepage.aspx"); %>
    <div  style="width=1000px; height=1000px"></div>
  <!-- <iframe src="../UserGuide/User Guide 2.ppsm"></iframe>
      
    <iframe src="https://drive.google.com/open?id=1_ugLZI_JnLj5TNADJejS7jW34YXvh0oy"></iframe>-->
    <div>
    <video  src="../UserGuide/User%20Guide%202%20(2).mp4" controls="controls" style="height: 515px; width: 883px" />
        </div>
    <div>
    <asp:Button ID="Button1" runat="server" Text="to see full user guide" Font-Size="XX-Large" OnClick="Button1_Click" />
        </div>
   <!-- <iframe   src="../UserGuide/User Guide 2 (2).html" style="height: 686px; width: 71%; margin-left: 0px" ></iframe>-->
</asp:Content>

