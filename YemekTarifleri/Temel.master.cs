using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Temel : System.Web.UI.MasterPage
{
    public LinkButton LabelUsername
    {
        get
        {
            return this.LinkButton_username;
        }
        
    }



    protected void Page_Load(object sender, EventArgs e)
    {

        LinkButton_logout.Visible = false;
        LinkButton_username.Visible = false;

        //Session.Clear();
        //Session.RemoveAll();

        if (Session["Username"] != null)
        {
            //LinkButton btn = (LinkButton)Master.FindControl("LinkButton_kayit");
            //btn.Visible = false;

            LinkButton_signup.Visible = false;

            //LinkButton btn2 = (LinkButton)Master.FindControl("LinkButton_giris");
            //btn2.Visible = false;

            LinkButton_signin.Visible = false;

            //LinkButton btn3 = (LinkButton)Master.FindControl("LinkButton_logout");
            //btn3.Visible = true;

            LinkButton_logout.Visible = true;

            //LinkButton btn4 = (LinkButton)Master.FindControl("LinkButton_user");
            //btn4.Visible = true;



            //Label lbl = (Label)Master.FindControl("Label2");
            LinkButton_username.Visible = true;
            LinkButton_username.Text = Session["Username"].ToString();
        }




    }







    protected void LinkButton_signup_Click(object sender, EventArgs e)
    {
        Response.Redirect("KayitOl.aspx");
    }

    protected void LinkButton_signin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Giris.aspx");
    }

   
    protected void LinkButton_logout_Click1(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("Giris.aspx");
    }
}
