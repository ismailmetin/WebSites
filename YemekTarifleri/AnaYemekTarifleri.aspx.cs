using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AnaYemekTarifleri : System.Web.UI.Page
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

                string sorgu = "select yemek from yemekler where yemek_kategori='ana yemek'";
                komut = new SqlCommand(sorgu, baglanti);

                SqlDataAdapter adpt = new SqlDataAdapter(komut);

                komut.ExecuteNonQuery();



                DataSet ds = new DataSet();
                adpt.Fill(ds);

                DataTable dataTab = ds.Tables[0].Copy();

                DropDownList_anayemek.Items.Add(new ListItem("--- Ana yemek tarifi seçiniz ---", "0"));

                for (int i = 0; i < dataTab.Rows.Count; i++)
                {

                    DropDownList_anayemek.Items.Add(new ListItem(dataTab.Rows[i]["yemek"].ToString(), (i + 1).ToString()));
                }
            }
            catch(Exception hata)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('"+hata.GetType().ToString()+"');</script>");

            }




        }




    }

    protected void DropDownList_anayemek_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownList_anayemek.SelectedValue.Equals("0"))
        {
            Response.Write("secim yap");
        }
        else
        {
            grid_doldurma(DropDownList_anayemek.SelectedItem.Text);
        }

    }

    protected void GridView_anayemek_SelectedIndexChanged(object sender, EventArgs e)
    {
        string uye = GridView_anayemek.SelectedRow.Cells[1].Text;
        string yemek_ismi = DropDownList_anayemek.SelectedItem.Text;
        int id = int.Parse(GridView_anayemek.SelectedRow.Cells[2].Text);
        string id2 = id.ToString();
        Response.Redirect("Tarif.aspx?uye=" + uye + "&yemek=" + yemek_ismi + "&id=" + id2);
    }

    void grid_doldurma(string anayemek)
    {

        try
        {
            string bagla = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
            baglanti = new SqlConnection(bagla);
            baglanti.Open();

            string sorgu = "select tarif_sahip,tarif_id from tarifler where yemek='" + anayemek + "'";
            komut = new SqlCommand(sorgu, baglanti);

            SqlDataAdapter adpt = new SqlDataAdapter(komut);

            komut.ExecuteNonQuery();



            DataSet ds = new DataSet();
            adpt.Fill(ds);




            GridView_anayemek.DataSource = ds.Tables[0];

            GridView_anayemek.DataBind();
            GridView_anayemek.Visible = true;
        }
        catch(Exception hata)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('" + hata.GetType().ToString() + "');</script>");

        }

    }

}