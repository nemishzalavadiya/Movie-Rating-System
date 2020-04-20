using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRatingSystem.Model
{
    public class User_Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Rarting_Id { get; set; } 
        [Required]
       
        public int UserId { get; set; }
        public virtual SystemUser SystemUser { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public double User_Provided_Rating { get; set; }
    }
}
