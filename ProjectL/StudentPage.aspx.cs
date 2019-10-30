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
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Select();
            }
        }

        protected void Select()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            SqlCommand com = new SqlCommand("SELECT o.OfferID, Company, Deadline, Type FROM Offer o INNER JOIN Elg_Branch e ON o.OfferID = e.OfferID AND e.Branch = @b", con);
            com.Parameters.AddWithValue("@b", Session["Branch"].ToString());
            //SqlCommand com = new SqlCommand("SELECT Company, Deadline, Type FROM Offer", con);
            //Label1.Text = Session["Branch"].ToString();

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
                Response.Write("<script>alert('" + s + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void Info(object sender, EventArgs e)
        {
            string s;
            s = "InfoPage.aspx?OfferID="+GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect(s);
        }

        protected void Applied(object sender, EventArgs e)
        {
            Response.Redirect("AppliedPage.aspx");
        }

        protected void Companies(object sender, EventArgs e)
        {
            Response.Redirect("StudentPage.aspx");
        }

        protected void GV_OnSorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = direction;
            if (direction == "ASC")
            {
                sortingDirection = direction = "DESC";

            }
            else
            {
                sortingDirection = direction = "ASC";

            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlacementDB"].ConnectionString;

            string query = "SELECT o.OfferID, Company, Deadline, Type FROM Offer o INNER JOIN Elg_Branch e ON o.OfferID = e.OfferID AND e.Branch = @b ORDER BY ";
            query += e.SortExpression + " " + sortingDirection;
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@b", Session["Branch"].ToString());
            //SqlCommand com = new SqlCommand("SELECT Company, Deadline, Type FROM Offer", con);
            //Label1.Text = Session["Branch"].ToString();

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Offer");

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                String s = ex.Message;
                //Response.Write("<script>alert('" + s + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        public string direction
        {
            get
            {
                if (ViewState["directionState"] == null)
                {
                    ViewState["directionState"] = "ASC";
                }
                return (string)ViewState["directionState"];
            }
            set
            {
                ViewState["directionState"] = value;
            }
        }
    }
}