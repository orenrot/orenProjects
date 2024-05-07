<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CardExpDate.aspx.cs" Inherits="CardExpDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <% Session["YearBorn"] = DropDownListBirthYear.SelectedValue;//משתנים שישמור על ערכי הלידה של האדם כך שאוכל בדף המנהל לשנות אותם לתאריך אחר
           Session["MonthBorn"] =  DropDownListBirthMonth.SelectedValue;
           Session["DayBorn"] = DropDownListBirthDay.SelectedValue;
            %>
        <form id="form1" runat="server">
        <asp:DropDownList ID="DropDownListBirthMonth" runat="server" AutoPostBack="True"
            Height="30px" OnSelectedIndexChanged="DropDownListBirthMonth_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="1">1</asp:ListItem>
          
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListBirthYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListBirthYear_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="2018">2018</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelMonth" runat="server" Style="z-index: 105; left: 670px; position: absolute;
            top: 219px" Text=":חודש" Width="49px"></asp:Label>
        <asp:Label ID="LabelYear" runat="server" Style="z-index: 106; left: 749px; position: absolute;
            top: 216px" Text=":שנה  " Width="58px"></asp:Label>
        <asp:DropDownList ID="DropDownListBirthDay"   runat="server"  AutoPostBack="true">
                      <asp:ListItem Selected="True" Value="0">none</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelDay" runat="server" Style="z-index: 108; left: 599px; position: absolute;
            top: 218px" Text=":יום" Width="41px"></asp:Label>
            </form>
</body>
</html>
