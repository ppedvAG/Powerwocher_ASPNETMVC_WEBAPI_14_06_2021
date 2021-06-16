using ASPNETCORE_MVCSamples.Data;
using ASPNETCORE_MVCSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly MovieDbContext _context;

        public ShoppingController(MovieDbContext context)
        {
            _context = context;
        }
        

        public IActionResult ShoppingCartOverview()
        {
            List<Movie> movieList = new List<Movie>();
            if (HttpContext.Session.IsAvailable)
            {
                if(HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    movieList = InitializeShoppingCart();
                }
            }
            return View(movieList);
        }

        private List<Movie> InitializeShoppingCart()
        {
            List<Movie> movieList = new List<Movie>();
            
            string shoppingCartJsonString = HttpContext.Session.GetString("ShoppingCart");

            List<int> ids = JsonSerializer.Deserialize<List<int>>(shoppingCartJsonString);

            foreach (int currentArticleId in ids)
            {
                var currentMovie = _context.Movies.Find(currentArticleId);
                movieList.Add(currentMovie);
            }
            return movieList;
        }


        [HttpPost]
        public IActionResult Delete (int? id)
        {
            if (!id.HasValue)
                return NotFound();

            List<Movie> movies = InitializeShoppingCart();

            if (movies.Any(a=>a.Id == id.Value))
            {
                Movie toCancel = movies.First(a => a.Id == id.Value);
                movies.Remove(toCancel);

                if (movies.Count == 0)
                {
                    HttpContext.Session.Remove("ShoppingCart");
                }
                else
                {
                    string jsonString = JsonSerializer.Serialize(movies.Select(n => n.Id).ToList());

                    HttpContext.Session.SetString("ShoppingCart", jsonString);
                }
            }

            return RedirectToAction(nameof(ShoppingCartOverview));

        }


        public IActionResult ShoppingPayment()
        {
            return View();
        }
    }
}
