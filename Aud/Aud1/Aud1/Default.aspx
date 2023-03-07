<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aud1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Auditoriska 1</h1>
    </div>

    <div class="row">
        <div class="col-md-4 text-left">
            <div class="m-3">
                Choose city:
                 <br />

                <asp:ListBox ID="CityList" runat="server" SelectionMode="Multiple">
                    <asp:ListItem Value="0">Skopje</asp:ListItem>
                    <asp:ListItem Value="50">Veles</asp:ListItem>
                    <asp:ListItem Value="150">Prilep</asp:ListItem>
                    <asp:ListItem Value="200">Bitola</asp:ListItem>
                </asp:ListBox>
            </div>

            <div class="m-3">
                <asp:Button ID="ShowCity" runat="server" Text="Show selected city" OnClick="ShowCity_Click" />
            </div>

            <div class="m-3">
                The selected city is:
                <asp:Label ID="SelectedCity" runat="server" Text=" "></asp:Label>
            </div>

            <div class="m-3">
                Distance from Skopje is:
                <asp:Label ID="Distance" runat="server" Text=" "></asp:Label>
            </div>

        </div>

        <div class="col-lg-4 text-right">
            <div class="mg-4">
                Insert currency name
                <br />
                <asp:TextBox ID="CurrencyName" runat="server"></asp:TextBox>
            </div>

            <br />

            <div class="mg-4">
                Insert currency value
                <br />
                <asp:TextBox ID="CurrencyValue" runat="server"></asp:TextBox>
            </div>
            <br />

            <div class="mg-4">
                <asp:Button ID="InsertCurrency" runat="server" Text="Insert currency" OnClick="InsertCurrency_Click" />
            </div>
            <br />

            <div class="mg-4">
                <asp:RadioButtonList ID="Currencies" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Currencies_SelectedIndexChanged"></asp:RadioButtonList>

                <asp:Button ID="DeleteSelectedCurrency" runat="server" Text="Delete selected currency" OnClick="DeleteSelectedCurrency_Click" />
            </div>
            <br />

            <div class="mg-4">
                Total amount of currencies:
                <asp:Label ID="totalCurrencies" runat="server" Text="0"></asp:Label>
            </div>

        </div>

        <div class="col-lg-4 text-right">
            <div class="mg-4">
                Enter amount to convert to DEN(MKD)
                <asp:TextBox ID="ToConvert" runat="server"></asp:TextBox>
                <br />

                Converted value:
                <asp:Label ID="Converted" runat="server" Text="0 den"></asp:Label>
            </div>
        </div>

    </div>

</asp:Content>
