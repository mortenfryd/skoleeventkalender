<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="opretBruger.aspx.cs" Inherits="skoleeventkalender.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Login.CSS" rel="stylesheet" />
    <div class="login_page">
    <h1>Opret bruger</h1>
    <span>Fornavn</span> <br />
    <asp:TextBox CssClass="textboxUser" ID="firstname" runat="server"></asp:TextBox> <br />
    <span>Efternavn</span> <br />
    <asp:TextBox CssClass="textboxUser" ID="lastname" runat="server"> </asp:TextBox> <br />
    <span>Email</span> <br />
    <asp:TextBox CssClass="textboxUser" ID="username" runat="server"></asp:TextBox> <br />
    <span>Fødselsdagsdato yyyy-mm-dd</span> <br />
    <asp:TextBox CssClass="textboxUser" ID="birthday" runat="server"></asp:TextBox> <br />
    <span>Kodeord</span> <br />
    <asp:TextBox CssClass="textboxPass" ID="password" TextMode="Password" runat="server"></asp:TextBox> <br />
    <span>Kodeord bekræft</span> <br />
    <asp:TextBox CssClass="textboxPass" ID="passwordconfirm" TextMode="Password" runat="server"></asp:TextBox> <br /> <br />
    
    <asp:Button CssClass="btn" ID="tilbage" Text="Tilbage" runat="server" OnClick="tilbage_Click" />
    <asp:Button CssClass="btn" ID="confirm" Text="Opret bruger" runat="server" OnClick="confirm_Click" /> <br />
    <asp:Label ID="errorlabel" runat="server"></asp:Label>
    </div>
</asp:Content>
