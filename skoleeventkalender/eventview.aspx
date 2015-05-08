<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="eventview.aspx.cs" Inherits="skoleeventkalender.eventView" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/generalStyle.css" rel="stylesheet" />
    <asp:SqlDataSource runat="server" ID="MySQLData"
    ConnectionString="server=178.62.234.169;database=eventkalender;uid=myproviewereventkalender;password=YxcCpSyUxt3e33D5"
    ProviderName="MySql.Data.MySqlClient"/>

    <DayPilot:DayPilotCalendar ID="eventCalender" runat="server" OnEventClick="eventCalender_EventClick" EventClickJavaScript="alert('');" EventClickHandling="PostBack" TimeRangeSelectedHandling="PostBack" OnTimeRangeSelected="eventCalender_TimeRangeSelected" />
    <asp:Button CssClass="btn" ID="forrigeUgeBtn" runat="server" Text="Forrige uge" float="left" OnClick="forrigeUgeBtn_Click"/>
    <asp:Button CssClass="btn" ID="denneUgeBtn" runat="server" Text="Denne uge"  float="center" OnClick="denneUgeBtn_Click"/>
    <div style=" float:right"><asp:Button CssClass="btn" ID="naesteUgeBtn" runat="server" Text="Næste uge" OnClick="naesteUgeBtn_Click" /></div>
    <br />
    <asp:Button CssClass="btn" ID="CreateEventBtn" runat="server" Text="Create Event" OnClick="CreateEventBtn_Click" />
</asp:Content>
