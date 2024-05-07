<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<%@ Register src="WebUserControlTrying.ascx" tagname="WebUserControlTrying" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%
//    if (Session["Option"] == null || (int)Session["Option"] < 2 || Session["SelecteValue"] == null || Session["username"] == null)
  //      Response.Redirect("Homepage.aspx");
    if (Session["SelecteValue"] == null)//אם הגיע לעמוד בלי להיות בעמוד שבו נשמר המספר הייחודי של המוצר עליו לחזור עליו
        Response.Redirect("/generalInfo/BuyingProducts.aspx");
     %>
   <!-- <script type="text/javascript">
        function EabyOrAliex()
        {

            var a = window.prompt("are you want to compare price with eaby or aliexpress or both sites (ebay/aliexpress/both)");
            if(a=="aliexpress")
              
        }

    </script>-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div ></div>
    <asp:Label ID="Label3" runat="server" Text="Which Company YOU WNAT TO COMPARE"></asp:Label>
     <asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Text="ebay" Value="ebay">ebay</asp:ListItem>
       <asp:ListItem Text="amazon" Value="amazon">amazon</asp:ListItem>
        <asp:ListItem Text="gearbest" Value="gearbest">gearbest</asp:ListItem>
        <asp:ListItem Text="all" Value="all">all</asp:ListItem>
     </asp:DropDownList>
        <asp:TextBox ID="TextSearch" runat="server" ></asp:TextBox>
      <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
    <asp:Label ID="lblShowProduct" runat="server" Text=""></asp:Label>
        <asp:Image ID="Image1" runat="server" />
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:ImageButton   ImageUrl="/pic/Add-To-Cart-Button-PNG-Pic.png"  
        ID="ImageButton1"  runat="server" Height="80px" Width="249px" 
        onclick="ImageButton1_Click" />
         <asp:ImageButton   ImageUrl="/pic/whislist.png"
        ID="ImageButton2"  runat="server" Height="80px" Width="249px" 
        onclick="ImageButton2_Click" />
    <uc1:WebUserControlTrying ID="WebUserControlTrying1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
     <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 
</asp:Content>

