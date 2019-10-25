using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectL
{
    public partial class InitialPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BRecruiter_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recruiter.aspx");
        }

        protected void BAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void BStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}