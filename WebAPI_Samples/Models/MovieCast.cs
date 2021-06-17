using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Samples.Models
{
    public class MovieCast
    {
        public int Id { get; set; }



        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }



        public int ArtistI { get; set; }
        public virtual Artists Artists { get; set; }
    }
}
