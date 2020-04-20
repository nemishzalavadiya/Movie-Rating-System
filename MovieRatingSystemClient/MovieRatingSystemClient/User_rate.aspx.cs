using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRatingSystemClient
{
    public partial class User_rate : System.Web.UI.Page
    {
        MovieSystemServiceReferece.MovieSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new MovieSystemServiceReferece.MovieSystemClient();
            User_Rate.Text = "";
            IEnumerable<MovieSystemServiceReferece.RatinDto3> data = client.ShowRating_Log(SessionManage.sessionId);
            if (data.Count() == 0)
            {
                User_Rate.ForeColor = System.Drawing.Color.Green;
                User_Rate.Text = "No Data Available";
            }
            GridView1.DataSource = data;
            GridView1.DataBind();
            if (IsPostBack)
                return;
            if (SessionManage.sessionId == -1) {
                Response.Redirect("Login.aspx");
            }
            
            DropDownList1.DataSource = client.getMovie_Name();
            DropDownList1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == "") {
                User_Rate.ForeColor = System.Drawing.Color.Red;
                User_Rate.Text = "Both Fields Are Required";
            }
            try
            {
                double rate = Convert.ToDouble(TextBox3.Text);
                if (rate > 10 || rate < 0) {
                    User_Rate.ForeColor = System.Drawing.Color.Red;
                    User_Rate.Text = "Ratig Must Be Between [ 0, 10 ]";
                }
                MovieSystemServiceReferece.User_Rating rto = new MovieSystemServiceReferece.User_Rating();
                rto.MovieName = DropDownList1.SelectedValue;
                rto.User_Provided_Rating = rate;
                rto.UserId = SessionManage.sessionId;
                string result = client.AddRating(rto);
                User_Rate.ForeColor = System.Drawing.Color.Green;
                User_Rate.Text = result;
            }
            catch (Exception e_) {
                User_Rate.ForeColor = System.Drawing.Color.Red;
                User_Rate.Text = "Ratig Must Be Between Numeric";
            }
            IEnumerable<MovieSystemServiceReferece.RatinDto3> data = client.ShowRating_Log(SessionManage.sessionId);
            GridView1.DataSource = data;
            GridView1.DataBind();

        }

        protected void Movie_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void Provide_Rating_Click(object sender, EventArgs e)
        {
            Response.Redirect("User_rate.aspx");
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[4].Text;
            int id_ = Convert.ToInt32(id);
            string result = client.DeleteRating(id_);
            User_Rate.ForeColor = System.Drawing.Color.Green;
            User_Rate.Text = result;
            GridView1.DataSource = client.ShowRating_Log(SessionManage.sessionId);
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id= GridView1.Rows[e.RowIndex].Cells[4].Text;
            int id_ = Convert.ToInt32(id);

            if (TextBox3.Text == "")
            {
                User_Rate.ForeColor = System.Drawing.Color.Red;
                User_Rate.Text = "Fill All TextBoxs With New Values To Update Row";
                return;
            }
            MovieSystemServiceReferece.RatinDto movie = new MovieSystemServiceReferece.RatinDto();
            try
            {
                double rate = Convert.ToDouble(TextBox3.Text);
                if (rate > 10 || rate < 0)
                {
                    User_Rate.ForeColor = System.Drawing.Color.Red;
                    User_Rate.Text = "Rating Must Be Between [ 0, 10 ]";
                    return;
                }
                movie.MovieName = DropDownList1.SelectedValue;
                movie.User_Provided_Rating = rate;
                movie.UserId = SessionManage.sessionId;
            }
            catch (Exception e_)
            {
                User_Rate.ForeColor = System.Drawing.Color.Red;
                User_Rate.Text = "Rating Must be Number";
            }
            string result = client.UpdateRating(id_, movie);
            User_Rate.ForeColor = System.Drawing.Color.Green;
            User_Rate.Text = result;
            GridView1.DataSource = client.ShowRating_Log(SessionManage.sessionId);
            GridView1.DataBind();
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            SessionManage.sessionId = -1;
            Response.Redirect("Login.aspx");
        }
    }
}