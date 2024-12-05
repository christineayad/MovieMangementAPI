using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;
using MovieMangementAPI.Migrations;
using MovieMangementAPI.Model;

namespace MovieMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ShowTimeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("showtimes")]
        public async Task<IActionResult> GetShowtimes(int cinemaId, int movieId)
        {
            var showtimes = await _context.ShowTimes
                .Where(st => st.CinemaId == cinemaId && st.MovieId == movieId)
                .Select(st => new
                {
                    st.Id,
                    st.StartTime,
                    st.Movie.Name,

                 hallName = st.Hall.Name
                
                 
                })
                .ToListAsync();
            return Ok(showtimes);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var showtimes = await _context.ShowTimes.ToListAsync();
            return Ok(showtimes);
        }

        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var showtime = _context.ShowTimes.Find(id);
            if (showtime == null)
                return NotFound("showtime Not Found");
            return Ok(showtime);
        }


        // POST api/<CinemaController>
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(showtimedto showtime)
        {
            if (ModelState.IsValid)
            {
                ShowTime showtime1 = new()
                {
                    StartTime=showtime.StartTime,
                    MovieId=showtime.MovieId,
                    CinemaId=showtime.CinemaId,
                    HallId=showtime.HallId,
                    TicketPrice=showtime.TicketPrice
                };
                _context.ShowTimes.AddAsync(showtime1);
                await _context.SaveChangesAsync();
                return Ok("ShowTime is Created Succefully");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShowTime(int id, [FromBody] showtimedto showtime)
        {

            var existingshowtime = await _context.ShowTimes.FindAsync(id);
            if (existingshowtime == null)
                return NotFound("showtime not found.");

            existingshowtime.StartTime = showtime.StartTime;
            existingshowtime.MovieId = showtime.MovieId;
            existingshowtime.CinemaId = showtime.CinemaId;
            existingshowtime.HallId = showtime.HallId;
            existingshowtime.TicketPrice = showtime.TicketPrice;


            _context.ShowTimes.Update(existingshowtime);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShowTime(int id)
        {
            var showtime = await _context.ShowTimes.FindAsync(id);
            if (showtime == null)
                return NotFound("showtime not found.");

            _context.ShowTimes.Remove(showtime);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
