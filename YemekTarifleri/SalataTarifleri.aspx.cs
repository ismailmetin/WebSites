using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SalataTarifleri : System.Web.UI.Page
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

                string sorgu = "select yemek from yemekler where yemek_kategori='salata'";
                komut = new SqlCommand(sorgu, baglanti);

                SqlDataAdapter adpt = new SqlDataAdapter(komut);

                komut.ExecuteNonQuery();



                DataSet ds = new DataSet();
                adpt.Fill(ds);

                DataTable dataTab = ds.Tables[0].Copy();

                DropDownList_salata.Items.Add(new ListItem("--- Salata tarifi seçiniz ---", "0"));

                for (int i = 0; i < dataTab.Rows.Count; i++)
                {

                    DropDownList_salata.Items.Add(new ListItem(dataTab.Rows[i]["yemek"].ToString(), (i + 1).ToString()));
                }
            }
            catch(Exception hata)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

            }
            



        }

    }

    protected void DropDownList_salata_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList_salata.SelectedValue.Equals("0"))
        {
            Response.Write("secim yap");
        }
        else
        {
            grid_doldur(DropDownList_salata.SelectedItem.Text);
        }

    }

    void grid_doldur(string salata)
    {

        try
        {
            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select tarif_sahip,tarif_id from tarifler where yemek='" + salata + "'";
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);




            GridView_salata.DataSource = ds.Tables[0];

            GridView_salata.DataBind();
            GridView_salata.Visible = true;
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }

    }


    protected void GridView_salata_SelectedIndexChanged(object sender, EventArgs e)
    {
        string uye = GridView_salata.SelectedRow.Cells[1].Text;
        string yemek_ismi = DropDownList_salata.SelectedItem.Text;
        int id = int.Parse(GridView_salata.SelectedRow.Cells[2].Text);
        string id2 = id.ToString();
        Response.Redirect("Tarif.aspx?uye=" + uye + "&yemek=" + yemek_ismi + "&id=" + id2);
    }
}