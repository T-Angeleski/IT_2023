<%@ Page Title="Cities" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zadacha2.aspx.cs" Inherits="ValidationAndRichControls.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <asp:DropDownList ID="droplCities" runat="server">
                    <asp:ListItem>(choose city)</asp:ListItem>
                    <asp:ListItem>Skopje</asp:ListItem>
                    <asp:ListItem>Veles</asp:ListItem>
                    <asp:ListItem>Prilep</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-md-3">
                <asp:RequiredFieldValidator 
                    class="text-danger"
                    ID="reqValCity" 
                    runat="server" 
                    ErrorMessage="Please choose a city" 
                    ControlToValidate="droplCities" 
                    InitialValue="(choose city)"></asp:RequiredFieldValidator>
            </div>
        </div>

        <br />
        <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
        <br />
        <asp:Label ID="lbSelectedCity" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
