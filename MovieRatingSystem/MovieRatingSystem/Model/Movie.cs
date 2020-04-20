using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MovieRatingSystem.Model
{
    public class Movie
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Movie_Id { get; set; }
        [Required]
        public string Movie_Name { get; set; }
        [Required]
        public string Movie_Type { get; set; }
        public double Movie_Rating { get; set; }
    }
}
