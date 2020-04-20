using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
namespace MovieRatingSystemClient
{
    public partial class Login : System.Web.UI.Page
    {
        MovieSystemServiceReferece.MovieSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new MovieSystemServiceReferece.MovieSystemClient();
            Error_Login.Text = "";
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (password.Text == "" || username.Text == "")
            {
                Error_Login.ForeColor = System.Drawing.Color.Red;
                Error_Login.Text= "All Fields Are Mandatory";return;
            }
            string result=client.Verify_User(username.Text.ToUpper(), password.Text.ToUpper());
            string[] arr = result.Split(' ');
            if (arr[0].Equals("Admin"))
            {
                SessionManage.sessionId = Convert.ToInt32(arr[1]);
                Response.Redirect("Admin.aspx");
            }
            else if (arr[0].Equals("User"))
            {
                SessionManage.sessionId = Convert.ToInt32(arr[1]);
                Response.Redirect("User.aspx");
            }
            else {
                Error_Login.Text = result;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}