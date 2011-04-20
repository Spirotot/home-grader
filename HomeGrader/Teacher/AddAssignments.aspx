<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAssignments.aspx.cs" Inherits="Teacher_AddAssignments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Add Assignments<br />
    
    </div>
    <asp:Panel ID="chooseClassPanel" runat="server">
        Choose student:
        <asp:DropDownList ID="drpStudent" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Choose schoolyear:
        <asp:DropDownList ID="drpSchoolYear" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Choose semester:
        <asp:DropDownList ID="drpSemester" runat="server" AutoPostBack="True" 
            onselectedindexchanged="drpSemester_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Fall</asp:ListItem>
            <asp:ListItem>Spring</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Choose class:
        <asp:DropDownList ID="drpClass" runat="server" AutoPostBack="True" 
            onselectedindexchanged="drpClass_SelectedIndexChanged">
        </asp:DropDownList>
    </asp:Panel>
    <asp:Panel ID="addAssignmentPanel" runat="server">
        Add assigment to:
        <asp:Label ID="lblClassTitle" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Title:
        <asp:TextBox ID="txtAssignmentTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        Possible Score:
        <asp:TextBox ID="txtPossibleScore" runat="server"></asp:TextBox>
        <br />
        <br />
        Date:
        <asp:TextBox ID="txtDate" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
            onselectionchanged="Calendar1_SelectionChanged" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        <asp:Button ID="btnAddAssign" runat="server" onclick="btnAddAssign_Click" 
            Text="Add Assignment" />
    </asp:Panel>
    </form>
</body>
</html>
