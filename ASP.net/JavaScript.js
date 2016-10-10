function valider_activite() {
    var nom = document.getElementById("ContentPlaceHolderContenu_ddl_ajout_date").value;
    return(confirm("Voulez-vous vraiment ajouter cet horraire pour l'activité " + " " + nom + " " + "?"));
};


