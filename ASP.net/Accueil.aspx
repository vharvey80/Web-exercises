<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Accueil.aspx.cs" Inherits="Accueil" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="Script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <h3>La ville Bouc Étourdi est fier de vous présenter ses activités ! </h3>
    <p>
        <asp:Label ID="lbl_admin" runat="server"></asp:Label>
    </p> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <p>
        <asp:Image ID="Image1" runat="server" Height="250px" Width="848px" ImageUrl="~/App_Themes/Apparence/up.png" />
</p>
    <p>
        Message à tous : Bienvenue sur le site de la ville de Bouc Étourdi. Ce site est présenté et approuvé par le maire. &quot; Je crois parler aux nom des citoyens en vous disant que vous êtes tous le bienvenue pour faire les activités dont vous avez envie. &quot;</p>
    <p>
        &nbsp;Maire de la ville.<br />
</p>
<p>
    <asp:Image ID="Image2" runat="server" Height="175px" ImageUrl="~/App_Themes/Apparence/Basket.jpg" Width="200px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="Image3" runat="server" Height="175px" ImageUrl="~/App_Themes/Apparence/catSoccer.jpg" Width="200px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="Image4" runat="server" Height="175px" ImageUrl="~/App_Themes/Apparence/randonne.png" Width="200px" />
</p>
    <p>
        <asp:Button ID="btn_accueil" runat="server" PostBackUrl="~/Activités.aspx" Text="Entrez " Width="150px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_deco" runat="server" Enabled="False" OnClick="btn_deco_Click" Text="Déconnexion" Width="150px" />
</p>
</asp:Content>

