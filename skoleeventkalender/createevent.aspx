<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createevent.aspx.cs" Inherits="skoleeventkalender.createevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/generalStyle.css" rel="stylesheet" />
    <link href="CSS/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Event name<br />
        <asp:TextBox ID="eventName" runat="server"></asp:TextBox>
    <br />
        <br />
        <br />
        Start date<br />
    Year: <asp:DropDownList ID="ecStartYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecStartYear_SelectedIndexChanged" ></asp:DropDownList> 
           
    Month: <asp:DropDownList ID="ecStartMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecStartMonth_SelectedIndexChanged">
        </asp:DropDownList> 
       
    Day: <asp:DropDownList ID="ecStartDay" runat="server" AutoPostBack="True" onselectedindexchanged="ecStartDay_SelectedIndexChanged">
        </asp:DropDownList> <br />

        <br />
        End date<br />
    Year: <asp:DropDownList ID="ecEndYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecEndYear_SelectedIndexChanged" ></asp:DropDownList> 
           
    Month: <asp:DropDownList ID="ecEndMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecEndMonth_SelectedIndexChanged">
        </asp:DropDownList> 
       
    Day: <asp:DropDownList ID="ecEndDay" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ecEndDay_SelectedIndexChanged">
        </asp:DropDownList> <br />
        <br />
        <br />
        Event type:
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        <br />
        <br />
        <br /> 
        Event description <br /> 
     <asp:TextBox ID="TextBox1" runat="server" Height="191px" Width="342px"></asp:TextBox>
        <br />
        <br />
        <asp:Button CssClass="btn" ID="eventCreateBtn" runat="server" Text="Create" OnClick="eventCreateBtn_Click" /> 
        <asp:Button CssClass="btn" ID="eventCancelBtn" runat="server" Text="Cancel" OnClick="eventCancelBtn_Click" />
    </div>
       
    </form>
</body>
</html>
