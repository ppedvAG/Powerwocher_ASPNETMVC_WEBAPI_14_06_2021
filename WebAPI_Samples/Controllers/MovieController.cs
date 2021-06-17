using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Samples.Data;
using WebAPI_SharedLibrary.Entities;

namespace WebAPI_Samples.Controllers
{
    //Route zu Controller kann per Default -> localhost:12345/api/Movie sein -> [Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController] //Sagt áus, dass der Movie - Controller sich um einen WEBAPI - Controller handelt
    public class MovieController : ControllerBase
    {
        private readonly MovieDbContext _context;

        //DI Injektion Unterstützung, wie bei MVC 
        public MovieController(MovieDbContext context)
        {
            _context = context;
        }


        #region Get-Methoden
        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]

        //Angabe, welche Status Codes zurück geliefert haben.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status303SeeOther)]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound(); //404 Fehler
            }

            return Ok(movie); //200 OK 
        }
        #endregion

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
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

        
        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        //[HttpPost]
        //[HttpPut]
        //public IActionResult CreateOrUpdate(Movie movie)
        //{
        //    if (movie.Id != 0)
        //    {
        //        //Update
        //    }
        //    else
        //    {
        //        //Create
        //    }
        //    return Ok();
        //}

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
