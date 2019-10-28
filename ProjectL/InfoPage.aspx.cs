using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class InfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LCompany.Text = Request.QueryString["Company"];
            LOfferID.Text = Request.QueryString["Offer"];
            LRole.Text = Request.QueryString["Role"];
            LType.Text = Request.QueryString["Type"];
            LDescription.Text = Request.QueryString["Description"];
            LCompensation.Text = Request.QueryString["Compensation"];
            LDeadline.Text = Request.QueryString["Deadline"];
        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("INSERT INTO Applied (StudentID, OfferID) VALUES (@sid, @oid)", con);
            com.Parameters.AddWithValue("@sid", Session["StudentID"]);
            com.Parameters.AddWithValue("@oid", Request.QueryString["OfferID"]);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert(" + ex.ToString() + ")</script>");
            }
            finally
            {
                con.Close();
                Label1.Visible = true;
                Label1.Text = "Applied Successfully";
                Apply.Enabled = false;
            }
        }
    }
}