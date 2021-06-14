using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Models
{
    public class Artists
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }
    }
}
