using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Giris : System.Web.UI.Page
{
    SqlConnection baglanti;
    SqlCommand komut;


    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    protected void Button_gir_Click(object sender, EventArgs e)
    {

        string mail = TextBox_girEmail.Text.ToString();
        string parola = TextBox_girParola.Text.ToString();
        
        if(mail.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Mail adresinizi girin.');</script>");

        }
        else if(parola.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Parolanızı girin.');</script>");

        }
        else if(email_kontrol(mail).Equals(false))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hatalı giriş", "<script>alert('Geçersiz mail adresi girdiniz.');</script>");

        }

        else
        {

            try
            {
                string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
                baglanti = new SqlConnection(bagla);
                baglanti.Open();
                //string sql_komut = "select ad,soyad from KullaniciBilgileri where email='" + mail + "' and parola='" + parola + "'";
                string sql_komut = "select * from KullaniciBilgileri";
                komut = new SqlCommand(sql_komut, baglanti);

                SqlDataAdapter adp = new SqlDataAdapter(komut);


                komut.ExecuteNonQuery();

                DataSet dataset = new DataSet();

                adp.Fill(dataset);

                DataTable dt = dataset.Tables[0].Copy();

                baglanti.Close();


                bool kontrol = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (mail.Equals(dt.Rows[i]["email"]) && parola.Equals(dt.Rows[i]["parola"]))
                    {
                        kontrol = true; break;
                    }

                }


                if (kontrol == true)
                {
                    Session["Username"] = mail;
                    Response.Redirect("WelcomePage.aspx");
                }

                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hatalı giriş yaptınız", "<script>alert('Bilgileriniz bulanamadı.');</script>");

                }


                /*

                bool kontrol = false;

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    if(mail.Equals(dt.Rows[i]["email"]) && parola.Equals(dt.Rows[i]["parola"]))
                    {
                        kontrol = true; break;
                    }

                }
                if(kontrol==true)
                {



                    Label lbluserloggedUserName = (Label)Master.FindControl("Label1");
                    lbluserloggedUserName.Text = "sadfsafwsfsa";

                    Label lb = (Label)Master.FindControl("Label3");
                    lb.Text = "Çıkış Yap";

                    HyperLink link = (HyperLink)Master.FindControl("HyperLink2");
                    link.Enabled = false;






                    // System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("yeni");

                    //hiding the div
                    //currdiv.Style.Add("display", "none");









                }
                else
                {
                    Response.Write("yanlis girildi");
                }*/

            }

            catch (Exception hata)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

            }

        }

      

       

    }

    bool email_kontrol(string email)
    {

        string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
+ @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
+ @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
+ @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
+ @"[a-zA-Z]{2,}))$";
        Regex reStrict = new Regex(patternStrict);
        bool isStrictMatch = reStrict.IsMatch(email);
        return isStrictMatch;

    }
}