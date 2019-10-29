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
    public partial class ManageStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Select(String query, String parameter)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@s", parameter);

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Elg_Stud");

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(sidTB.Text != "")
            {
                Label1.Visible = true;
                String query = "SELECT * FROM Elg_Stud WHERE StudentID = @s";

                Select(query, sidTB.Text);
            }
            else if(snameTB.Text != "")
            {
                Label1.Visible = true;
                String query = "SELECT * FROM Elg_Stud WHERE Name = @s";

                Select(query, snameTB.Text);
            }
            else
            {
                Label1.Visible = false;
            }
        }

        protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = (GridViewRow) GridView1.Rows[e.RowIndex];
            String id = GridView1.Rows[e.RowIndex].Cells[1].Text;

            Delete(id);
        }

        protected void Delete(String idParam)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("DELETE FROM Elg_Stud WHERE StudentID = @sid", con);
            com.Parameters.AddWithValue("@sid", idParam);

            try
            {
                con.Open();

                com.ExecuteNonQuery();

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
    }
}