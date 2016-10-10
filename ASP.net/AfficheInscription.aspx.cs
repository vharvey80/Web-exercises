using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.conf

public partial class AfficheInscription : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Accueil.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
                Connection = new MySqlConnection(ConnectionString.ConnectionString);
                ddl_choix_insciption.Items.Add(new ListItem(" "));
                FillDropDownListChoix();
            }
        }

    }

    void FillDropDownListChoix()
    {
        string ActivityName = " ";
        MySqlCommand ActiviteCommand;
        MySqlDataReader ActiviteReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            ActiviteCommand = Connection.CreateCommand();
            ActiviteCommand.CommandText = "Select TitreActivite from activites";
            ActiviteReader = ActiviteCommand.ExecuteReader();
            while (ActiviteReader.Read())
            {
                ActivityName = ActiviteReader["TitreActivite"].ToString();
                ddl_choix_insciption.Items.Add(new ListItem(ActivityName));
                //ddl_ajout_date.Items.Add(ActivityName);
            }
            ActiviteReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("Accueil.aspx");
        }
    }

    void ShowInscription()
    {
        lit_activite_showed.Text = " ";
        lbl_inscription.Text = " ";
        string no_activite = "";
        string Activtity = ddl_choix_insciption.SelectedValue;
        string no_ins = " ";
        string nom = " ";
        string prenom = " ";
        string adresse = " ";
        string ville = " ";
        string telephone = " ";
        string courriel = " ";
        MySqlCommand InscriptionCommand;
        MySqlDataReader InscriptionReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            InscriptionCommand = Connection.CreateCommand();
            InscriptionCommand.CommandText = "Select NumeroActivite from activites where TitreActivite ='" + Activtity + "'";
            InscriptionReader = InscriptionCommand.ExecuteReader();
            if (InscriptionReader.Read())
            {
                no_activite = (InscriptionReader["NumeroActivite"]).ToString();
                lbl_inscription.Text = no_activite;
            }
            InscriptionReader.Close();
            InscriptionCommand = Connection.CreateCommand();
            InscriptionCommand.CommandText = "Select NumeroInscription, Nom, Prenom, Adresse, Ville, Telephone, Courriel from inscriptions where NumeroActivite ='" + no_activite + "'";
            InscriptionReader = InscriptionCommand.ExecuteReader();
            while (InscriptionReader.Read())
            {
                no_ins = InscriptionReader["NumeroInscription"].ToString();
                nom = InscriptionReader["Nom"].ToString();
                prenom = InscriptionReader["Prenom"].ToString();
                adresse = InscriptionReader["Adresse"].ToString();
                ville = InscriptionReader["Ville"].ToString();
                telephone = InscriptionReader["Telephone"].ToString();
                courriel = InscriptionReader["Courriel"].ToString();
                lit_activite_showed.Text = lit_activite_showed.Text + "<p>" + "No : " + no_ins + " / " + "Nom : " + nom + " / " + "Prénom : " + prenom + " / " + "Adresse :" + adresse + " / " + "Ville :" + ville + " / " + "Téléphone :" + telephone + " / " + "Courriel :" + courriel + "</p>";
            }
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
    }
    protected void btn_go_Click(object sender, EventArgs e)
    {
        ShowInscription();
    }
    protected void ddl_choix_insciption_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowInscription();
    }
}