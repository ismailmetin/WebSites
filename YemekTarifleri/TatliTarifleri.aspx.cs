using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TatliTarifleri : System.Web.UI.Page
{
    SqlConnection baglanti;
    SqlCommand komut;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            try
            {
                string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
                baglanti = new SqlConnection(bagla);
                baglanti.Open();

                string sorgu = "select yemek from yemekler where yemek_kategori='tatlı'";
                komut = new SqlCommand(sorgu, baglanti);

                SqlDataAdapter adpt = new SqlDataAdapter(komut);

                komut.ExecuteNonQuery();



                DataSet ds = new DataSet();
                adpt.Fill(ds);

                DataTable dataTab = ds.Tables[0].Copy();

                DropDownList_tatlilar.Items.Add(new ListItem("--- Tatlı tarifi seçiniz ---", "0"));

                for (int i = 0; i < dataTab.Rows.Count; i++)
                {

                    DropDownList_tatlilar.Items.Add(new ListItem(dataTab.Rows[i]["yemek"].ToString(), (i + 1).ToString()));
                }
            }
            catch(Exception hata)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

            }
          



        }





    }

    protected void DropDownList_tatlilar_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList_tatlilar.SelectedValue.Equals("0"))
        {
            Response.Write("secim yap");
        }
        else
        {
            grid_doldur(DropDownList_tatlilar.SelectedItem.Text);
        }

    }

    void grid_doldur(string tatli)
    {
        try
        {
            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select tarif_sahip,tarif_id from tarifler where yemek='" + tatli + "'";
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);




            GridView_tatlilar.DataSource = ds.Tables[0];

            GridView_tatlilar.DataBind();
            GridView_tatlilar.Visible = true;
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }


    }

    protected void GridView_tatlilar_SelectedIndexChanged(object sender, EventArgs e)
    {

        string uye = GridView_tatlilar.SelectedRow.Cells[1].Text;
        string yemek_ismi = DropDownList_tatlilar.SelectedItem.Text;
        int id = int.Parse(GridView_tatlilar.SelectedRow.Cells[2].Text);
        string id2 = id.ToString();
        Response.Redirect("Tarif.aspx?uye=" + uye + "&yemek=" + yemek_ismi + "&id=" + id2);

    }
}