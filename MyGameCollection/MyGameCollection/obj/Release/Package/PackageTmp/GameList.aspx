<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GameList.aspx.cs" Inherits="MyGameCollection.GameList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:ListView ID="GametListView" runat="server" ItemType="MyGameCollection.Model.Game" SelectMethod="GameListView_GetData">
        <LayoutTemplate>
            <table>
                <tr>
                    <th>Spel
                    </th>
                </tr>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("Details", new { id = Item.GameID})%>' Text='<%# Item.GameName %>' />
                  
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>


</asp:Content>
