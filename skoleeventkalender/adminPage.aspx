<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="skoleeventkalender.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS\generalStyle.css" rel="stylesheet" />    

    <title>Admin is root</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul align="center">
             <li><a href="">Calender</a></li>
             <li><a href="">Users</a></li>
             <li><a href=""></a></li>
         </ul>
    </div>
        <div>
            <asp:DropDownList ID="userdropdown" runat="server" OnLoad="userdropdown_onLoad" OnSelectedIndexChanged="userdropdown_SelectedIndexChanged"></asp:DropDownList> &nbsp;
            <asp:Button ID="select" runat="server" OnClick="select_Click" Text="Select" />
            <asp:Button ID="deletebtn" runat="server" Text="Delete" />
            <br />
            <span>Email</span><br />
            <asp:TextBox ID="emailtext" runat="server"></asp:TextBox><br />
            <span>Fornavn</span><br />
            <asp:TextBox ID="fornavntext" runat="server"></asp:TextBox><br />
            <span>Efternavn</span><br />
            <asp:TextBox ID="efternavntext" runat="server"></asp:TextBox><br />
            <span>fødselsdag</span><br />
            Year: <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList> 
           
            Month: <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="ddlMonth_SelectedIndexChanged">
            </asp:DropDownList> 
       
            Day: <asp:DropDownList ID="ddlDay" runat="server">
            </asp:DropDownList> <br />
            <span>Password</span><br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox><br />
            <span>Password bekræft</span><br />
            <asp:TextBox ID="passwordconfirm" runat="server"></asp:TextBox><br />
            <asp:CheckBox ID="isadmin" runat="server" />
            <span>Admin?</span> <br />
            <asp:Button ID="editbtn" Text="Edit" runat="server" />

        </div>
    </form>
</body>
</html>
