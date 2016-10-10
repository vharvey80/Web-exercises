using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.config

public partial class Horaire : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
            Connection = new MySqlConnection(ConnectionString.ConnectionString);
            ddl_choix_horraire.Items.Add(new ListItem(" "));
            FillDropDownListChoix();
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
                ddl_choix_horraire.Items.Add(new ListItem(ActivityName));
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

    void ShowSchedule()
    {
        lit_horraire.Text = " ";
        lbl_activite.Text = " ";
        string Activtity =  ddl_choix_horraire.SelectedValue;
        string no_act = " ";
        string jour = " ";
        string date = " ";
        string heure = " ";
        string precision = " ";
        MySqlCommand ScheduleCommand;
        MySqlDataReader ScheduleReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            ScheduleCommand = Connection.CreateCommand();
            ScheduleCommand.CommandText = "Select NumeroActivite from activites where TitreActivite ='" + Activtity + "'";
            ScheduleReader = ScheduleCommand.ExecuteReader();
            if (ScheduleReader.Read())
            {
                no_act = (ScheduleReader["NumeroActivite"]).ToString();
                lbl_activite.Text = Activtity;
            }
            ScheduleReader.Close();
            ScheduleCommand = Connection.CreateCommand();
            ScheduleCommand.CommandText = "Select Jour, Date, Heure, Precisions from horaires where NumeroActivite ='" + no_act + "'";
            ScheduleReader = ScheduleCommand.ExecuteReader();
            while (ScheduleReader.Read())
            {
                jour = ScheduleReader["Jour"].ToString();
                date = ScheduleReader["Date"].ToString();
                heure = ScheduleReader["Heure"].ToString();
                precision = ScheduleReader["Precisions"].ToString();
                lit_horraire.Text = lit_horraire.Text + "<p>" + "Jour(s) : " + jour + " / " + "Date(s) : " + date + " / " + "Heure(s) : " + heure + " / " + "Précision(s) :" + precision + "</p>";
            }
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
    }
    protected void ddl_choix_horraire_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowSchedule();
    }
}