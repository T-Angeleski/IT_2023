<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidationAndRichControls._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin: 20px;">
        <div class="row">
            <div class="col-md-3">
                Username:
                <br />
                <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-9 text-left">
                <asp:RequiredFieldValidator
                    class="text-danger"
                    ID="rqvalidatorUsername"
                    runat="server"
                    ErrorMessage="Please fill out username"
                    ControlToValidate="tbUsername"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                Email:
                <br />
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-9 text-left">
                <asp:RegularExpressionValidator
                    class="text-danger"
                    ID="regexValEmail"
                    runat="server"
                    ValidationExpression="\S+@\S+\.\S+"
                    ErrorMessage="Invalid e-mail format"
                    ControlToValidate="tbEmail"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                Password:
                <br />
                <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-9 text-left">
                <asp:RegularExpressionValidator
                    class="text-danger"
                    ID="regexValPw"
                    runat="server"
                    ErrorMessage="Password must be at least 5 characters long"
                    ControlToValidate="tbPassword"
                    ValidationExpression=".{5,}"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                Confirm password:
                <br />
                <asp:TextBox ID="tbConfirmPassword" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-9 text-left">
                <asp:RequiredFieldValidator
                    class="text-danger"
                    ID="rqvalidatorConfirm"
                    runat="server"
                    ErrorMessage="Confirm password can not be blank"
                    ControlToValidate="tbConfirmPassword"></asp:RequiredFieldValidator>

                <asp:CompareValidator
                    class="text-danger"
                    ID="cmpValPW"
                    runat="server"
                    ErrorMessage="Passwords do not match"
                    ControlToCompare="tbPassword"
                    ControlToValidate="tbConfirmPassword"></asp:CompareValidator>
            </div>
        </div>
        <br />

        
        <asp:Button ID="btRegister" runat="server" Text="Register" OnClick="btRegister_Click" />
        
        <br />
        <div class="row">
            <asp:Label ID="lbSuccess" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>
