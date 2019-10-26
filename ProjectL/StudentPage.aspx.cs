﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        protected void Select()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("SELECT Company, Deadline, Type FROM Offer o INNER JOIN Elg_Branch e ON o.OfferID = e.OfferID AND e.Branch = @b", con);
            com.Parameters.AddWithValue("@b", Session["Branch"].ToString());
            //SqlCommand com = new SqlCommand("SELECT Company, Deadline, Type FROM Offer", con);
            Label1.Text = Session["Branch"].ToString();

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
                String s = ex.ToString();
                Response.Write("<script>alert(" + s + ")</script>");
            }
            finally
            {
                con.Close();
            }

            /*SqlCommand com = new SqlCommand("SELECT * FROM Elg_Branch");
            Label1.Text = Session["Branch"].ToString();

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Elg_Branch");

                GridView2.DataSource = ds;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                String s = ex.ToString();
                Response.Write("<script>alert(" + s + ")</script>");
            }
            finally
            {
                con.Close();
            }*/
        }
    }
}