using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SharedLibrary.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        //[Display(Name = "Titel")]
        //[Required (ErrorMessage ="Titel muss eingegeben werden")] //Titel ist jetzt ein Muss-Feld
        //[StringLength(30)]
        public string Title { get; set; }


        //[Display(Name = "Beschreibung")]
        //[MaxLength(100)]
        public string Description { get; set; }

        //public Genre Genre { get; set; }

        //[Required]
        //[Display(Name = "Preis")]
        public decimal Price { get; set; }



        public DateTime Published { get; set; }


        //Navigation zu Relationale Daten
        //public  List<MovieCast> MovieCasts { get; set; } //-> ComplexeTypes
    }


    //public enum Genre {  Action=1, Comedy=2, Horror=3, Thriller=4, Romance=5, Animations=6, Drama=7, Documentary=8}
}
