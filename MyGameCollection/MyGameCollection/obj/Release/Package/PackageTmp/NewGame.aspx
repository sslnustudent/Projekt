    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="MyGameCollection.NewGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" Text="Ange namnet på spelet"></asp:Label>
        <br />
        <asp:TextBox ID="GameNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ValidationGroup="GameCheck" ControlToValidate="GameNameTextBox" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange namnet på spelet"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Ange beskrivningen av spelet"></asp:Label>
        <br />
        <asp:TextBox CssClass="NewGameTextBox" ID="GameTextBox" runat="server" TextMode="MultiLine" MaxLength="5000">

        </asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="GameTextBox" ValidationGroup="GameCheck" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ange en beskrivning"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Lägg till en bild på framsidan av spelet"></asp:Label>
        <br />
        <asp:FileUpload ID="ImageFileUpload" runat="server" />
        <asp:RequiredFieldValidator ValidationGroup="GameCheck" ControlToValidate="ImageFileUpload" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange en bild" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ValidationGroup="GameCheck" ControlToValidate="ImageFileUpload" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Måste Vara JPG, GIF eller PNG" ValidationExpression="(.*?)\.(jpg|png|gif)" Display="Dynamic"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="OkButton" runat="server" Text="Lägg till spel" ValidationGroup="GameCheck" OnClick="OkButton_Click" />

    </div>

</asp:Content>
