using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.config 

public partial class AjouterHorraire : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;
    string ChosenActivty = " ";

    protected void Page_Load(object sender, EventArgs e)
    {
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
        Connection = new MySqlConnection(ConnectionString.ConnectionString);
        if (Session["user"] == null)
        {
            Response.Redirect("Accueil.aspx");
        }
        else
        {
            ddl_ajout_date.Items.Add(new ListItem(" "));
            if (!Page.IsPostBack)
            {
                FillDropDownList();
            }
        }
        btn_confirmer_date.Enabled = true;      
    }
    protected void btn_confirmer_date_Click(object sender, EventArgs e)
    {
        AddSchedule();
        lbl_date_confirm.Visible = true;
    }
    protected void ddl_ajout_date_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_ajout_date.SelectedIndex != 0)
        {
            txt_date.Enabled = true;
            txt_jour1.Enabled = true;
            txt_heure_debut.Enabled = true;
            txt_precisions.Enabled = true;
            ChosenActivty = ddl_ajout_date.SelectedValue;
        }
        else
        {
            txt_date.Enabled = false;
            txt_jour1.Enabled = false;
            txt_heure_debut.Enabled = false;
            txt_precisions.Enabled = false;


        }

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
            ActiviteCommand.CommandText = "Select TitreActivite from activites";
            ActiviteReader = ActiviteCommand.ExecuteReader();
            while (ActiviteReader.Read())
            {
                ActivityName = ActiviteReader["TitreActivite"].ToString();
                ddl_ajout_date.Items.Add(new ListItem(ActivityName));
                //ddl_ajout_date.Items.Add(ActivityName);
            }
            ActiviteReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
    }

    void AddSchedule()
    {
        
        if (Page.IsValid)
        {
            string Jour = txt_jour1.Text;
            string Date = txt_date.Text;
            string Heure = txt_heure_debut.Text;
            string Precision = txt_precisions.Text;
            string NumeroActiviteAjout = " ";
          

            MySqlCommand ScheduleCommand;
            Connection.Open();

            NumeroActiviteAjout = Schedule();

            lbl_date_confirm.Visible = true;
            ScheduleCommand = Connection.CreateCommand();
            ScheduleCommand.CommandText = "INSERT into horaires  (Jour, Date, Heure, Precisions, NumeroActivite) values('" + Jour + "','" + Date + "','" + Heure + "','" + Precision + "','" + NumeroActiviteAjout + "')";
            ScheduleCommand.ExecuteNonQuery();
            Connection.Close();
        }
    }

    string Schedule()
    {
        string activite = ddl_ajout_date.SelectedValue;
        string Schedule = " ";
        MySqlCommand HorraireCommand;
        MySqlDataReader ScheduleReader;
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            HorraireCommand = Connection.CreateCommand();
            HorraireCommand.CommandText = "Select NumeroActivite from activites where TitreActivite ='" + activite + "'";
            ScheduleReader = HorraireCommand.ExecuteReader();
            if (ScheduleReader.Read())
            {
                Schedule = ScheduleReader["NumeroActivite"].ToString();
            }
            ScheduleReader.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
        return Schedule;
    }
}