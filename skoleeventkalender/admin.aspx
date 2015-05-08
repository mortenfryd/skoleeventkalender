<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="skoleeventkalender.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <ul align="center">
             <li><a href="eventview.aspx">Calender</a></li>
         </ul>
    </div>
        <div class="login_page">
            <asp:DropDownList CssClass="textboxUser" ID="userdropdown" runat="server" OnLoad="userdropdown_onLoad" OnSelectedIndexChanged="userdropdown_SelectedIndexChanged"></asp:DropDownList> &nbsp;
            <asp:Button ID="select" CssClass="btn" runat="server" OnClick="select_Click" Text="Select" />
            <asp:Button ID="deletebtn" CssClass="btn" runat="server" Text="Delete" OnClick="deletebtn_Click" />
            <br />
            <span>Email</span><br />
            <asp:TextBox ID="emailtext" CssClass="textboxUser" runat="server"></asp:TextBox><br />
            <span>Fornavn</span><br />
            <asp:TextBox ID="fornavntext" CssClass="textboxUser" runat="server"></asp:TextBox><br />
            <span>Efternavn</span><br />
            <asp:TextBox ID="efternavntext" CssClass="textboxUser" runat="server"></asp:TextBox><br />
            <span>fødselsdag</span><br />
            Year: <asp:DropDownList CssClass="dropdown" ID="ddlYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList> 
           
            Month: <asp:DropDownList CssClass="dropdown" ID="ddlMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="ddlMonth_SelectedIndexChanged">
            </asp:DropDownList> 
       
            Day: <asp:DropDownList CssClass="dropdown" ID="ddlDay" runat="server">
            </asp:DropDownList> <br />
            <span>Password</span><br />
            <asp:TextBox ID="password" TextMode="Password" CssClass="textboxPass" runat="server"></asp:TextBox><br />
            <span>Password bekræft</span><br />
            <asp:TextBox ID="passwordconfirm" TextMode="Password" CssClass="textboxPass" runat="server"></asp:TextBox><br />
            <asp:CheckBox ID="isadmin" runat="server" />
            <span>Admin?</span> <br />
            <asp:Button ID="editbtn" CssClass="btn" Text="Edit" runat="server" OnClick="editbtn_Click" /><br />
            <asp:Label ID="errorlabel" runat="server"></asp:Label>
        </div>


</asp:Content>
