using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectL
{
    public partial class Recruiter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlDataReader rd;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from RecLogin where Id = @sel", con);
                cmd.Parameters.AddWithValue("@sel", TextBox1.Text);

                rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    Label1.Text = "Id not found";
                }

                if (TextBox2.Text.Equals(rd["Password"]))
                {
                    //login successfull
                    Session["user"] = TextBox1.Text;
                    rd.Close();
                    Response.Redirect("RecruiterDashboard.aspx");
                }
                else
                {
                    //Login fail
                    Label1.Text = "Invalid password";
                    rd.Close();
                }

            }
            catch (Exception ex)
            {
                Label1.Text = "Error " + ex.ToString();
            }
            finally
            {
                con.Close();
            }
        }
    }
}