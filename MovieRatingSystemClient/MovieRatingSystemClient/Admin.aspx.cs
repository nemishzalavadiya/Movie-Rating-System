using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieRatingSystemClient
{
    public partial class Admin : System.Web.UI.Page
    {
        MovieSystemServiceReferece.MovieSystemClient client;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManage.sessionId == -1)
            {
                Response.Redirect("Login.aspx");
            }
            client = new MovieSystemServiceReferece.MovieSystemClient();
            Admin_Label.Text = "";
            IEnumerable<MovieSystemServiceReferece.Movie> data = client.ShowMovie();
            if (data.Count() == 0)
            {
                Admin_Label.ForeColor = System.Drawing.Color.Green;
                Admin_Label.Text = "No Data Available";
            }
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void Movie_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[2].Text;
            int id_ = Convert.ToInt32(id);
            string result = client.DeleteMovie(id_);
            Admin_Label.Text = result;
            GridView1.DataSource = client.ShowMovie();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[2].Text;
            int id_ = Convert.ToInt32(id);

            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
            {
                Admin_Label.ForeColor = System.Drawing.Color.Red;
                Admin_Label.Text = "Fill All TextBoxs With New Values To Update Row";
                return;
            }
            MovieSystemServiceReferece.Movie movie = new MovieSystemServiceReferece.Movie();
            try
            {
                double rate = Convert.ToDouble(TextBox3.Text);
                if (rate > 10 || rate < 0)
                {
                    Admin_Label.ForeColor = System.Drawing.Color.Red;
                    Admin_Label.Text = "Rating Must Be Between [ 0, 10 ]";
                    return;
                }
                movie.Movie_Name = TextBox2.Text.ToUpper();
                movie.Movie_Type = TextBox1.Text.ToUpper();
                movie.Movie_Rating = rate;
            }
            catch (Exception e_)
            {
                Admin_Label.ForeColor = System.Drawing.Color.Red;
                Admin_Label.Text = "Rating Must be Number";
            }
            string result = client.UpdateMovie(id_, movie);
            Admin_Label.ForeColor = System.Drawing.Color.Green;
            Admin_Label.Text = result;
            GridView1.DataSource = client.ShowMovie();
            GridView1.DataBind();
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
                {
                    Admin_Label.ForeColor = System.Drawing.Color.Red;
                    Admin_Label.Text = "Fill All TextBoxs";
                    return;
                }
                double rate = Convert.ToDouble(TextBox3.Text);
                if (rate > 10 || rate < 0)
                {
                    Admin_Label.ForeColor = System.Drawing.Color.Red;
                    Admin_Label.Text = "Rating Must Be Between [ 0, 10 ]";
                    return;
                }
                MovieSystemServiceReferece.Movie movie = new MovieSystemServiceReferece.Movie();
                movie.Movie_Name = TextBox2.Text.ToUpper();
                movie.Movie_Type = TextBox1.Text.ToUpper();
                movie.Movie_Rating = rate;

                IEnumerable<string> list_movie = client.getMovie_Name();
                foreach(string s in list_movie){
                    if (s.Equals(TextBox2.Text.ToUpper())) {
                        Admin_Label.ForeColor = System.Drawing.Color.Red;
                        Admin_Label.Text = "Movie Already Available";
                        return;
                    }
                }

                Admin_Label.ForeColor = System.Drawing.Color.Green;
                Admin_Label.Text = client.AddMovie(movie);
                GridView1.DataSource = client.ShowMovie();
                GridView1.DataBind();
            }
            catch (Exception e_) {
                Admin_Label.ForeColor = System.Drawing.Color.Red;
                Admin_Label.Text = "Rating Must be Number";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void User_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_User_Check.aspx");
        }

        protected void Movie_Rating_Click(object sender, EventArgs e)
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