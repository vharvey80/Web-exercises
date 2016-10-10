<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Activités.aspx.cs" Inherits="Activités" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

        <script src="Script.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">



    <p>
        <h3>Exemple d&#39;activités données cette année !!</h3>
        
    </p>



</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">



    <br />


    <asp:Literal ID="lit_activite" runat="server"></asp:Literal>


    <br />
<br />
<br />
    <asp:Button ID="btn_ins" runat="server" PostBackUrl="~/Inscription.aspx" Text="S'inscrire maintenant" Width="200px" />
    &nbsp;



    <asp:Button ID="btn_voir_horraire" runat="server" PostBackUrl="~/Horaire.aspx" Text="Voir les horraires" Width="200px" />



</asp:Content>

