<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="MyGameCollection.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Information">
    <asp:FormView ID="FormView1" runat="server"
        ItemType="MyGameCollection.Model.Game"
        SelectMethod="FormView1_GetItem"
        RenderOuterTable="false"
        DataKeyNames="GameID">
        <ItemTemplate>
            
                <h2>
                    <%#: Item.GameName %>
                </h2>
                <p>
                    <%#: Item.GameText %>
                </p>
            

        </ItemTemplate>


    </asp:FormView>
     </div>
    <div id="Cover">
        <asp:Image ID="CoverImage" runat="server" />
    </div>
    <div id="PictureDiv">
            <asp:Image ID="ShowImage" runat="server" />
    </div>
    <div id="Pics">

        <asp:Repeater ID="GalleryRepeater" runat="server" ItemType="MyGameCollection.Model.FileData" SelectMethod="GalleryRepeater_GetData">
            <ItemTemplate>
               <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "spel/" + Convert.ToInt32(Page.RouteData.Values["id"]) + "?img=" + Item.Name %>'> <asp:Image ImageUrl="<%#Item.Name%>" Width="120px" ID="pic" runat="server" /></asp:HyperLink>
            </ItemTemplate>

        </asp:Repeater>
            <div id="addimage">
        <asp:Label ID="IdTestLabel" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Lägg till en bild" Visible="false"></asp:Label>
        <asp:FileUpload ID="ImageFileUpload" runat="server" Visible="false" />
        <asp:RequiredFieldValidator ValidationGroup="AddImageGroup" ControlToValidate="ImageFileUpload" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange en bild" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ValidationGroup="AddImageGroup" ControlToValidate="ImageFileUpload" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Måste Vara JPG, GIF eller PNG" ValidationExpression="(.*?)\.(jpg|png|gif)" Display="Dynamic"></asp:RegularExpressionValidator>

        <asp:Button ID="UpploadImageButton" runat="server" Text="Lägg till" Visible="false" OnClick="UpploadImageButton_Click" ValidationGroup="AddImageGroup" />
    </div>
    </div>
    <asp:Label ID="TextLabel" runat="server" Text="Skriv en kommentar"></asp:Label>
        <div id="MakeCommentDiv">
        <asp:TextBox ID="TextBox1" CssClass="writebox" runat="server" TextMode="MultiLine" MaxLength="150" Visible="false"></asp:TextBox>
        <asp:RequiredFieldValidator ControlToValidate="TextBox1" ValidationGroup="Comment" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Skriv en kommentar"></asp:RequiredFieldValidator>
        <asp:Button ID="Button1" runat="server" Text="Lägg till kommentar" OnClick="Button1_Click" Visible="false" ValidationGroup="Comment" />
    </div>
    <div id="Comments">

        <asp:Repeater ID="Repeater1" runat="server" ItemType="MyGameCollection.Model.Comment" SelectMethod="Repeater1_GetData">
            <ItemTemplate>
                <div class="CommentFrame">
                    <p class="CommentUser"><%#Item.UserName%></p>
                    <p class="CommentTime"><%#Item.DateAndTime%></p>
                    <p class="CommentText"><%#Item.CommentText%></p>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>



    <a href="Details.aspx"></a>

</asp:Content>
