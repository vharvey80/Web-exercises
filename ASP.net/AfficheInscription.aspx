<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AfficheInscription.aspx.cs" Inherits="AfficheInscription" Theme="Apparence" %>

<script runat="server">


</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <asp:DropDownList ID="ddl_choix_insciption" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_choix_insciption_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lbl_inscription" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Literal ID="lit_activite_showed" runat="server"></asp:Literal>
</asp:Content>

