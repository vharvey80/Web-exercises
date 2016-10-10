using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.config

public partial class Activités : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;

    protected void Page_Load(object sender, EventArgs e)
    {
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
        Connection = new MySqlConnection(ConnectionString.ConnectionString);
        ShowActivities();
    }

    void ShowActivities()
    {
        string NoActivity = " ";
        string Activity = " ";
        string Description = " ";
        string Lieu = " ";
        int prix = 0;
        string Image = " ";
        string Inscription = " ";
        MySqlCommand ActivityCommand;
        MySqlDataReader ActivityReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            ActivityCommand = Connection.CreateCommand();
            ActivityCommand.CommandText = "Select NumeroActivite, TitreActivite, Description, Lieu, Prix, Image, InscriptionObligatoire from activites";
            ActivityReader = ActivityCommand.ExecuteReader();
            while (ActivityReader.Read())
            {
                NoActivity = ActivityReader["NumeroActivite"].ToString();
                Activity = ActivityReader["TitreActivite"].ToString();
                Description = ActivityReader["Description"].ToString();
                Lieu = ActivityReader["Lieu"].ToString();
                prix = Convert.ToInt32(ActivityReader["Prix"]);
                Image = ActivityReader["Image"].ToString();
                Inscription = ActivityReader["InscriptionObligatoire"].ToString();
                if (Inscription == "oui")
                {
                    lit_activite.Text = lit_activite.Text + "<form>" + "<h3>Activité:" + " " + Activity + " </h3>" + "Description: " + " " + Description + " " + "Où:" + " " + Lieu + " " + "</br>Prix:" + " " + prix + "$" + " " + "Incription obligatoire:" + " " + Inscription
                        + "</br><img Height='100px' src='App_Themes/Apparence/" + Image + "' Width='100px' /></br><a href='Inscription.aspx?no="+NoActivity+"' class='button'> Inscris - toi ! </a></form>";
                    // + "<img Height='100px' src='" + Image + "' Width='100px' /></p>";
                }
                else
                {
                    lit_activite.Text = lit_activite.Text + "<p>" + "<h3>Activité:" + " " + Activity + " </h3>" + "Description: " + " " + Description + " " + "Où:" + " " + Lieu + " " + "</br>Prix:" + " " + prix + "$" + " " + "Incription obligatoire:" + " " + Inscription
                        + "</br><img Height='100px' src='App_Themes/Apparence/" + Image + "' Width='100px' /></p>";
                    // + "<img Height='100px' src='" + Image + "' Width='100px' /></p>";
                }
            }
            ActivityReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("Accueil.aspx");
        }
    }
}