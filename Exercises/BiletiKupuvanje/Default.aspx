<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BiletiKupuvanje._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username cannot be blank"
                    ControlToValidate="tbUsername"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Username must contain ^, ! or -"
                    ControlToValidate="tbUsername" ValidationExpression="\S*[!^-]\S*"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password cannot be blank"
                    ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-4">
                <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            </div>
            <div class="col-4">
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email cannot be blank"
                    ControlToValidate="tbEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid email format"
                    ControlToValidate="tbEmail" ValidationExpression="\S+\@\S+\.\S+"></asp:RegularExpressionValidator>

            </div>
        </div>

        <asp:Button ID="btnSignin" runat="server" Text="Sign in" OnClick="btnSignin_Click" />
    </div>

</asp:Content>
