using ASPNETCORE_MVCSamples.Data;
using ASPNETCORE_MVCSamples.Models;
using ASPNETCORE_MVCSamples.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class RazorSampleWithVMController : Controller
    {
        private readonly MovieDbContext _context;


        public RazorSampleWithVMController(MovieDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            //ViewModel wird befüllt und an oberfläche übergeben
            MovieOverviewVM vm = new MovieOverviewVM();

            vm.Movie = _context.Movies.First();
            vm.BlueRayURL = "amazon/BlueRay/irgendeineURL";

            if (vm.Casts == null)
                vm.Casts = new List<Artists>();

            //vm.Casts ?? new List<Artists>();

            //vm.Casts.Add(new Models.Artists
            //{
            //    Id = 1,
            //    Firstname = "Maria",
            //    Lastname = "Musterfrau"
            //});
            //vm.Casts.Add(new Models.Artists
            //{
            //    Id = 2,
            //    Firstname = "Max",
            //    Lastname = "Mustermann"
            //});


            //Model/ViewModel(Daten) werden von Controller an die View übergeben
            return View(vm);
        }

        public IActionResult ShowEasyList()
        {
            IList<Artists> artists = new List<Artists>();
            artists.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Maria",
                Lastname = "Musterfrau"
            });
            artists.Add(new Models.Artists
            {
                Id = 1,
                Firstname = "Max",
                Lastname = "Mustermann"
            });

            return View(artists);
        }
    }
}
