using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tarif : System.Web.UI.Page
{
    SqlCommand komut;
    SqlConnection baglanti;

    protected void Page_Load(object sender, EventArgs e)
    {
        string uye= Request.QueryString["uye"].ToString();
        string yemek= Request.QueryString["yemek"].ToString();
        int id = int.Parse(Request.QueryString["id"].ToString());

        try
        {
            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select tarif,malzemeler from tarifler where tarif_sahip='" + uye + "' and yemek='" + yemek + "' and tarif_id=" + id;
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);

            DataTable tarif = ds.Tables[0].Copy();

            TextBox_tarifGoster.Text = tarif.Rows[0]["tarif"].ToString();
            TextBox_malzemelerTarif.Text = tarif.Rows[0]["malzemeler"].ToString();
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }



    }
}