using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCORE_WebAPI_SharedLib.Entities;
using Microsoft.EntityFrameworkCore;


namespace ASPNETCORE_WebAPI_Course.Data
{
    public class ASPNETCORE_WebAPI_CourseContext : DbContext
    {
        public ASPNETCORE_WebAPI_CourseContext (DbContextOptions<ASPNETCORE_WebAPI_CourseContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
