﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="skoleeventkalender.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login_page">
    <h1>Login</h1>
    <span>Username</span> <br />
    <asp:TextBox CssClass="textboxUser" ID="username" runat="server"></asp:TextBox> <br />  
    <span>Password</span> <br />
    <asp:TextBox CssClass="textboxPass" ID="password" runat="server" TextMode="Password"></asp:TextBox> <br />
    <asp:Label ID="errorlabel" runat="server"></asp:Label> <br />
    <asp:Button CssClass="btn" ID="login" Text="Login" runat="server" OnClick="login_Click" /><br /> <br />
    <asp:Button CssClass="btn" ID="makeuser" Text="Opret Bruger" runat="server" OnClick="makeuser_Click" /> <br />
    
    </div>
</asp:Content>
