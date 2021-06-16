using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_MVCSamples.Data;
using ASPNETCORE_MVCSamples.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ASPNETCORE_MVCSamples.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }





       
        // GET: Movie
        public async Task<IActionResult> Index(string query)
        { 
            if (!string.IsNullOrEmpty(query))
            {
                //ViewData ist eine Einmalnachricht von Controller an View 
                ViewData["FilterQuery"] = query;
            }

            IList<Movie> filterdList = string.IsNullOrEmpty(query) ?
                await _context.Movies.ToListAsync() :
                await _context.Movies.Where(q => q.Title.Contains(query)).ToListAsync();

            return View(filterdList);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }





        [Route("Movie/Create")]

        // GET: Movie/Create
        public IActionResult Create()
        {
            //Zeig ein leeres Formular an
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        [Route("Movie/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Genre,Price")] Movie movie)
        {

            //POST -> Formular wird an WebServer gesendet und ausgewertet
            if (movie.Price > 1000)
            {
                ModelState.AddModelError("Price", "Kann es sein, dass wir hier Probleme mit Cultures haben");
            }

            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie); //Edit Formular zum Bearbeiten des Datensatzes
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult Buy(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            //Wir wird der Warenkorb befüllt. Beim Thema Session -> wird weiterprogrammiert

            if (HttpContext.Session.IsAvailable)
            {
                List<int> idList = new List<int>();

                //Schauen, ob der Warenkorb schon existiert
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    //Lese vorhandene ids 
                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");

                    idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
                }

                idList.Add(id.Value);

                string jsonString = JsonSerializer.Serialize(idList);
                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Wish (int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            //Wir wird der Warenkorb befüllt. Beim Thema Session -> wird weiterprogrammiert

            return RedirectToAction(nameof(Index));
        }
    }
}
