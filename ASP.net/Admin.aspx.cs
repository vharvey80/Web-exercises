using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration; //accéder au web.config 

public partial class Admin : System.Web.UI.Page
{
    static ConnectionStringSettings ConnectionString;
    static MySqlConnection Connection;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    bool FindAdmin(string NameToFind)
    {
        bool UserFind = false;
        MySqlCommand UserCommand;
        MySqlDataReader UserReader;
        Connection.Open();
        if (Connection != null)
        {
            UserCommand = Connection.CreateCommand();
            UserCommand.CommandText = "Select login from admin where login ='" + NameToFind + "'";
            UserReader = UserCommand.ExecuteReader();
            if (UserReader.Read())
            {
                if (UserReader["login"].ToString() == NameToFind)
                {
                    UserFind = true;
                }
            }
            UserReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
        return UserFind;
    }


    bool VerifMDP(string User, string Answer)
    {
        bool find = false;
        MySqlCommand AnswerCommand;
        MySqlDataReader AnswerReader;
        Connection.Open();
        //while (QuestionReader.Read())
        if (Connection != null)
        {
            AnswerCommand = Connection.CreateCommand();
            AnswerCommand.CommandText = "Select password from admin where login ='" + User + "'";
            AnswerReader = AnswerCommand.ExecuteReader();
            if (AnswerReader.Read())
            {
                if (AnswerReader["password"].ToString() == Answer)
                {
                    find = true;
                }
            }
            AnswerReader.Close();
            Connection.Close();
        }
        else
        {
            //connexion non réussie
            Response.Redirect("default.aspx");
        }
        return find;
    }
    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        string nom;
        string rep;
        bool find = false;
        bool mdp = false;
        ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationConnection"];
        Connection = new MySqlConnection(ConnectionString.ConnectionString);
        nom = txt_user.Text;
        rep = txt_password.Text;
        if (nom != null)
        {
            find = FindAdmin(nom);
            if (find == false)
            {
                Response.Redirect("Accueil.aspx");
            }
            else
            {
                Session["user"] = nom;
                mdp = VerifMDP(nom, rep);
                if (mdp == false)
                {
                    Response.Redirect("Accueil.aspx");
                }
                else
                {
                    //lbl_bon_mdp.Visible = true;
                    //lbl_admin.Visible = true;
                    //lbl_admin.Text = Session["user"].ToString();
                    Response.Redirect("Accueil.aspx");
                }
            }
        }
    }
}