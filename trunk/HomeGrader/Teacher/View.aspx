<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Teacher_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        View<br />
        <br />
        Student:
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Schoolyear:
        <asp:ListBox ID="DropDownList2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
            SelectionMode="Multiple">
        </asp:ListBox>
        <br />
        <br />
        Semester:
        <asp:ListBox ID="DropDownList3" runat="server" AutoPostBack="True" 
            SelectionMode="Multiple" 
            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
        </asp:ListBox>
        <br />
        <br />
        Classes:
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
            SelectionMode="Multiple"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="View" onclick="Button1_Click" />
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
