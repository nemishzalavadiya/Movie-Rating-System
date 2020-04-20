using MovieRatingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieRatingSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MovieSystem : IMovieSystem
    {
        MovieRate context;
        MovieSystem() {
            context = new MovieRate();
        }
        //########################################################################## Movies
        public string AddMovie(Movie movie) 
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return "Movie Added";
        }
        public string UpdateMovie(int id,Movie movie)
        {
            Movie movie_= context.Movies.Find(id);
            movie_.Movie_Name = movie.Movie_Name;
            movie_.Movie_Rating = movie.Movie_Rating;
            movie_.Movie_Type = movie.Movie_Type;
            context.SaveChanges();
            return "Movie Updated";
        }
        public string DeleteMovie(int id)
        {
            Movie m=context.Movies.Find(id);
            context.Movies.Remove(m);
            context.SaveChanges();
            return "Deleted SuccessFully";
        }
        public IEnumerable<Movie> ShowMovie()
        {
            IEnumerable<Movie> list =context.Movies.ToList();
            return list;
        }
        //########################################################################## Users
        public string AddUser(SystemUser user)
        {
            context.SystemUsers.Add(user);
            context.SaveChanges();
            return "User Added";
        }
        public string UpdateUser(int id, SystemUser user)
        {
            SystemUser user_ = context.SystemUsers.Find(id);
            user_.User_Name = user.User_Name;
            user_.User_Password = user.User_Password;
            context.SaveChanges();
            return "User Updated";
        }
        public string DeleteUser(int id)
        {
           SystemUser user= context.SystemUsers.Find(id);
            context.SystemUsers.Remove(user);
            context.SaveChanges();
            return "Deleted SuccessFully";
        }
        public IEnumerable<SystemUser> ShowUser()
        {
            IEnumerable<SystemUser> list = context.SystemUsers.ToList();
            return list;
        }
        public string Verify_User(String username, string password) {
            SystemUser user = context.SystemUsers.FirstOrDefault(x => x.User_Name == username && x.User_Password == password);
            if (user != null)
            {
                string des = user.User_Designation.ToString();
                string id__ = user.UserId.ToString();
                return des+" "+id__;
            }
            else {
                return "Invalide Username Or Password";
            }

        }
        //########################################################################## Ratings
        public string AddRating(User_Rating rate)
        {
            context.User_Ratings.Add(rate);
            context.SaveChanges();
            return "Ratings Added";
        }
        public string UpdateRating(int id, RatinDto movie)
        {
            User_Rating rate = context.User_Ratings.Find(id);
            rate.MovieName = movie.MovieName;
            rate.User_Provided_Rating = movie.User_Provided_Rating;
            context.SaveChanges();
            return "Ratings Updated";
        }
        public string DeleteRating(int id)
        {
            User_Rating movie = context.User_Ratings.Find(id);
            context.User_Ratings.Remove(movie);
            context.SaveChanges();
            return "Ratings Deleted SuccessFully";
        }
        public IEnumerable<RatinDto> ShowRating()
        {
            IEnumerable<RatinDto> list = context.User_Ratings.Select(  x=> new RatinDto(){User_Rarting_Id=x.User_Rarting_Id,UserId=x.UserId ,MovieName=x.MovieName,User_Provided_Rating=x.User_Provided_Rating }  ).ToList();
            return list;
        }
        public IEnumerable<RatinDto2> ShowRating_short()
        {
            IEnumerable<RatinDto2> list = context.User_Ratings.Select(x => new RatinDto2() {  MovieName = x.MovieName, User_Provided_Rating = x.User_Provided_Rating }).ToList();
            return list;
        }
        public IEnumerable<RatinDto2> ShowRating_Persional(int id)
        {
            IEnumerable<RatinDto2> list = context.User_Ratings.Where(x=>x.UserId==id).Select(x => new RatinDto2() { MovieName = x.MovieName, User_Provided_Rating = x.User_Provided_Rating }).ToList();
            return list;
        }
        public IEnumerable<RatinDto3> ShowRating_Log(int id)
        {
            IEnumerable<RatinDto3> list = context.User_Ratings.Where(x => x.UserId == id).Select(x => new RatinDto3() { User_Rarting_Id=x.User_Rarting_Id,MovieName = x.MovieName, User_Provided_Rating = x.User_Provided_Rating }).ToList();
            return list;
        }
        public IEnumerable<string> getMovie_Name() {

            return context.Movies.Select(x => x.Movie_Name).ToList();
        }
    }
}
