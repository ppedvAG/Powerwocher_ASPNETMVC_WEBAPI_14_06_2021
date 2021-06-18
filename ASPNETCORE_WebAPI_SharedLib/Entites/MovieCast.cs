using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI_SharedLib.Entities
{
    public class MovieCast
    {
        public int Id { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }


        public int ArtistId { get; set; }
        public virtual Artists Artist { get; set; }
    }
}
