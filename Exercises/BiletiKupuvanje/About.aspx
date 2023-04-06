<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BiletiKupuvanje.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div>
            <asp:ListBox ID="lbGenres" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbGenres_SelectedIndexChanged">
                <asp:ListItem>Drama</asp:ListItem>
                <asp:ListItem>Comedy</asp:ListItem>
                <asp:ListItem>Action</asp:ListItem>
            </asp:ListBox>

            <asp:Image ID="Image1" runat="server" ImageUrl="~/moviesIcon.png" />
        </div>

        <div class="row">
            <div class="col-3">
                <asp:CheckBoxList ID="cblMovies" runat="server"></asp:CheckBoxList>
            </div>
            <div class="col-2">

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            </div>
        </div>
        <asp:Button ID="btnBuy" runat="server" Text="Buy tickets" OnClick="btnBuy_Click" />
        <asp:Label ID="labelPrice" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
