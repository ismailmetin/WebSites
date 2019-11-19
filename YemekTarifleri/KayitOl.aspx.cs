using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KayitOl : System.Web.UI.Page
{
    SqlConnection baglanti;
    SqlCommand komut;


    protected void Page_Load(object sender, EventArgs e)
    {

        

    }

    protected void Button_kayit_Click(object sender, EventArgs e)
    {

        string isim, soyisim, kullaniciadi, parola, email,parolatekrar;

        isim = TextBox_ad.Text.ToString();
        soyisim= TextBox_soyad.Text.ToString();
        kullaniciadi=TextBox_kullaniciad.Text.ToString();
        parola= TextBox_parola.Text.ToString();
        email= TextBox_email.Text.ToString();
        parolatekrar = TextBox_parolaTekrar.Text.ToString();

        if(isim.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Adınızı girin.');</script>");
        }
        else if (soyisim.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Soyadınızı girin.');</script>");

        }
        else if(kullaniciadi.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Kullanıcı adınızı girin.');</script>");


        }
        else if(parola.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Parolanızı tekrar girin.');</script>");

        }
        else if(parolatekrar.Equals(""))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Boş alan", "<script>alert('Parola tekrarını girin.');</script>");

        }
        else if(email_kontrol(email).Equals(false))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hatalı giriş", "<script>alert('Geçersiz mail adresi girdiniz.');</script>");
        }
        else if(!parola.Equals(parolatekrar))
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hatalı giriş", "<script>alert('Parolalar uyuşmuyor.');</script>");
        }
        else
        {
            try
            {
                string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
                baglanti = new SqlConnection(bagla);

                baglanti.Open();
                string ekleme = "insert into KullaniciBilgileri (ad,soyad,kullaniciadi,parola,email) values ('" + isim + "' , '" + soyisim

                    + "' , '" + kullaniciadi + "' , '" + parola + "' , '" + email + "')";

                komut = new SqlCommand(ekleme, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Kayıt başarılı", "<script>alert('Kaydınız başarıyla tamamlandı.');</script>");
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