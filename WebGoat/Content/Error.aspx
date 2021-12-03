<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="OWASP.WebGoat.NET.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">A tale of two numbers ...</h1>

Select a text file containing two numbers on separate lines, then click the Calculate button. 
    This page is supposed to calculate the sum of the two numbers.
<p />

    <asp:Label ID="labelUpload" runat="server" Visible="false">
    
    </asp:Label>

<div class="tiny" style="text-align:center">Attach a file (Plain Text only with .txt extension)...
    <hr />
    <asp:FileUpload ID="FileUpload1" runat="server"/>
    <p>&nbsp;</p>
    <asp:Button ID="btnUpload" runat="server" Text="Calculate!" 
            CssClass="button medium blue" onclick="btnUpload_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    This page handles errors and exceptions and even throws an exception if the file is invalid. 
    However, there is a resource leak on this page. Can you find it?
</asp:Content>