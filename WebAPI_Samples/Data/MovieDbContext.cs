using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SharedLibrary.Entities;

namespace WebAPI_Samples.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
    }
}
