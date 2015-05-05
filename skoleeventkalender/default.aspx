<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="skoleeventkalender.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' />
    <link href="CSS/Main.css" rel="stylesheet" />
    
    <div class="login_page">
    <p>Username</p>
    <asp:TextBox CssClass="textbox" ID="username" runat="server"></asp:TextBox>    
    <p>Password</p> 
    <asp:TextBox CssClass="textbox" ID="password" runat="server" TextMode="Password"></asp:TextBox> <br /> <br />
    <asp:Button CssClass="btn" ID="login" Text="Login" runat="server" OnClick="login_Click" /> <br /> <br />
    <asp:Label ID="errorlabel" runat="server"></asp:Label> <br /> <br />
    <a href="eventview.aspx">eventview.aspx</a> 
    </div>
</asp:Content>
