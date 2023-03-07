<%@ Page Title="Image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="Aud1.WebForm1" %>
<asp:Content ID="Image" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mg-4">
            <asp:Image ID="chess" runat="server" ImageUrl="~/Images/chess.jpg" />
        </div>

        <div class="row mg-4">
            <asp:ImageButton ID="checkmateButton" runat="server" ImageUrl="~/Images/checkmate.jpg" Height="200" Width="150" OnClick="checkmateButton_Click" />
        </div>

        <div class="row mg-4">
            <asp:Label ID="imageLabel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
