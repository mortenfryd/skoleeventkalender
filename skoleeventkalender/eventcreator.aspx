﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="eventcreator.aspx.cs" Inherits="skoleeventkalender.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CSS/Login.CSS" rel="stylesheet" />
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
        </asp:DropDownList> 
    Hour: <asp:DropDownList ID="ecStartHour" runat="server" AutoPostBack="True"></asp:DropDownList>

        Minute: <asp:DropDownList ID="ecStartMinute" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br /><br />
        End date<br />
    Year: <asp:DropDownList ID="ecEndYear" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecEndYear_SelectedIndexChanged" ></asp:DropDownList> 
           
    Month: <asp:DropDownList ID="ecEndMonth" runat="server" AutoPostBack="True"
            onselectedindexchanged="ecEndMonth_SelectedIndexChanged">
        </asp:DropDownList> 
       
    Day: <asp:DropDownList ID="ecEndDay" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ecEndDay_SelectedIndexChanged">
        </asp:DropDownList> 
        Hour: <asp:DropDownList ID="ecEndHour" runat="server" AutoPostBack="True"></asp:DropDownList>

        Minute: <asp:DropDownList ID="ecEndMinute" runat="server" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <br />
        Event type:
        <asp:DropDownList ID="eventTypeDropD" runat="server"></asp:DropDownList>
        <br />
        <br />
        <br /> 
        Event description <br /> 
     <asp:TextBox ID="eventDescription" runat="server" Height="191px" Width="342px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <asp:Button CssClass="btn" ID="eventCreateBtn" runat="server" Text="Create" OnClick="eventCreateBtn_Click" /> 
        <asp:Button CssClass="btn" ID="eventCancelBtn" runat="server" Text="Cancel" OnClick="eventCancelBtn_Click" />
    </div>


</asp:Content>