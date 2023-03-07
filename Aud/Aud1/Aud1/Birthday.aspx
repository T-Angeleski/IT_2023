<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Birthday.aspx.cs" Inherits="Aud1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-5">
                <div class="m-4">
                    Choose background color:
               <br />
                    <asp:DropDownList ID="BGColor" runat="server"></asp:DropDownList>
                </div>

                <div class="m-4">
                    Choose font:
               <br />
                    <asp:DropDownList ID="Font" runat="server"></asp:DropDownList>
                </div>

                <div class="m-4">
                    Choose text color:
               <br />
                    <asp:DropDownList ID="FontColor" runat="server"></asp:DropDownList>
                </div>

                <div class="m-4">
                    Choose text size:
               <br />
                    <asp:TextBox ID="FontSize" runat="server"></asp:TextBox>
                </div>

                <div class="m-4">
                    Choose border type:
               <br />
                    <asp:RadioButtonList ID="BorderType" runat="server"></asp:RadioButtonList>
                </div>

                <div class="m-4">
                    Show image Y/N:
               <br />
                    <asp:CheckBox ID="ShowImg" runat="server" />
                </div>

                <div class="m-4">
                    <br />
                    <asp:TextBox ID="ShortText" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="m-4">
                    <asp:Button ID="Save" runat="server" Text="Create" OnClick="Save_Click" />
                </div>
            </div>

            <div class="col-5">
                <asp:Panel ID="BirthdayCard" runat="server">
                    <asp:Label ID="TextWish" runat="server" Text="Label"></asp:Label>
                    <asp:Image ID="BirthdayImg" runat="server" ImageUrl="~/Images/ASCII-Happy-Birthday.jpg" Visible="False" />
                </asp:Panel>
            </div>

        </div>
    </div>
</asp:Content>
