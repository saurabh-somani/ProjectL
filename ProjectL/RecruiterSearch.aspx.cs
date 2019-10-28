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
    public partial class RecruiterSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Select()
        {
            Label1.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            String query = "SELECT DISTINCT st.StudentID, Name, Branch, CGPA FROM Student st INNER JOIN SkillSet ss ON st.StudentID = ss.StudentID ";
            int count = 0;
            foreach(ListItem d in CheckBoxList1.Items)
            {
                if(d.Selected)
                {
                    //Label1.Text += "  " + d.Value;
                    if (count == 0)
                    {
                        query += "WHERE ss.Skill = '" + d.Value + "'";
                        count++;
                    }
                    else
                    {
                        query += " OR ss.Skill = '" + d.Value + "'";
                    }
                }
            }

            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Student");

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert(" + ex.ToString() + ")</script>");
            }
            finally
            {
                con.Close();
            }

        }

        protected void Show_Click(object sender, EventArgs e)
        {
            Select();
        }
    }
}