using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class RecruiterDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateQuery()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;
            SqlCommand com = null;
            String query = "";
            if(TextBox2.Text != null)
            {
                query = "UPDATE Company SET ";
                query += "SubType = @st ";
                query += "WHERE Company = @c";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@c", DropDownList1.SelectedItem.Text);
                com.Parameters.AddWithValue("@st", TextBox2.Text);

                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(" + ex.ToString() + ")</script>");
                }
                finally
                {
                    com.Dispose();
                    con.Close();
                }
            }
            if(TextBox3.Text != null)
            {
                query = "UPDATE Company SET ";
                query += "email = @e ";
                query += "WHERE Company = @c";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@c", DropDownList1.SelectedItem.Text);
                com.Parameters.AddWithValue("@e", TextBox3.Text);

                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(" + ex.ToString() + ")</script>");
                }
                finally
                {
                    com.Dispose();
                    con.Close();
                }
            }
            if(TextBox4.Text != null)
            {
                query = "UPDATE Company SET ";
                query += "phone = @p ";
                query += "WHERE Company = @c";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@c", DropDownList1.SelectedItem.Text);
                com.Parameters.AddWithValue("@p", TextBox4.Text);

                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert(" + ex.ToString() + ")</script>");
                }
                finally
                {
                    com.Dispose();
                    con.Close();
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateQuery();
            Label1.Text = "Updated Successfully";
        }
    }
}