using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;
using MovieMangementAPI.Model;

namespace MovieMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HallController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetHallByShowtime(int showtimeId)
        {
            var hall = await _context.ShowTimes
                .Where(st => st.Id == showtimeId)
                .Select(st => new
                {
                    HallId = st.Hall.Id,
                    HallName = st.Hall.Name
                })
                .FirstOrDefaultAsync();

            if (hall == null)
                return NotFound("Hall not found for this showtime.");

            return Ok(hall);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll()
        {
            var Halls = await _context.Halls.ToListAsync();
            return Ok(Halls);
        }

        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Hall = _context.Halls.Find(id);
            if (Hall == null)
                return NotFound("Hall Not Found");
            return Ok(Hall);
        }
       

        // POST api/<CinemaController>
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(Halldto hall)
        {
            if (ModelState.IsValid)
            {
                Hall hall1 = new()
                {
                    Name = hall.Name,
                    Capacity = hall.Capacity,
                    CinemaId = hall.CinemaId
                };
                _context.Halls.AddAsync(hall1);
                await _context.SaveChangesAsync();
                return Ok("Hall is Created Succefully");
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHall(int id, [FromBody] Halldto hall)
        {

            var existinghall = await _context.Halls.FindAsync(id);
            if (existinghall == null)
                return NotFound("hall not found.");

            existinghall.Name = hall.Name;
            existinghall.Capacity = hall.Capacity;
            existinghall.CinemaId = hall.CinemaId;


            _context.Halls.Update(existinghall);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHall(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
                return NotFound("Hall not found.");

            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
