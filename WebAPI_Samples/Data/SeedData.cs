using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Samples.Models;

namespace WebAPI_Samples.Data
{
    public class SeedData
    {
        public static void Init(MovieDbContext context)
        {
            if(!context.Movies.Any())
            {
                context.Movies.Add(new Movie { Id = 1, Title = "Jurassic Park", Description = "Streichel nicht den T-Rex", Genre = Models.Genre.Action, Price = 12.99m });
                context.Movies.Add(new Movie { Id = 2, Title = "ES", Description = "Ein Clown läuft da rum", Genre = Models.Genre.Horror, Price = 11.99m });
                context.Movies.Add(new Movie { Id = 3, Title = "Star Wars", Description = "Sohn sucht Vater", Genre = Models.Genre.Animations, Price = 19.99m });
            }


            context.SaveChanges();
        }
    }
}
