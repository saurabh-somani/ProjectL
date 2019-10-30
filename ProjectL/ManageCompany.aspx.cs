using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectL
{
    public partial class ManageCompany : System.Web.UI.Page
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
            if (!TextBox2.Text.Equals(""))
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
            if (!TextBox3.Text.Equals(""))
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
                    Response.Write("<script>alert('" + ex.ToString() + "')</script>");
                }
                finally
                {
                    com.Dispose();
                    con.Close();
                }
            }
            if (!TextBox4.Text.Equals(""))
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
                    Label1.Text = "Updated Successfully";
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
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;
                SqlCommand cmd = new SqlCommand();

                try
                {
                    con.Open();
                    cmd.CommandText = "SELECT * FROM Company WHERE Company= @Sel";
                    cmd.Parameters.AddWithValue("@Sel", DropDownList1.SelectedValue.ToString());
                    cmd.Connection = con;

                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    TextBox2.Text = rd["SubType"].ToString();
                    TextBox3.Text = rd["email"].ToString();
                    TextBox4.Text = rd["phone"].ToString();

                    rd.Close();
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
            else
            {
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
            }
        }

        protected void backclick(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }
    }
}
