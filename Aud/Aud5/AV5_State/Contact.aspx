<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AV5_State.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <asp:Label ID="Label1" runat="server" Text="Shopping cart contents:"></asp:Label>
       <br />

       <asp:ListBox ID="lbItemsToPay" runat="server"></asp:ListBox>
       <br />

       <asp:Label ID="labelTotalPrice" runat="server" Text="Total: 0 denari."></asp:Label>
   </div>


</asp:Content>
