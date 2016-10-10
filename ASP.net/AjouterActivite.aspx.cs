using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.config 

public partial class AjouterActivite : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Accueil.aspx");
        }
    }


    protected void btn_ajout_activite_Click(object sender, EventArgs e)
    {
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
        Connection = new MySqlConnection(ConnectionString.ConnectionString);
        Connection.Open();
        if (Page.IsValid)
        {
            
            string NoActivite = txt_no_act.Text;
            string TitreActivite = txt_titre.Text;
            string Description = txt_description.Text;
            string Lieu = txt_lieu.Text;
            string Prix = txt_prix.Text;
            string ImageActivite = " ";
            string InscriptionObli = txt_obligatoire.Text;
            bool Activite = true;
            string TypeImage = fileUpload_image.PostedFile.ContentType;
            string NomFichier = "";
            string NomUpload = "";
            //vérfie s'il s'agit bien d'un type de fichier contenant une image
            if (TypeImage == "image/jpeg" || TypeImage == "image/gif" || TypeImage == "image/png")
            {
                NomFichier = fileUpload_image.FileName;
                NomUpload = Server.MapPath("~/App_Themes/Apparence/") + NomFichier;
                fileUpload_image.SaveAs(NomUpload);
                ImageActivite = NomFichier;
            }

            MySqlCommand ActiviteCommand;
            Activite = ActiviteValide(TitreActivite);
            if (Activite)
            {
                lbl_ajout_act.Text = "Ajout confirmé";
                lbl_ajout_act.Visible = true;
                ActiviteCommand = Connection.CreateCommand();
                ActiviteCommand.CommandText = "INSERT into activites  (NumeroActivite, TitreActivite, Description, Lieu, Prix, Image, InscriptionObligatoire) values('" + NoActivite + "','" + TitreActivite + "','" + Description + "','" + Lieu + "','" + Prix + "','" + ImageActivite + "' , '" + InscriptionObli + "')";
                ActiviteCommand.ExecuteNonQuery();
                Connection.Close();
            }
            else
            {
                lbl_ajout_act.Text = "Nom d'activité déja existant";
                lbl_ajout_act.Visible = true;
            }
        }
    }

    bool ActiviteValide(string TitreActivite)
    {
        bool Valid = true;
        MySqlCommand ActiviteCommand;
        MySqlDataReader ActiviteReader;
        //while (QuestionReader.Read())
        //Connection.Open();
        if (Connection != null)
        {
            ActiviteCommand = Connection.CreateCommand();
            ActiviteCommand.CommandText = "Select TitreActivite from activites where TitreActivite ='" + TitreActivite + "'";
            ActiviteReader = ActiviteCommand.ExecuteReader();
            if (ActiviteReader.Read())
            {
                Valid = false; 
            }
            ActiviteReader.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
        return Valid;
    }
}