using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Accueil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            lbl_admin.Text = "Bonjour " + Session["user"].ToString() + " " + "!";
            btn_deco.Enabled = true;
        }
    }
    protected void btn_deco_Click(object sender, EventArgs e)
    {
        Session.Remove("user");
        Response.Redirect("Accueil.aspx");
    }
}