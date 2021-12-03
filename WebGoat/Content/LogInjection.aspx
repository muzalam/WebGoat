<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="LogInjection.aspx.cs" Inherits="OWASP.WebGoat.NET.LogInjection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">Customer Support: Submit a ticket...</h1>
    <p><asp:TextBox ID="txtBoxMsg" runat="server" TextMode="MultiLine" Width="400px" Height="100px"/></p>
    
    <p><asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
            Text="Submit Ticket" SkinID="Button"/></p>
    <p>Result: 
        <asp:Label ID="lblResultMessage" runat="server" /></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    You can first login as jerry@goatgoldstore.net and then try entering something malicious here like:
    User jerry@goatgoldstore.net logged out!
</asp:Content>