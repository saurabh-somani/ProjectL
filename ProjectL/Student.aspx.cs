using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace ProjectL
{
    public partial class Student : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Select();
        }

        protected void Login(object sender, EventArgs e)
        {
            string b;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            try
             {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from StudLogin where StudentId = @selstud", con);
                cmd.Parameters.AddWithValue("@selstud", TextBox1.Text);

                SqlDataReader rd = cmd.ExecuteReader();
                if(!rd.Read())
                {
                    Label1.Text = "StudentId not found";
                }

                if(TextBox2.Text.Equals(rd["Password"]))
                {
                    //login successfull
                    Session["user"] = TextBox1.Text;
                    rd.Close();
                    cmd.CommandText = "Select Branch from Student where StudentID = @selstud";
                    rd = cmd.ExecuteReader();
                    rd.Read();
                    b = rd["Branch"].ToString();
                    Session["Branch"] = b;
                    rd.Close();
                    Response.Redirect("StudentPage.aspx");
                }
                else
                {
                    //Login fail
                    rd.Close();
                }
                
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("Invalid attempt to read when no data is present"))
                {
                    Label1.Text = "Id not found";
                }
                else
                {
                    Label1.Text = "Error " + ex.Message;
                }
            }
            finally
            {
                con.Close();
            }
        }
    }
}