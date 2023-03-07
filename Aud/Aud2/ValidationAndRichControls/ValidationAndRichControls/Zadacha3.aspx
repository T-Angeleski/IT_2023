<%@ Page Title="Exam Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zadacha3.aspx.cs" Inherits="ValidationAndRichControls.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin: auto;">
        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbName" runat="server" Text="Exam name"></asp:Label>
            </div>

            <div class="col-4">
                <asp:TextBox ID="tbExamName" runat="server"></asp:TextBox>
            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator 
                    ID="reqValName" 
                    class="text-danger"
                    runat="server" 
                    ErrorMessage="Must enter name" ControlToValidate="tbExamName"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbGrade" runat="server" Text="Grade"></asp:Label>
            </div>

            <div class="col-4">
                <asp:TextBox ID="tbGrade" runat="server"></asp:TextBox>
            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator 
                    class="text-danger"
                    ID="reqValGrade" 
                    runat="server" 
                    ErrorMessage="Enter grade" ControlToValidate="tbGrade"></asp:RequiredFieldValidator>
                <asp:RangeValidator 
                    class="text-danger"
                    ID="RangeValidator1" 
                    runat="server" 
                    ErrorMessage="Grade must be between 5 and 10" ControlToValidate="tbGrade" 
                    MinimumValue="5" MaximumValue="10" Type="Integer"></asp:RangeValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-4">
                <asp:Label ID="lbDate" runat="server" Text="Exam Date"></asp:Label>

            </div>

            <div class="col-4">
                <asp:TextBox ID="tbExamDate" runat="server"></asp:TextBox>

            </div>

            <div class="col-4">
                <asp:RequiredFieldValidator 
                    class="text-danger"
                    ID="RequiredFieldValidator3" 
                    runat="server" 
                    ErrorMessage="Enter date" ControlToValidate="tbExamDate"></asp:RequiredFieldValidator>
                <asp:CompareValidator 
                    ID="CompareValidator1" 
                    runat="server" 
                    ErrorMessage="Invalid Date" 
                    ControlToValidate="tbExamDate" 
                    ValueToCompare="17-03-2023" 
                    Operator="LessThanEqual" Type="Date"></asp:CompareValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-6" style="text-align: center;">
                <asp:Button ID="btExam" runat="server" Text="Validate" OnClick="btExam_Click" />
            </div>
        </div>
        <br />
        <asp:Label ID="lbSuccess" CssClass="text-success" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
