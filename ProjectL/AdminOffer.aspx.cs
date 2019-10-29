using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class AdminOffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyTB.Text = Session["user"].ToString();
            Select();
        }

        protected void Select()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("SELECT * FROM Offer", con);

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Offer");

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void Insert()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("INSERT INTO Offer (Company,Role,Type,Description,Compensation,Deadline) VALUES (@c,@r,@t,@d,@cs,@dl)", con);
            com.Parameters.AddWithValue("@c", CompanyTB.Text);
            com.Parameters.AddWithValue("@r", RoleTB.Text);
            com.Parameters.AddWithValue("@t", TypeDDL.SelectedValue);
            com.Parameters.AddWithValue("@d", DescriptionTB.Text);
            com.Parameters.AddWithValue("@cs", CompensationTB.Text);
            com.Parameters.AddWithValue("@dl", DeadlineTB.Text);

            try
            {
                con.Open();
                com.ExecuteNonQuery();

                Label1.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void InsertEB()
        {
            int index = GridView1.Rows.Count - 1;
            Int32.TryParse(GridView1.Rows[index].Cells[0].Text, out int oid);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com;

            foreach(ListItem d in CheckBoxList1.Items)
            {
                if(d.Selected)
                {
                    com = new SqlCommand("INSERT INTO Elg_Branch (OfferID,Branch) VALUES (@oid, @b)", con);
                    com.Parameters.AddWithValue("@oid", oid);
                    com.Parameters.AddWithValue("@b", d.Text);

                    try
                    {
                        con.Open();
                        com.ExecuteNonQuery();

                        Label1.Visible = true;
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
        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            Insert();

            CompanyTB.Text = "";
            RoleTB.Text = "";
            DescriptionTB.Text = "";
            CompensationTB.Text = "";
            DeadlineTB.Text = "";

            Select();
            InsertEB();

            CheckBoxList1.ClearSelection();
        }

        protected void backClick(object sender, EventArgs e)
        {
            Response.Redirect("RecruiterDashboard.aspx");
        }
    }
}