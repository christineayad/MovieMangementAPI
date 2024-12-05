using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;
//using MovieMangementAPI.Migrations;
using MovieMangementAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CinemaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CinemaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CinemaController>
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll()
        {
            var Cinemas = await _context.Cinemas.ToListAsync();
            return Ok(Cinemas);
        }

        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if(cinema==null)
            return NotFound("Cinema Not Found");  
            return Ok(cinema);
        }

        // POST api/<CinemaController>
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(Cinemadto cinema)
        {
            if(ModelState.IsValid)
            {
                Cinema cinema1 = new()
                {
                    Name=cinema.Name,
                    Location=cinema.Location,
                };
                _context.Cinemas.AddAsync(cinema1);
                await _context.SaveChangesAsync();
                return Ok("Cinema is Created Succefully");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCinema(int id, [FromBody] Cinemadto cinema)
        {
         
            var existingcinema = await _context.Cinemas.FindAsync(id);
            if (existingcinema == null)
                return NotFound("Cinema not found.");

            existingcinema.Name = cinema.Name;
            existingcinema.Location = cinema.Location;
            

            _context.Cinemas.Update(existingcinema);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null)
                return NotFound("cinema not found.");

            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
