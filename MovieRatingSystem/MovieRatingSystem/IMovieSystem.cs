using MovieRatingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieRatingSystem
{
    [ServiceContract]
    public interface IMovieSystem
    {
        [OperationContract]
        string AddMovie(Movie e);
        [OperationContract]
        string UpdateMovie(int id,Movie e);
        [OperationContract]
        string DeleteMovie(int id);
        [OperationContract]
        IEnumerable<Movie> ShowMovie();
        [OperationContract]
        string AddUser(SystemUser s);
        [OperationContract]
        string DeleteUser(int id);
        [OperationContract]
        string UpdateUser(int id,SystemUser e);
        [OperationContract]
        IEnumerable<SystemUser> ShowUser();
        [OperationContract]
        string Verify_User(string user, string pass);
        [OperationContract]
        string AddRating(User_Rating s);
        [OperationContract]
        string DeleteRating(int id);
        [OperationContract]
        string UpdateRating(int id,RatinDto e);
        [OperationContract]
        IEnumerable<RatinDto> ShowRating();
        [OperationContract]
        IEnumerable<RatinDto2> ShowRating_short();
        [OperationContract]
        IEnumerable<RatinDto2> ShowRating_Persional(int id);
        [OperationContract]
        IEnumerable<RatinDto3> ShowRating_Log(int id);
        [OperationContract]
        IEnumerable<string> getMovie_Name();
    }

}
