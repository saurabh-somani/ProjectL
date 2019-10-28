﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class InfoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.QueryString["OfferID"];
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Offer WHERE OfferID = @o", con);
                cmd.Parameters.AddWithValue("@o", s);

                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();

                LCompany.Text = rd["Company"].ToString();
                LOfferID.Text = rd["OfferID"].ToString();
                LRole.Text = rd["Role"].ToString();
                LType.Text = rd["Type"].ToString();
                LDescription.Text = rd["Description"].ToString();
                LCompensation.Text = rd["Compensation"].ToString();
                LDeadline.Text = rd["Deadline"].ToString();

                rd.Close();
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.ToString();
            }
            finally
            {
                con.Close();
            }

            
        }

        protected void Apply_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("INSERT INTO Applied (StudentID, OfferID) VALUES (@sid, @oid)", con);
            com.Parameters.AddWithValue("@sid", Session["StudentID"]);
            com.Parameters.AddWithValue("@oid", Request.QueryString["OfferID"]);

            try
            {
                con.Open();
                com.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert(" + ex.ToString() + ")</script>");
            }
            finally
            {
                con.Close();
                Label1.Visible = true;
                Label1.Text = "Applied Successfully";
                Apply.Enabled = false;
            }
        }
    }
}