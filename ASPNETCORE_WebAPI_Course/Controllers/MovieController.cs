using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE_WebAPI_Course.Data;
using ASPNETCORE_WebAPI_SharedLib.Entities;

namespace ASPNETCORE_WebAPI_Course.Controllers
{
    [Route("Stammdaten/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ASPNETCORE_WebAPI_CourseContext _context;

        public MovieController(ASPNETCORE_WebAPI_CourseContext context)
        {
            _context = context;
        }

        // GET: Stammdaten/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: Stammdaten/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: Stammdaten/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Stammdaten/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.ID }, movie);
        }

        // DELETE: Stammdaten/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
