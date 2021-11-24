<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Master-Pages/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="OWASP.WebGoat.NET.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HelpContentPlaceholder" runat="server">
    Like many web applications that allow users to recover their forgotten passwords that are used to authenticate the user,
    this website also tries to implement the functionality. However, it does it in an insecure way. It implements a two step
    process for recovering the password. Check out the requests generated in Burp Suite (under Target tab) when you enter an 
    incorrect response and look at the code to decipher the answer. You do not need to access the database for answers to the 
    security question for this exercise.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContentPlaceholder" runat="server">


    <h1 class="title-regular-4 clearfix">Forgot Password</h1>
    
    <asp:Panel ID="PanelForgotPasswordStep1" runat="server">

        
        <div class="notice">
            <asp:Literal runat="server" EnableViewState="False" ID="labelMessage">Forgot your password huh?  No problem, we've got you covered.  Enter your email address to get started</asp:Literal>
        </div>

        <p></p>                                                                                                                                                                                                                                                                                                                                                 
        
        <p class="inline">
            <label for="name">Email Address: </label>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" class="text"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonCheckEmail" SkinID="Button" runat="server" Text="Proceed to Next Step" OnClick="ButtonCheckEmail_Click" />
        </p>

    </asp:Panel>

    <asp:Panel ID="PanelForgotPasswordStep2" runat="server">

        <div class="error">
            <asp:Literal runat="server" EnableViewState="False" ID="labelQuestion"></asp:Literal>
        </div>
        <p></p>                                                                                                                                                                                                                                                                                                                                                 
        
        <p>
            <label for="name">Answer: </label>
            <br />
            <asp:TextBox ID="txtAnswer" runat="server" class="text"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonCheckAnswer" SkinID="Button" runat="server" Text="Recover Password!" OnClick="ButtonRecoverPassword_Click" />
        </p>
      
    </asp:Panel>

    <asp:Panel ID="PanelForgotPasswordStep3" runat="server">
        <p />
        <div class="success">
            <asp:Literal runat="server" EnableViewState="False" ID="labelPassword"></asp:Literal>
        </div>
    </asp:Panel>




</asp:Content>
