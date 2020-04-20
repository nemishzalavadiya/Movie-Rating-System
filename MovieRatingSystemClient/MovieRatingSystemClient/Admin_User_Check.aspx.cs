using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRatingSystemClient
{
    public partial class Admin_User_Check : System.Web.UI.Page
    {
        MovieSystemServiceReferece.MovieSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManage.sessionId == -1)
            {
                Response.Redirect("Login.aspx");
            }
            client = new MovieSystemServiceReferece.MovieSystemClient();
            Admin_User_Label.Text = "";
            IEnumerable<MovieSystemServiceReferece.SystemUser> data = client.ShowUser();
            if (data.Count() == 0) {
                Admin_User_Label.ForeColor = System.Drawing.Color.Green;
                Admin_User_Label.Text = "No Data Available";
            }
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Movie__Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void User__Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_User_Check.aspx");
        }

        protected void Movie_Rating__Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_User_Rating.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            SessionManage.sessionId = -1;
            Response.Redirect("Login.aspx");
        }
    }
}