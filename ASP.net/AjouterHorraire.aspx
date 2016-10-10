<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterHorraire.aspx.cs" Inherits="AjouterHorraire" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="Script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <h3>Il faut donc ajouter une date à cette activité ! </h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <p>
    <asp:Label ID="lbl_choisi" runat="server" Text="1) Selectionnez une activité : "></asp:Label>
</p>
<p>
    <asp:DropDownList ID="ddl_ajout_date" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ajout_date_SelectedIndexChanged" Width="146px">
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="lbl_info" runat="server" Text="2) Ajouter les informations suivantes "></asp:Label>
</p>
<p>
    <asp:Label ID="lbl_date_debut" runat="server" Text="Date de commencement :" Width="240px"></asp:Label>
    <asp:TextBox ID="txt_date" runat="server" Enabled="False" TextMode="Date" Width="146px" BorderStyle="Double"></asp:TextBox>
    <asp:RequiredFieldValidator ID="Required_date" runat="server" ControlToValidate="txt_date" Display="Dynamic" ErrorMessage="***"></asp:RequiredFieldValidator>
</p>
    <asp:Label ID="lbl_jour" runat="server" Text="Journée d'activité (Jours de semaine) : " Width="240px"></asp:Label>
    <asp:TextBox ID="txt_jour1" runat="server" Enabled="False" Width="146px" BorderStyle="Double"></asp:TextBox>
    <asp:RequiredFieldValidator ID="required_jour" runat="server" ControlToValidate="txt_jour1" Display="Dynamic" ErrorMessage="***"></asp:RequiredFieldValidator>
&nbsp;
        <br />
<br />
        <asp:Label ID="lbl_precision" runat="server" Text="Précision(s) : " Width="240px"></asp:Label>
        <asp:TextBox ID="txt_precisions" runat="server" BorderStyle="Double" Width="146px" style="margin-top: 0px" Enabled="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_prec" runat="server" ControlToValidate="txt_precisions" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
<p>
    <asp:Label ID="lbl_heure" runat="server" Text="Heures : "></asp:Label>
    de
    <asp:TextBox ID="txt_heure_debut" runat="server" Enabled="False" Width="150px" BorderStyle="Double"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="required_heure1" runat="server" ControlToValidate="txt_heure_debut" Display="Dynamic" ErrorMessage="***"></asp:RequiredFieldValidator>
</p>
<p>
    <asp:Button ID="btn_confirmer_date" runat="server" Enabled="False" OnClick="btn_confirmer_date_Click" OnClientClick="if(!valider_activite()) return false;" Text="Confirmer la date " Width="150px" />
</p>


    <br />


<p>
    <asp:Label ID="lbl_date_confirm" runat="server" Text="Date confirmée " Visible="False"></asp:Label>
</p>
</asp:Content>

