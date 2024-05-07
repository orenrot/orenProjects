<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserRmarks.aspx.cs" Inherits="UserRmarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% if (Session["category"] == "admin")
       Response.Redirect("~/Homepage.aspx");
   if ((Session["Option"] == null || ((int)(Session["Option"]) < 0)))//בודק אם המשתמש קיים ואו המשתמש עם אפשרות פחות מאפס אז לא יתן לו להיכנס
       Response.Redirect("~/Homepage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   <asp:RegularExpressionValidator ValidationGroup="Re" ValidationExpression="^[\u0590-\u05fe]{3,100}$" runat="server" ControlToValidate="TextBox1" ErrorMessage="הכנס הערות בעברית בין 2 ל100 תווים ללא רווחים"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Re" ControlToValidate="TextBox1" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
    <asp:Button ID="Button1" runat="server" ValidationGroup="Re" CausesValidation="true" Text="Button" onclick="Button1_Click" />
</asp:Content>

