using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ProjectL
{
    public partial class Student : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = 'E:\IT Lab project\myrepo\ProjectL\ProjectL\PlacementDB.mdf'; Integrated Security = True; Pooling = False";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from StudLogin where StudentId = @selstud",con );
                cmd.Parameters.AddWithValue("@selstud", TextBox1.Text);

                SqlDataReader rd = cmd.ExecuteReader();
                if(!rd.Read())
                {
                    Label1.Text = "StudentId not found";
                }

                if(TextBox2.Text.Equals(rd["Password"]))
                {
                    //login successfull
                }
                else
                {
                    //Login fail
                }
                
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
    }
}