<%@ Page Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="VerbTampering.aspx.cs" Inherits="OWASP.WebGoat.NET.VerbTampering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    Try to change the message below to say "Used Verb [HTTP VERB HERE] to tamper this message" ... <br />
<asp:Label ID="lblTampered" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
   Many of the web servers or frameworks allow for authentication and authorization of HTTP verbs like GET, PUT, DELETE etc. for different pages.
    ASP .NET is no exception. For this exercise in the Attack Lab, <b>without logging in as any user</b>:
    <ul>
    <li>Use the BurpSuite Repeater feature to change/tamper the message below.</li>
    <li>Use the Repeater to make a request to VerbTamperingAttack.aspx which takes a query parameter called 'message'.</li>
    <li>You will notice VerbTamperingAttack.aspx page is not in the WebGoat .NET menu and is "hidden". </li>
    <li>The 'message' query parameter then changes what gets displayed in the message below.</li>
    <li>Do not change Web.config file (You will see that certain verbs for non-logged in users are not allowed).</li>
    </ul>
    After using the Repeater, refresh this page to see that message below. Now you can't use certain HTTP verbs in your request to pull this off.
    For the Fix Lab, we will be fixing this issue.
</asp:Content>

