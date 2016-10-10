<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterActivite.aspx.cs" Inherits="AjouterActivite" Theme="Apparence" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="Script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTete" Runat="Server">
    <h3>Vous pouvez maintenant, à partir d'ici, ajouter des activités !</h3>
    &nbsp;
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderContenu" Runat="Server">
    <p>
        <asp:Label ID="lbl_titre" runat="server" Text="Titre de l'activité : " Width="125px"></asp:Label>
        <asp:TextBox ID="txt_titre" runat="server" BorderStyle="Double" Width="146px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_titre" runat="server" ControlToValidate="txt_titre" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_no_act" runat="server" Text="Numéro d'activité : " Width="125px"></asp:Label>
        <asp:TextBox ID="txt_no_act" runat="server" BorderStyle="Double" Width="146px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_no" runat="server" ControlToValidate="txt_no_act" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lbl_lieu" runat="server" Text="Lieu : " Width="125px"></asp:Label>
        <asp:TextBox ID="txt_lieu" runat="server" BorderStyle="Double" Width="146px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_lieu" runat="server" ControlToValidate="txt_lieu" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_prix" runat="server" Text="Prix : " Width="125px"></asp:Label>
        <asp:TextBox ID="txt_prix" runat="server" BorderStyle="Double" Width="146px" style="margin-left: 0px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_prix" runat="server" ControlToValidate="txt_prix" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lbl_description" runat="server" Text="Description : " Width="125px"></asp:Label>
        <asp:TextBox ID="txt_description" runat="server" BorderStyle="Double" style="margin-top: 0px" Width="470px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="required_description" runat="server" ControlToValidate="txt_description" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
        </p>
<p>
<asp:Label ID="lbl_image" runat="server" Text="Nom de l'image : " Width="125px" style="margin-left: 0px"></asp:Label>
    <asp:FileUpload ID="fileUpload_image" runat="server" Width="183px" />
    <asp:RequiredFieldValidator ID="required_image" runat="server" ControlToValidate="fileUpload_image" Display="Dynamic" ErrorMessage="***" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </p>
<asp:Label ID="Label1" runat="server" Text="Inscription : " Width="125px"></asp:Label>
    <asp:TextBox ID="txt_obligatoire" runat="server" BorderStyle="Double" ></asp:TextBox>
    <br />
<br />
    <p>
        <asp:Button ID="btn_ajout_activite" runat="server" OnClientClick="if (! confirm(&quot;Voulez-vous continuer?&quot;)) return false;" Text="Confirmer l'ajout" style="margin-left: 0px" OnClick="btn_ajout_activite_Click" />
    </p>
    <asp:RegularExpressionValidator ID="expression_no" runat="server" ControlToValidate="txt_no_act" Display="Dynamic" ErrorMessage="Le format du numéro doit être : Aaa0000" ValidationExpression="[A-Z]{1}[a-z]{2}[0-9]{4}"></asp:RegularExpressionValidator>
    <br />
    <asp:RegularExpressionValidator ID="expression_prix" runat="server" ControlToValidate="txt_prix" Display="Dynamic" ErrorMessage="Vous devez entrez au moins 0 si l'activité ne coute rien" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
      <br />
    <asp:RegularExpressionValidator ID="expression_obligatoire" runat="server" ControlToValidate="txt_obligatoire" Display="Dynamic" ErrorMessage="Vous devez &quot;oui&quot; ou &quot;non&quot; " ValidationExpression="(oui|non)"></asp:RegularExpressionValidator>
      <br />
      <br />
      <p>
        <asp:Label ID="lbl_ajout_act" runat="server" Text="Ajout confirmé" Visible="False"></asp:Label>
        <br />
    </p>
</asp:Content>

