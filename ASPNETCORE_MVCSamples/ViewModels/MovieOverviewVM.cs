using ASPNETCORE_MVCSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.ViewModels
{
    public class MovieOverviewVM
    {
        //ctor + tab tab -> Konstruktor
        public MovieOverviewVM()
        {

        }

        public Movie Movie { get; set; }

        public string BlueRayURL { get; set; }

        public Artists Hauptdarsteller { get; set; }

        public IList<Artists> Casts { get; set; }
    }
}
