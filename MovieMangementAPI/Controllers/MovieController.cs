using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;
using MovieMangementAPI.Model;

namespace MovieMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CinemaController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Movies = await _context.Movies.ToListAsync();
            return Ok(Movies);
        }

        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Movie = _context.Movies.Find(id);
            if (Movie == null)
                return NotFound("Movie Not Found");
            return Ok(Movie);
        }
        //[HttpGet("movies")]
        //public async Task<IActionResult> GetMoviesByCinema(int cinemaId)
        //{
        //    var movies = await _context.ShowTimes
        //        .Where(st => st.CinemaID == cinemaId)
        //        .Select(st => st.Movie)
        //        .Distinct()
        //        .Select(m => new { m.Id, m.Name })
        //        .ToListAsync();
        //    return Ok(movies);
        //}

        // POST api/<CinemaController>
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(Moviedto movie)
        {
            if (ModelState.IsValid)
            {
                Movie movie1 = new()
                {
                    Name = movie.Name,
                    Genre=movie.Genre,
                    Description = movie.Description
                };
                _context.Movies.AddAsync(movie1);
                await _context.SaveChangesAsync();
                return Ok("Movie is Created Succefully");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Moviedto movie)
        {

            var existingMovie = await _context.Movies.FindAsync(id);
            if (existingMovie == null)
                return NotFound("Movie not found.");

            existingMovie.Name = movie.Name;
            existingMovie.Genre = movie.Genre;
            existingMovie.Description = movie.Description;


            _context.Movies.Update(existingMovie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return NotFound("movie not found.");

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

