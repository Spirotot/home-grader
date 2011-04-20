<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateClass.aspx.cs" Inherits="Teacher_CreateClass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Create Class<br />
        <br />
        Title:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        Schoolyear (e.g. 2007/2008):
        <asp:TextBox ID="TextBox3" runat="server" Width="50px"></asp:TextBox>
        /<asp:TextBox ID="TextBox4" runat="server" Width="50px"></asp:TextBox>
        <br />
        <br />
        Grade:<br />
&nbsp;<asp:ListBox ID="ListBox1" runat="server">
            <asp:ListItem Selected="True" Value="12">Grade 12</asp:ListItem>
            <asp:ListItem Value="11">Grade 11</asp:ListItem>
            <asp:ListItem Value="10">Grade 10</asp:ListItem>
            <asp:ListItem Value="9">Grade 9</asp:ListItem>
            <asp:ListItem Value="8">Grade 8</asp:ListItem>
            <asp:ListItem Value="7">Grade 7</asp:ListItem>
            <asp:ListItem Value="6">Grade 6</asp:ListItem>
            <asp:ListItem Value="5">Grade 5</asp:ListItem>
            <asp:ListItem Value="4">Grade 4</asp:ListItem>
            <asp:ListItem Value="3">Grade 3</asp:ListItem>
            <asp:ListItem Value="2">Grade 2</asp:ListItem>
            <asp:ListItem Value="1">Grade 1</asp:ListItem>
            <asp:ListItem Value="0">Kindergarten</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        Semester:
          <asp:DropDownList ID="drpSemester" runat="server">
              <asp:ListItem>Fall</asp:ListItem>
              <asp:ListItem>Spring</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Create Class" />
    
    </div>
    </form>
</body>
</html>
