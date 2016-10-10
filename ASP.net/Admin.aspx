<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <h3>Connexion de l'admin</h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <asp:Label ID="lbl_username" runat="server" Text="Username : " Width="150px"></asp:Label>
    <asp:TextBox ID="txt_user" runat="server" Width="125px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lbl_password" runat="server" Text="Password :" Width="150px"></asp:Label>
    <asp:TextBox ID="txt_password" runat="server" Width="125px" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btn_confirm" runat="server" style="margin-left: 30px" Text="Confirmez" Width="150px" OnClick="btn_confirm_Click" />
    <br />
    <br />
    <asp:Label ID="lbl_bon_mdp" runat="server" Text="Connexion confirmé" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lbl_admin" runat="server" Visible="False"></asp:Label>
    <br />
</asp:Content>

