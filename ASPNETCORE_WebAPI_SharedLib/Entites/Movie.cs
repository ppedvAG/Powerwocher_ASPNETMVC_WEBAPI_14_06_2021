using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_SharedLib.Entities
{
    public class Movie
    {
        public int ID { get; set; }

        [Required (ErrorMessage = "Ein Fehler ist passiert")]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }

    public enum Genre { Action=1, Comedy, Horror, Thriller, Romance, Animations }
}
