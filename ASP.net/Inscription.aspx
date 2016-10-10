<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inscription.aspx.cs" Inherits="Inscription" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="Script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <h3>Il est maintenant temps de vous inscrire à une activité !</h3>
    &nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <p>
        <asp:Label ID="lbl_etape1" runat="server" Text="1- Choisir une activité."></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            style="margin-left: 13px">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lbl_etape2" runat="server" Text="2- Entrez vos renseignements personnels"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lbl_nom" runat="server" Text="Nom : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_nom" runat="server" Enabled="False" 
            style="margin-left: 0px; margin-top: 4px; margin-bottom: 0px;" Width="146px" BorderStyle="Double"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_nom" runat="server" ControlToValidate="txt_nom" ErrorMessage="***"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_prenom" runat="server" Text="Prénom : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_prenom" runat="server" Enabled="False" 
            style="margin-left: 4px; margin-top: 4px" Width="146px" BorderStyle="Double"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_prenom" runat="server" ControlToValidate="txt_prenom" ErrorMessage="***"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lbl_adresse" runat="server" Text="Adresse : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_adresse" runat="server" Enabled="False" 
            style="margin-left: 0px; margin-top: 4px" Width="146px" BorderStyle="Double"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_add" runat="server" ControlToValidate="txt_adresse" ErrorMessage="***"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_ville" runat="server" Text="Ville : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_ville" runat="server" Enabled="False" 
            style="margin-left: 4px; margin-top: 4px" Width="146px" BorderStyle="Double"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_ville" runat="server" ControlToValidate="txt_ville" ErrorMessage="***"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lbl_tel" runat="server" Text="Téléphone : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_tel" runat="server" Enabled="False" 
            style="margin-top: 4px; margin-left: 0px;" Width="146px" BorderStyle="Double"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="required_tel" runat="server" ControlToValidate="txt_tel" ErrorMessage="***"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_courriel" runat="server" Text="Courriel : " Width="75px"></asp:Label>
        <asp:TextBox ID="txt_courriel" runat="server" Enabled="False" 
            style="margin-left: 0px" Width="146px" BorderStyle="Double"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_courriel" runat="server" ControlToValidate="txt_courriel" ErrorMessage="***"></asp:RequiredFieldValidator>
</p>
    <p>
&nbsp;</p>
<p>
        <asp:Button ID="btn_valider" runat="server" OnClick="Button1_Click" OnClientClick="if (! confirm(&quot;Voulez-vous continuer?&quot;)) return false;" Text="Valider " Width="150px" />
    </p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_tel" Display="Dynamic" ErrorMessage="Entrez le format valdie d'un numéro de téléphone" SetFocusOnError="True" ValidationExpression="[0-9]{3} [0-9]{3}-[0-9]{4}"></asp:RegularExpressionValidator>
<br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_courriel" Display="Dynamic" ErrorMessage="Entrez le format valide d'un couriel " SetFocusOnError="True" ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
<p>
        <asp:Label ID="lbl_confirm" runat="server" Text="Inscription confirmé" Visible="False"></asp:Label>
        <br />
    </p>
</asp:Content>

