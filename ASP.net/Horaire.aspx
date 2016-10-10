<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Horaire.aspx.cs" Inherits="Horaire" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Choisissez l'activité dont vous voulez voir l'horraire :"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddl_choix_horraire" runat="server" OnIndexChanged="ddl_choix_horraire_SelectedIndexChanged" AutoPostBack="True" OnSelectedIndexChanged="ddl_choix_horraire_SelectedIndexChanged">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="lbl_activite" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Literal ID="lit_horraire" runat="server"></asp:Literal>
</asp:Content>

