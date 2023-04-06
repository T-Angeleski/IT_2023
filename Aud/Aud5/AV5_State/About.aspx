<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="AV5_State.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center" style="font-size: 30px;">
            <asp:Label ID="labelCategory" runat="server" Text="(category)"></asp:Label>
        </div>

        <div class="row">
            <div class="col-md-8 text-center">
                <h4>Books</h4>
            </div>

            <div class="col-md-4">
                <h4>Prices</h4>
            </div>
        </div>

        <div class="row">
            <div class="col-md-8 text-center">
                <asp:ListBox ID="lbBooks" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbBooks_SelectedIndexChanged" Width="800px"></asp:ListBox>
            </div>

            <div class="col-md-4">
                <asp:ListBox ID="lbPrices" runat="server" Width="400px"></asp:ListBox>
            </div>
        </div>

        <div class="row text-end">
            <asp:Label ID="labelTotal" runat="server" Text="Total: 0"></asp:Label>
        </div>

        <div style="margin-left:300px;">
            <asp:Button ID="btnAddCart" runat="server" Text="Add to cart" OnClick="btnAddCart_Click" />
            <br />
        </div>

        <div class="row">
            <div class="col-md-8 text-center">
                <h4>Shopping cart</h4> <br />
                <asp:ListBox ID="lbShoppingCart" runat="server"></asp:ListBox>
            </div>
        </div>

        <div style="margin-left:300px;">
            <asp:Button ID="btnPay" runat="server" Text="Proceed payment" OnClick="btnPay_Click" />
            <br />
        </div>
    </div>
</asp:Content>
