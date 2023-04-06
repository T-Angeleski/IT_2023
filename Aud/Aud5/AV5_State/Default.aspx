<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AV5_State._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="text-align: center">
        <h1> Categories </h1>
        <br />
        <div class="col-md-6" style="margin: auto; font-size:20px;">
            <asp:LinkButton ID="lbTechnical" runat="server" OnClick="lbTechnical_Click">Technical literature</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbScience" runat="server" OnClick="lbScience_Click">Science fiction</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lbAutomobiles" runat="server" OnClick="lbAutomobiles_Click">Automobiles</asp:LinkButton>
        </div>
    </div>

</asp:Content>
