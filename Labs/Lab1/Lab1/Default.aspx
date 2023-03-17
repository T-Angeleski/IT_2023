<%@ Page Title="Najava" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-4">
                Name 
            </div>

            <div class="col-4">
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                <br />
            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator 
                    class="text-danger"
                    ID="RequiredFieldValidator1" 
                    runat="server" 
                    ErrorMessage="Enter name" 
                    ControlToValidate="tbName"></asp:RequiredFieldValidator>
            </div>

        </div>

        <div class="row">
            <div class="col-4">
                Password 
            </div>

            <div class="col-4">
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                <br />
            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator
                    class="text-danger"
                    ID="RequiredFieldValidator2" 
                    runat="server" 
                    ErrorMessage="Enter password" 
                    ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
            </div>

        </div>

        <div class="row">
            <div class="col-4">
                Email 
            </div>

            <div class="col-4">
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                <br />
            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator 
                    class="text-danger"
                    ID="RequiredFieldValidator3" 
                    runat="server" 
                    ErrorMessage="Enter email" 
                    ControlToValidate="tbEmail"></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator 
                    class="text-danger"
                    ID="RegularExpressionValidator1" 
                    runat="server" 
                    ErrorMessage="Invalid format" 
                    ControlToValidate="tbEmail" 
                    ValidationExpression="\S+@\S+\.\S+"></asp:RegularExpressionValidator>
            </div>

        </div>

        <asp:Button ID="btConfirm" runat="server" Text="Log In" OnClick="btConfirm_Click" />



    </div>

</asp:Content>
