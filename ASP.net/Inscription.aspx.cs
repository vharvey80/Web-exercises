using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.conf

public partial class Inscription : System.Web.UI.Page
{
    string no_act = " ";
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;
    protected void Page_Load(object sender, EventArgs e)
    {
        txt_adresse.Enabled = true;
        txt_courriel.Enabled = true;
        txt_nom.Enabled = true;
        txt_prenom.Enabled = true;
        txt_tel.Enabled = true;
        txt_ville.Enabled = true;
        btn_valider.Enabled = true;
        no_act = Request.QueryString["no"];
        
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
        Connection = new MySqlConnection(ConnectionString.ConnectionString);
        if (!Page.IsPostBack)
        {
            DropDownList1.Items.Add(new ListItem(" "));
            FillDropDownList();
            ShowChosenActivite(no_act);
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        no_act = Request.QueryString["no"];
        lbl_confirm.Visible = true;
        Connection.Open();
        if (Page.IsValid)
        {
            string nom = txt_nom.Text;
            string prenom = txt_prenom.Text;
            string adresse = txt_adresse.Text;
            string ville = txt_ville.Text;
            string telephone = txt_tel.Text;
            string Courriel = txt_courriel.Text;
            string numeroAct = " ";
            string nomAct = DropDownList1.SelectedValue;
            numeroAct = nom_act(nomAct);

            MySqlCommand UserCommand;
            lbl_confirm.Visible = true;
            UserCommand = Connection.CreateCommand();
            UserCommand.CommandText = "INSERT into inscriptions  (Nom, Prenom, Adresse, Ville, Telephone, Courriel, NumeroActivite) values('" + nom + "','" + prenom + "','" + adresse + "','" + ville + "','" + telephone + "','" + Courriel + "','" + numeroAct + "')";
            UserCommand.ExecuteNonQuery();
            Connection.Close();
        }
    }

    string nom_act(string nom)
    {
        string no_act = " ";
        MySqlCommand NoCommand;
        MySqlDataReader NoReader;
        //while (QuestionReader.Read())
        //Connection.Open();
        if (Connection != null)
        {
            NoCommand = Connection.CreateCommand();
            NoCommand.CommandText = "Select NumeroActivite from activites where TitreActivite ='" + nom + "'";
            NoReader = NoCommand.ExecuteReader();
            if (NoReader.Read())
            {
                no_act = NoReader["NumeroActivite"].ToString();
            }
            NoReader.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("Accueil.aspx");
        }
        return no_act;
    }

    void FillDropDownList()
    {
        string ActivityName = " ";
        MySqlCommand ActiviteCommand;
        MySqlDataReader ActiviteReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            ActiviteCommand = Connection.CreateCommand();
            ActiviteCommand.CommandText = "Select TitreActivite from activites where InscriptionObligatoire = 'oui'";
            ActiviteReader = ActiviteCommand.ExecuteReader();
            while (ActiviteReader.Read())
            {
                ActivityName = ActiviteReader["TitreActivite"].ToString();
                DropDownList1.Items.Add(new ListItem(ActivityName));
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

    void ShowChosenActivite(string NumeroActivite)
    {
        string chosenAct = " ";
        MySqlCommand ChosenCommand;
        MySqlDataReader ChosenReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            ChosenCommand = Connection.CreateCommand();
            ChosenCommand.CommandText = "Select TitreActivite from activites where NumeroActivite ='" + NumeroActivite + "'";
            ChosenReader = ChosenCommand.ExecuteReader();
            while (ChosenReader.Read())
            {
                chosenAct = ChosenReader["TitreActivite"].ToString();
                DropDownList1.Text = chosenAct;
                //ddl_ajout_date.Items.Add(ActivityName);
            }
            ChosenReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("Accueil.aspx");
        }
    }

}