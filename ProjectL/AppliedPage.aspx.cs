using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace ProjectL
{
    public partial class AppliedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("SELECT o.OfferID, Company, Role FROM Offer o INNER JOIN Applied a ON o.OfferID = a.OfferID AND a.StudentID = @s", con);
            com.Parameters.AddWithValue("@s", Session["user"].ToString());
            
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Offer");

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                String s = ex.ToString();
                Response.Write("<script>alert(" + s + ")</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void Companies(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }

        protected void info(object sender, EventArgs e)
        {
            string s;
            s = "InfoPage.aspx?OfferID=" + GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect(s);
        }
    }
}