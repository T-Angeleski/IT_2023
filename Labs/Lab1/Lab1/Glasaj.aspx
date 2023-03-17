<%@ Page Title="Glasaj" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Image ID="imgFinki" runat="server" 
            ImageUrl="~/Images/logo_finki.png" />
        <br />
        <asp:Label ID="lbProfessor" runat="server" Text=""></asp:Label>

        <div class="row">
            <div class="col-2" style="display: inline;">
                <asp:ListBox ID="lbPredmeti" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbPredmeti_SelectedIndexChanged">
                    <asp:ListItem Value="Prof D-r Goce Armenski">Internet Tehnologii</asp:ListItem>
                    <asp:ListItem Value="Prof D-r Magdalena Kostoska">Internet</asp:ListItem>
                    <asp:ListItem Value="Prof D-r Adam Adamson">Digitalna Elektronika</asp:ListItem>
                </asp:ListBox>
            </div>
            
            <div class="col-2" style="display: inline;">
                <asp:ListBox ID="lbKrediti" runat="server">
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>5.5</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:ListBox>
            </div>
        </div>

        <asp:Button ID="btVote" runat="server" Text="Vote" OnClick="btVote_Click" />
    </div>
</asp:Content>
