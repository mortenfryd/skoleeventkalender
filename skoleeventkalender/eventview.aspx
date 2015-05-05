<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="eventview.aspx.cs" Inherits="skoleeventkalender.eventView" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource runat="server" ID="MySQLData"
    ConnectionString="server=178.62.234.169;database=eventkalender;uid=myproviewereventkalender;password=YxcCpSyUxt3e33D5"
    ProviderName="MySql.Data.MySqlClient"/>

    <DayPilot:DayPilotCalendar ID="eventCalender" runat="server" />
</asp:Content>
