using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MovieRatingSystemClient
{
    public partial class Register : System.Web.UI.Page
    {
        MovieSystemServiceReferece.MovieSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new MovieSystemServiceReferece.MovieSystemClient();
            Error_register.Text = "";
        }

        protected void Log_id_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Register_User_Click(object sender, EventArgs e)
        {
            string result = "";
            if (password_register.Text == "" || reenter_password_register.Text == "" || username_register.Text == "") {
                Error_register.ForeColor = System.Drawing.Color.Red;
                result = "All Fields Are Mandatory";
            }
            else if (password_register.Text.ToUpper().Trim().Equals(reenter_password_register.Text.ToUpper().Trim()))
            {
                MovieSystemServiceReferece.SystemUser user = new MovieSystemServiceReferece.SystemUser();
                user.User_Name = username_register.Text.ToUpper();
                user.User_Password = password_register.Text.ToUpper();
                user.User_Designation = "User";
                result = client.AddUser(user);
                Error_register.ForeColor = System.Drawing.Color.Green;
            }
            else {
                Error_register.ForeColor = System.Drawing.Color.Red;
                result = "Both Passwords Must Be Same";
            }
            Error_register.Text = result;
        }
    }
}