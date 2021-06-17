using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SharedLibrary.Entities;

namespace WebAPI_Samples.Data
{
    public class SeedData
    {
        public static void Init(MovieDbContext context)
        {
            if(!context.Movies.Any())
            {
                context.Movies.Add(new Movie { Id = 1, Title = "Jurassic Park", Description = "Streichel nicht den T-Rex", Genre = Genre.Action, Price = 12.99m });
                context.Movies.Add(new Movie { Id = 2, Title = "ES", Description = "Ein Clown läuft da rum", Genre = Genre.Horror, Price = 11.99m });
                context.Movies.Add(new Movie { Id = 3, Title = "Star Wars", Description = "Sohn sucht Vater", Genre = Genre.Animations, Price = 19.99m });
            }


            context.SaveChanges();
        }
    }
}
