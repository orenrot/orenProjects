<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="XmlSchema.aspx.cs" Inherits="XmlSchema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<% if (Session["username"] == null || Session["category"] == "admin")
       Response.Redirect("~/HomePage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

