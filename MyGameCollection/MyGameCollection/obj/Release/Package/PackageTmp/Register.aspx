<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyGameCollection.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="Ange Användarnamn"></asp:Label>
    <br />
    <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="UserNameTextBox" ID="RequiredFieldValidator1" runat="server" ValidationGroup="UserCreation" ErrorMessage="Ange ett användarnamn" Display="Dynamic"></asp:RequiredFieldValidator>
    
    <br />
    <asp:Label ID="Label2" runat="server" Text="Ange Lösenord"></asp:Label>
    <br />
    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ControlToValidate="PasswordTextBox" ID="RequiredFieldValidator2" ValidationGroup="UserCreation" runat="server" ErrorMessage="Ange ett lösenord" Display="Dynamic"></asp:RequiredFieldValidator>
    
    <br />
    <asp:Button ID="OkButton" runat="server" Text="Registrera" ValidationGroup="UserCreation" OnClick="OkButton_Click" />
</asp:Content>
