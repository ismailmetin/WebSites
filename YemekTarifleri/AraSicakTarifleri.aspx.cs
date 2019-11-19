using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AraSicakTarifleri : System.Web.UI.Page
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

                string sorgu = "select yemek from yemekler where yemek_kategori='ara sıcak'";
                komut = new SqlCommand(sorgu, baglanti);

                SqlDataAdapter adpt = new SqlDataAdapter(komut);

                komut.ExecuteNonQuery();



                DataSet ds = new DataSet();
                adpt.Fill(ds);

                DataTable dataTab = ds.Tables[0].Copy();

                DropDownList_arasicak.Items.Add(new ListItem("--- Ara sıcak tarifi seçiniz ---", "0"));

                for (int i = 0; i < dataTab.Rows.Count; i++)
                {

                    DropDownList_arasicak.Items.Add(new ListItem(dataTab.Rows[i]["yemek"].ToString(), (i + 1).ToString()));
                }

            }
            catch (Exception hata)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

            }
           


        }


    }

    protected void DropDownList_arasicak_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList_arasicak.SelectedValue.Equals("0"))
        {
            Response.Write("secim yap");
        }
        else
        {
            grid_doldur(DropDownList_arasicak.SelectedItem.Text);
        }

    }

    protected void GridView_arasicak_SelectedIndexChanged(object sender, EventArgs e)
    {
        string uye = GridView_arasicak.SelectedRow.Cells[1].Text;
        string yemek_ismi = DropDownList_arasicak.SelectedItem.Text;
        int id = int.Parse(GridView_arasicak.SelectedRow.Cells[2].Text);
        string id2 = id.ToString();
        Response.Redirect("Tarif.aspx?uye=" + uye + "&yemek=" + yemek_ismi + "&id=" + id2);
    }

    void grid_doldur(string arasicak)
    {

        try
        {
            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select tarif_sahip,tarif_id from tarifler where yemek='" + arasicak + "'";
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);




            GridView_arasicak.DataSource = ds.Tables[0];

            GridView_arasicak.DataBind();
            GridView_arasicak.Visible = true;
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }

    }
}