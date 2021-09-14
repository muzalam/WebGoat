<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="RegexDoS.aspx.cs" Inherits="OWASP.WebGoat.NET.RegexDoS" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceHolder" runat="server">
    This page is the Username checker. It checks whether a username is acceptable based on a very simple criteria.
    It should contain letters followed by numbers. Try to cause the page to timeout.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">Username validator</h1>
Here are files available for download.  Please click on a file and the download should initiate within 10 seconds.<p/>

<asp:Label ID="lblError" runat="server" />
<br />
Username:&nbsp;<asp:TextBox ID="txtUsername" runat="server" />
<br />
<!-- Availability:&nbsp;<asp:TextBox ID="txtAvailable" runat="server" ReadOnly="true"/> -->
<br />
<asp:Button ID="btnCheckUsername" runat="server" Text="Check Username" OnClick="btnCheckUsername_Click" />
</asp:Content>
