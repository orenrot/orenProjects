﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowAllDataList.aspx.cs" Inherits="admin_ShowAllDataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%if (Session["category"] != "admin")
      Response.Redirect("~/Homepage.aspx"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server"
    BackColor="LightGoldenrodYellow" RepeatColumns="4"     OnDeleteCommand="DataList1_DeleteCommand" 
    OnEditCommand="DataList1_EditCommand"   OnCancelCommand="DataList1_CancelCommand"   OnUpdateCommand="DataList1_UpdateCommand"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" >
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <ItemTemplate>
<span style="color:Blue">USER ID:</span>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label> <br/>
<span style="color:Blue">password:</span>
<asp:Label ID="Label2" runat="server" Text='<%# Eval("password") %>'></asp:Label> <br/>
<span style="color:Blue">firstname:</span>
<asp:Label ID="Label3" runat="server" text ='<%# Eval("firstname") %>'></asp:Label><br/>
<span style="color:Blue">lastname:</span>
<asp:Label ID="Label4" runat="server" text ='<%# Eval("lastname") %>'></asp:Label><br/>
<span style="color:Blue">DateBorn:</span>
<asp:Label ID="Label5" runat="server" text ='<%# Eval("DateBorn") %>'></asp:Label><br/>
<span style="color:Blue">email:</span>
<asp:Label ID="Label6" runat="server" text ='<%# Eval("email") %>'></asp:Label><br/>
<span style="color:Blue">address:</span>
<asp:Label ID="Label7" runat="server" text ='<%# Eval("address") %>'></asp:Label><br/>
<span style="color:Blue">phone:</span>
<asp:Label ID="Label8" runat="server" text ='<%# Eval("phonenumber") %>'></asp:Label><br/>
<span style="color:Blue">OptionInWeb:</span>
<asp:Label ID="Label9" runat="server" text ='<%# Eval("OptionInWeb") %>'></asp:Label><br/>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Delete" Text="Delete"> </asp:LinkButton>
</ItemTemplate>
        <AlternatingItemStyle BackColor="PaleGoldenrod" />
<EditItemTemplate>

<span style="color:Blue">USER ID:</span>

<asp:Label ID="txtUserName"    runat="server" Text='<%# Eval("UserName") %>'></asp:Label><br/>


<span style="color:Blue">password:</span>

<asp:TextBox ID="txtpassword" runat="server" Text='<%# Eval("password") %>'></asp:TextBox> <br/>
<span style="color:Blue">firstname:</span>

<asp:TextBox ID="txtfirstname" runat="server" text ='<%# Eval("firstname") %>'></asp:TextBox><br/>

<span style="color:Blue">lastname:</span>

<asp:TextBox ID="txtlastname" runat="server" text ='<%# Eval("lastname") %>'></asp:TextBox><br/>

<span style="color:Blue">DateBorn:</span>
<asp:Label ID="txtDateBorn"    runat="server" Text='<%# Eval("DateBorn") %>'></asp:Label><br/>


 <iframe width="120px" height="100px"  src="/users/Exercise09.aspx"><!--  יהיה דף של התארכים שאפשר לשנות כדי לשנות את תאריך הלידה של המשתמש-->
 
 </iframe>

<span style="color:Blue">email:</span>
<asp:TextBox ID="txtemail" runat="server" text ='<%# Eval("email") %>'></asp:TextBox><br/>

<span style="color:Blue">address:</span>
<asp:TextBox ID="txtaddress" runat="server" text ='<%# Eval("address") %>'></asp:TextBox><br/>

<span style="color:Blue">phone:</span>
<asp:TextBox ID="txtphonenumber" runat="server" text ='<%# Eval("phonenumber") %>'></asp:TextBox><br/>

<span style="color:Blue">OptionInWeb:</span>
<asp:TextBox ID="txtOptionInWeb" runat="server" text ='<%# Eval("OptionInWeb") %>'></asp:TextBox><br/>

<asp:LinkButton style="color:Black"  runat="server" ValidationGroup="ChangeRegisterVal" CausesValidation="true"  ID="LinkButton2" CommandName="update" Text="Update"> </asp:LinkButton>
<asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
       <table>
           <tr>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtpassword" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator Display="Dynamic"   ValidationGroup="ChangeRegisterVal" ID="RegularExpressionValidator8" ControlToValidate="txtpassword"  ValidationExpression="^\w{5,180}$" runat="server" ErrorMessage="בתויים ובאנגלית ומספרים בלבד הכנס סיסמא יותר מארבעה תווים"></asp:RegularExpressionValidator><!--  בודק שיש  \w יותר מארבע אותיות -->
             </td>
                      </tr>
           <tr>
               <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtfirstname" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator Display="Dynamic"   ValidationGroup="ChangeRegisterVal"  ID="RegularExpressionValidator9" ControlToValidate="txtfirstname"  ValidationExpression="^[\{\u0590-\u05FF}]{2,200}$" runat="server" ErrorMessage="הכנס שם פרטי חוקי בעברית בלבד"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין      ^               : begining of string
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
           <tr>

          <td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtLastname" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="ChangeRegisterVal" ID="RegularExpressionValidator10" ControlToValidate="txtLastname"  ValidationExpression="^[\{\u0590-\u05FF}]{2,150}$" runat="server" ErrorMessage=" הכנס שם משפחה חוקי בעברית בלבד"></asp:RegularExpressionValidator>
      </td>
               </tr>
           <tr>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtemail" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator11" ControlToValidate="txtemail"  ValidationExpression="^\w+\@\w+\.\w+$" runat="server" ErrorMessage="הכנס איימיל חוקי"></asp:RegularExpressionValidator><!--  בודק שיש  באיימיל שיש שטרודל ונקודה אחת שהאיימיל תקין-->
      </td>
                </tr>
           <tr>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtaddress" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator  ValidationGroup="ChangeRegisterVal" Display="Dynamic" ID="RegularExpressionValidator12" ControlToValidate="txtaddress"  ValidationExpression="^[\{\u0590-\u05FF}]{2,150}$" runat="server" ErrorMessage="בעברית הכנס כתובת חוקית"></asp:RegularExpressionValidator>
     </td>
                   </tr>
           <tr>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtphonenumber" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtphonenumber"  ValidationExpression="^\d{3}-\d{3}-\d{4}$" runat="server" ErrorMessage="הכנס מספר טלפון חוקי"></asp:RegularExpressionValidator><!--  בודק שיש 3 מספרים ראשונים ואז -  ולאחר מכן שלושה מספרים ואז - ועוד ארבעה מספרים-->
  </td>
                       </tr>
           <tr>
               <td>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator10"  ValidationGroup="ChangeRegisterVal" ControlToValidate="txtOptionInWeb" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" runat="server" ValidationGroup="ChangeRegisterVal" ControlToValidate="txtOptionInWeb" Type="Integer" MinimumValue="1" MaximumValue="4" ErrorMessage="הכנס מספר בין 1 ל 4 כולל"></asp:RangeValidator><!-- בודק שהערכים בין 1 ל 4 כולל -->
          </td>
                   </tr>
                </table>
</EditItemTemplate>
    </asp:DataList>


    <table>
 <tr>
 <td>
 <asp:DetailsView ID="DetailsView1" runat="server" OnItemUpdating="DetailsView1_ItemUpdating" Height="50px"   Width="125px" 
        BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal" AutoGenerateRows="false"
        headerText="CreditCard" AllowPaging="True" onpageindexchanging="DetailsView1_PageIndexChanging"
 OnItemDeleting="DetailsView1_ItemDeleting"  
        onmodechanging="DetailsView1_ModeChanging" BorderStyle="None">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EditRowStyle BackColor="#738A9C" ForeColor="#F7F7F7" Font-Bold="True" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" 
            HorizontalAlign="Right" />
         
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
         <Fields>
         <asp:TemplateField>
         <ItemTemplate>
      <span style="color:Blue">CreditCardValiditiy:</span>
<asp:Label ID="Label1" runat="server" Text='<%# Bind("CreditCardValiditiy") %>'></asp:Label> <br/>
<span style="color:Blue">CardNumber:</span>
<asp:Label ID="Label2" runat="server" Text='<%# Bind("CardNumber") %>'></asp:Label> <br/>
<span style="color:Blue">ExpirationDate:</span>
<asp:Label ID="Label3" runat="server" text ='<%# Bind("ExpirationDate") %>'></asp:Label><br/>
<span style="color:Blue">SecurityCode:</span>
<asp:Label ID="Label4" runat="server" text ='<%# Bind("SecurityCode") %>'></asp:Label><br/>
<span style="color:Blue">UserId:</span>
<asp:Label ID="Label5" runat="server" text ='<%# Bind("UserId") %>'></asp:Label><br/>
  <asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Delete" Text="Delete"> </asp:LinkButton>
</ItemTemplate>
<EditItemTemplate>
<table>
<tr>
<td>
<span style="color:Blue">CreditCardValiditiy:</span>
</td>
<td>
<asp:Label ID="Label1" runat="server" Text='<%# Bind("CreditCardValiditiy") %>'></asp:Label><br/>
</td>
</tr>
<tr>
<td>
<span style="color:Blue">CardNumber:</span>
</td>
<td>
    <asp:TextBox ID="txtCardNumber" runat="server"  Text='<%# Bind("CardNumber") %>'></asp:TextBox><br/>
    </td>
    </tr>
    <tr>
    <td>
<span style="color:Blue">ExpirationDate:</span>
</td>
        
<td>
<asp:Label ID="Label10" runat="server" text ='<%# Bind("ExpirationDate") %>'></asp:Label><br/>
   
    </td>
    <td>
    <iframe height="100px" width="200px" src="CardExpDate.aspx">
    
    </iframe>
    </td>
    </tr>

    <tr>
    <td>
<span style="color:Blue">SecurityCode:</span>
</td>
        
<td>
    <asp:TextBox ID="txtSecurityCode" runat="server"  Text='<%# Bind("SecurityCode") %>'></asp:TextBox><br/>
    
    </td>
    </tr>
    <tr>
    <td>
<span style="color:Blue">UserId:</span>
</td>
        
<td>
<asp:Label ID="Label5" runat="server" text ='<%# Bind("UserId") %>'></asp:Label><br/>
</td>
</tr>
</table>
<table>
<tr>
<td>
    <asp:RegularExpressionValidator  ValidationGroup="CheckCreditCardVal" Display="Dynamic"  ControlToValidate="txtCardNumber" ValidationExpression="^[\0-9]{2,160}$" ID="RegularExpressionValidator2" runat="server" ErrorMessage="הכנס כרטיס אשראי תקין עם מספרים"></asp:RegularExpressionValidator><!--  בדיקה שזה רק מספרים עם מינימום של 2 מספרים-->
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CheckCreditCardVal" ControlToValidate="txtCardNumber" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
     <asp:RegularExpressionValidator  ValidationGroup="CheckCreditCardVal"  ControlToValidate="txtSecurityCode" ValidationExpression="^[\0-9]{3}$" ID="RegularExpressionValidator4" runat="server" ErrorMessage="הכנס קודי סודי תקין בן 3 ספרות"></asp:RegularExpressionValidator><!--  בדיקה שהקוד הסודי הוא רק 3 ספרות-->
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="CheckCreditCardVal" ControlToValidate="txtSecurityCode" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
</td>
</tr>
</table>
    <asp:Button ID="Button1" CommandName="update" ValidationGroup="CheckCreditCardVal" CausesValidation="true" runat="server" Text="Button" />
    <asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
</EditItemTemplate>
         </asp:TemplateField>
         
         </Fields>
    </asp:DetailsView>
       </td>
            <td>
    <asp:DetailsView ID="DetailsView2" runat="server" Height="50px" Width="125px" 
        BackColor="White" BorderColor="#E7E7FF" BorderWidth="1px" 
        CellPadding="3" GridLines="Horizontal"  AutoGenerateRows="false"
        headerText="Supplier" AllowPaging="True"  BorderStyle="None"  OnItemUpdating="DetailsView2_ItemUpdating" 
         OnItemDeleting="DetailsView2_ItemDeleting"
        onmodechanging="DetailsView2_ModeChanging">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <EditRowStyle BackColor="#738A9C" ForeColor="#F7F7F7" Font-Bold="True" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" 
            HorizontalAlign="Right" />
           
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Fields>
         <asp:TemplateField>
         <ItemTemplate>
      <span style="color:Blue">SupplierId:</span>
<asp:Label ID="Label1" runat="server" Text='<%# Bind("SupplierId") %>'></asp:Label> <br/>
<span style="color:Blue">RegisterDate:</span>
<asp:Label ID="Label2" runat="server" Text='<%# Bind("RegisterDate") %>'></asp:Label> <br/>
<span style="color:Blue">Remarks:</span>
<asp:Label ID="Label3" runat="server" text ='<%# Bind("Remarks") %>'></asp:Label><br/>
<span style="color:Blue">SupplierCompany:</span>
<asp:Label ID="Label4" runat="server" text ='<%# Bind("SupplierCompany") %>'></asp:Label><br/>
<span style="color:Blue">ShipmentTime:</span>
<asp:Label ID="Label5" runat="server" text ='<%# Bind("ShipmentTime") %>'></asp:Label><br/>
<span style="color:Blue">UserId:</span>
<asp:Label ID="Label12" runat="server" text ='<%# Bind("UserId") %>'></asp:Label><br/>
               <asp:LinkButton style="color:Black" runat="server" ID="LinkButton1" CommandName="edit" Text="Edit"> </asp:LinkButton>
<asp:LinkButton style="color:Black" runat="server" ID="LinkButton4" CommandName="Delete" Text="Delete"> </asp:LinkButton>
</ItemTemplate>
<EditItemTemplate>
<table>
<tr>
<td>
<span style="color:Blue">SupplierId:</span>
</td>
<td>
<asp:Label ID="Label1" runat="server" Text='<%# Bind("SupplierId") %>'></asp:Label> <br/>
</td>
</tr>
<tr>
<td>
<span style="color:Blue">RegisterDate:</span>
</td>
<td>
    <asp:Label ID="txtRegisterDate" runat="server" Text='<%# Bind("RegisterDate") %>'></asp:Label><br/>
    </td>
    </tr>
    <tr>
    <td>
<span style="color:Blue">Remarks:</span>
</td>
<td>
    <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>'></asp:TextBox><br/>
    </td>
    </tr>
    <tr>
    <td>
<span style="color:Blue">SupplierCompany:</span>
</td>
<td>
    <asp:TextBox ID="txtSupplierCompany" runat="server"  Text='<%# Bind("SupplierCompany") %>'></asp:TextBox><br/>
    </td>
    </tr>
       <tr>
    <td>
<span style="color:Blue">ShipmentTime:</span>
</td>
<td>
    <asp:TextBox ID="txtShipmentTime" runat="server"  Text='<%# Bind("ShipmentTime") %>'></asp:TextBox><br/>
    </td>
    </tr>
    <tr>
    <td>
<span style="color:Blue">UserId:</span>
</td>
<td>
<asp:Label ID="Label5" runat="server" text ='<%# Bind("UserId") %>'></asp:Label><br/>
</td>
</tr>
</table>
<table>
<tr>
<td>
   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtRemarks" ValidationExpression="^[\u0590-\u05FF]{2,160}$" runat="server" ValidationGroup="CheckSupplier" ErrorMessage="  ללא רווחים הכנס הערות בעברית בין 2 ל 160 תווים"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="CheckSupplier" ControlToValidate="txtRemarks" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="CheckSupplier" ValidationExpression="^[a-z]{2,100}$" ControlToValidate="txtSupplierCompany"  runat="server" ErrorMessage="הכנס שם ספק באנגלית מעל 2 תווים ועד 100 תווים"></asp:RegularExpressionValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="CheckSupplier" ControlToValidate="txtSupplierCompany" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>

</td>
</tr>
    <tr>
<td>
      <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtShipmentTime" Type="Integer"  MinimumValue="1" MaximumValue="65" ValidationGroup="SupplierVal"  runat="server" ErrorMessage="הכנס זמן משלוח בין יום אחד ל 65 יום"></asp:RangeValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="CheckSupplier" ControlToValidate="txtShipmentTime" runat="server" ErrorMessage="!!"></asp:RequiredFieldValidator>

</td>
</tr>
</table>
    <asp:Button ID="Button1" CommandName="update" ValidationGroup="CheckSupplier" CausesValidation="true" runat="server" Text="Button" />
    <asp:LinkButton style="color:Black"   runat="server" ID="LinkButton3"  CommandName="cancel" Text="Cancel"> </asp:LinkButton>
</EditItemTemplate>
         </asp:TemplateField>
         
         </Fields>
    </asp:DetailsView>
     </td>
    </tr>
     </table>
    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
</asp:Content>


