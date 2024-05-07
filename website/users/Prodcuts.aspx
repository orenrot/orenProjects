<%@ Page Title="Products" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Prodcuts.aspx.cs" Inherits="Prodcuts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%
 if (Session["Option"]==null  || ((int)(Session["Option"]) < 3)   )//בדיקה שהאדם רשאי להיכנס לעמוד זה שהוא ספק  שהאפשרות של האפשרות באתר לא ריקה וגם האפשרות גדולה מ 3
       Response.Redirect("~/Homepage.aspx");
     %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table >
<tr>
<td>
    <asp:Label id="LblID" runat="server" Text="Id"></asp:Label>
</td><td>
    <asp:TextBox id="txtID" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckId" runat="server" Text="" disabled="disabled"    Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ProductVal" ControlToValidate="txtID" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtID" Type="Integer" ValidationGroup="ProductVal" runat="server" MinimumValue="1" MaximumValue="100000" ErrorMessage="RangeValidator"></asp:RangeValidator>
       
    </td>
</tr>
<tr>
<td>
    <asp:Label id="LblType" runat="server" Text="Type"></asp:Label>
</td><td>
    <asp:TextBox id="txtType" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckType" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ProductVal" ControlToValidate="txtType" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ProductVal" ControlToValidate="txtType" ValidationExpression="^[a-z]{2,160}$" runat="server" ErrorMessage="הכנס סוג צעצוע באנגלית באותיות קטנות בלבד"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="LblAmount" runat="server" Text="Amount"></asp:Label>
</td><td>
    <asp:TextBox id="txtAmount" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckAmount" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ProductVal" ControlToValidate="txtAmount"   runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" ValidationGroup="ProductVal" Type="Integer" ControlToValidate="txtAmount" MinimumValue="1" MaximumValue="1000" runat="server" ErrorMessage="הכנס כמות בין 1 ל 1000"></asp:RangeValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="LblCompanyName" runat="server" Text="CompanyName"></asp:Label>
</td><td>
    <asp:TextBox id="txtCompanyName" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckCompanyName" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCompanyName" ValidationGroup="ProductVal" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtCompanyName" ValidationGroup="ProductVal" ValidationExpression="^[a-z]{2,160}$" runat="server" ErrorMessage="הכנס שם חברה באנגלית בלבד ללא רווחים"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="LblPrice" runat="server" Text="Price"></asp:Label>
</td><td>
    <asp:TextBox id="txtPrice" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckPrice" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ProductVal" ControlToValidate="txtPrice" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator3" ControlToValidate="txtPrice" Type="Integer" MinimumValue="1" MaximumValue="100000" runat="server" ValidationGroup="ProductVal"  ErrorMessage="הכנס מחיר בין 1 ל 100000 "></asp:RangeValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="lblProductName" runat="server" Text="ProductName"></asp:Label>
</td><td>
    <asp:TextBox id="txtProductName" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckProductName" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ProductVal" ControlToValidate="txtProductName"  runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtProductName" ValidationExpression="^[a-z]{2,160}$" ValidationGroup="ProductVal"  runat="server" ErrorMessage="הכנס שם מוצר באנגלית באותיות קטנות בלבד ללא רווחים"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label id="lblSupplier" runat="server" Text="Supplier"></asp:Label>
</td><td>
    <asp:TextBox id="TextBox1" runat="server" disabled="disabled" ></asp:TextBox></td>
</tr>
<tr>
<td>
    <asp:Label id="lblProductQuality" runat="server" Text="ProductQuality"></asp:Label>
</td><td>
    <asp:TextBox id="txtProductQuality" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckProductQuality" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  ValidationGroup="ProductVal" ControlToValidate="txtProductQuality"  runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator4"  runat="server" Type="Integer" ValidationGroup="ProductVal" ControlToValidate="txtProductQuality" MinimumValue="1" MaximumValue="5" ErrorMessage="הכנס איכות מוצר בין 1 ל 5"></asp:RangeValidator>
    </td>
</tr>
    <tr>
<td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    </td>
     <td>
        <asp:TextBox id="mCheckFileUpload" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
         
    </td>
        <td>
            <asp:CustomValidator ID="CustomValidator1" runat="server"  ValidationGroup="ProductVal" ControlToValidate="FileUpload1" ErrorMessage="File size should not be greater than 4 MB." OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="ProductVal" ControlToValidate="FileUpload1" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="ProductVal" ControlToValidate="FileUpload1"  ValidationExpression="^(.*?)\.(jpg|jpeg|png|JPG|JPEG|PNG)$"  runat="server" ErrorMessage="הכנס רק קבצי תמונות"></asp:RequiredFieldValidator>
        </td>
</tr>
<tr>
<td>
    <asp:Label id="lblShipmentCost" runat="server" Text="ShipmentCost"></asp:Label>
</td><td>
    <asp:TextBox id="txtShipmentCost" runat="server"></asp:TextBox></td>
    <td>
        <asp:TextBox id="mCheckShipmentCost" runat="server" Text="" disabled="disabled"  Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ProductVal" ControlToValidate="txtShipmentCost" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtShipmentCost" Type="Integer" ValidationGroup="ProductVal" MinimumValue="0" MaximumValue="100000" runat="server" ErrorMessage="100000 הכנס מחיר משלוח בין 0 ל "></asp:RangeValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Button id="ButRegister" runat="server" Text="enter Product"  ValidationGroup="ProductVal" CausesValidation="true"  onclick="ButRegister_Click"  />
</td>
</tr>
</table >
    <asp:Label id="lblmessage" runat="server" Text=""></asp:Label>
        <asp:Button id="Butclear" runat="server" Text="clear"  onclick="Butclear_Click"  />
    <asp:Image ID="Image1" runat="server" />
    <asp:Label ID="Message" runat="server" Text="Label"></asp:Label>
</asp:Content>

