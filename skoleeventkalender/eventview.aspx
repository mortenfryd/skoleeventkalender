<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="eventview.aspx.cs" Inherits="skoleeventkalender.eventView" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
    <link href="CSS/generalStyle.css" rel="stylesheet" />
=======
    <link href="CSS\Login.css" rel="stylesheet" />
>>>>>>> d9fb59dc0ca0dd6715e60083ac4722f925bda8cc
    <asp:SqlDataSource runat="server" ID="MySQLData"
    ConnectionString="server=178.62.234.169;database=eventkalender;uid=myproviewereventkalender;password=YxcCpSyUxt3e33D5"
    ProviderName="MySql.Data.MySqlClient"/>

    <DayPilot:DayPilotCalendar ID="eventCalender" runat="server" />
    <asp:Button CssClass="btn" ID="forrigeUgeBtn" runat="server" Text="Forrige uge" float="left" OnClick="forrigeUgeBtn_Click"/>
    <asp:Button CssClass="btn" ID="denneUgeBtn" runat="server" Text="Denne uge"  float="center" OnClick="denneUgeBtn_Click"/>
    <div style=" float:right"><asp:Button CssClass="btn" ID="naesteUgeBtn" runat="server" Text="Næste uge" OnClick="naesteUgeBtn_Click" /></div>
</asp:Content>
