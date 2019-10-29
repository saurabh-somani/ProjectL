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
            TextBox1.Text = Session["user"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                con.Open();
                cmd.CommandText = "SELECT * FROM Company WHERE Company= @Sel";
                cmd.Parameters.AddWithValue("@Sel", Session["User"].ToString());
                cmd.Connection = con;

                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                TextBox2.Text = rd["SubType"].ToString();
                TextBox3.Text = rd["email"].ToString();
                TextBox4.Text = rd["phone"].ToString();

                rd.Close();
            }
            catch(Exception ex)
            {
                Label1.Text = "Error " + ex.ToString();
            }
            finally
            {
                con.Close();
            }


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
                com.Parameters.AddWithValue("@c", TextBox1.Text);
                com.Parameters.AddWithValue("@st", TextBox2.Text);

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
            if(TextBox3.Text != null)
            {
                query = "UPDATE Company SET ";
                query += "email = @e ";
                query += "WHERE Company = @c";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@c", TextBox1.Text);
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
            if(TextBox4.Text != null)
            {
                query = "UPDATE Company SET ";
                query += "phone = @p ";
                query += "WHERE Company = @c";
                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@c", TextBox1.Text);
                com.Parameters.AddWithValue("@p", TextBox4.Text);

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
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            UpdateQuery();
            Label1.Text = "Updated Successfully";
        }

        protected void Search(object sender, EventArgs e)
        {
            Response.Redirect("RecruiterSearch.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Response.Redirect("InitialPage.aspx");
        }
    }
}