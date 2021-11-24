<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="ReadlineDoS.aspx.cs" Inherits="OWASP.WebGoat.NET.ReadlineDoS" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Hello! This webpage uses readline() function to parse input files that are uploaded to perform content validation. A DoS can becaused by uploading a really large file.
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">
    <h1 class="title-regular-4 clearfix">File Upload</h1>
Please upload a file. Warning: The content will be checked to ensure it meets requirements for allowed files only.<p/>

<asp:Label ID="lblFileContent" runat="server" />
<br />
<asp:FileUpload ID="file1" runat="server" />
<br />
<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
</asp:Content>

