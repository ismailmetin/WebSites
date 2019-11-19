using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data;

public partial class TarifEkle : System.Web.UI.Page
{
    SqlCommand komut;
    SqlConnection baglanti;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["Username"] != null)
            {

                DropDownList_kategori.Items.Add("corba");
                DropDownList_kategori.Items.Add("ana yemek");
                DropDownList_kategori.Items.Add("ara sıcak");
                DropDownList_kategori.Items.Add("tatlı");
                DropDownList_kategori.Items.Add("salata");




            }
            else
            {
                
                Label_yemekKate.Visible = false;
                Label_yemekTur.Visible = false;
                Label_malzeme.Visible = false;
                Label_tarif.Visible = false;
                DropDownList_kategori.Visible = false;
                DropDownList_yemekSinif.Visible = false;
                TextBox_malzeme.Visible = false;
                TextBox_tarifGir.Visible = false;
                Button_tarifEkle.Visible = false;

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Giriş Yapın", "<script>alert('Tarif eklemek için sisteme giriş yapın.');</script>");
                
                //Response.Write("<script>confirm('Tarif eklemek için giriş yapmalısınız.')/script>");
            }
        }
     
    }

    protected void DropDownList_kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        string secim = DropDownList_kategori.SelectedItem.Text;

        try
        {

            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select * from yemekler where yemek_kategori='" + secim + "'";
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);

            DataTable dataTab = ds.Tables[0].Copy();

            DropDownList_yemekSinif.Items.Clear();
            for (int i = 0; i < dataTab.Rows.Count; i++)
            {

                DropDownList_yemekSinif.Items.Add(new ListItem(dataTab.Rows[i]["yemek"].ToString(), (i).ToString()));
            }
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }


    }

    protected void Button_tarifEkle_Click(object sender, EventArgs e)
    {

        try
        {
            string uye = Session["Username"].ToString();
            string yemek_sinif = DropDownList_yemekSinif.SelectedItem.Text;
            string tarif = TextBox_tarifGir.Text;
            string yemek_kateg = DropDownList_kategori.SelectedItem.Text;
            string malzeme = TextBox_malzeme.Text;

            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            string sorgu2 = "select count(*) from tarifler";
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            komut = new SqlCommand(sorgu2, baglanti);
            int count = (Int32)komut.ExecuteScalar();
            string sorgu = "insert into tarifler (yemek,tarif,tarif_sahip,yemek_kategori,malzemeler,tarif_id) values('" + yemek_sinif + "','" + tarif + "','" + uye + "','" + yemek_kateg + "','" + malzeme + "'," + count + ")";

            komut = new SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Tarifiniz eklendi", "<script>alert('Tarif başarıyla tamamlandı.');</script>");


        }
        catch (Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }
       

      

    }
}