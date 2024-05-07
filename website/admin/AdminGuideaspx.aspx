<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminGuideaspx.aspx.cs" Inherits="admin_AdminGuideaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <% //if (Session["category"] != "admin")
  //    Response.Redirect("~/Homepage.aspx"); %> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div style=" width=100px; height=100px"></div>
    <div>
    <video src="../adminGuide/Admin%20Guide%202_2.mp4" controls="controls" style="height: 304px; width: 657px" />
        </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="to see full Admin guide" Font-Size="XX-Large" OnClick="Button1_Click"  />
        </div>
</asp:Content>

