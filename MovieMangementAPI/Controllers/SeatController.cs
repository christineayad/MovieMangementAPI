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
    public class SeatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SeatController(ApplicationDbContext context)
        {
                _context= context;
        }
        [HttpGet("AvailableSeat")]
        public async Task<IActionResult> GetAvailableSeat()
        {
            var availableSeats = _context.Seats.Include(s => s.Showtime)
                .ThenInclude(st => st.Movie)
            .Include(s => s.Showtime)
                
            .Include(s => s.Hall)
                .ThenInclude(h => h.Cinema)
            .Where(s => !s.IsReserved).Select(s=>new AvailableSeatdto
            {
                SeatNumber = s.SeatNumber,
                IsReserved = s.IsReserved,
                HallName = s.Hall.Name,
                CinemaName = s.Hall.Cinema.Name,
                MovieName = s.Showtime.Movie.Name,
                ShowtimeStart = s.Showtime.StartTime
            }).ToList();
            return Ok(availableSeats);
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll()
        {
            var Seats = await _context.Seats.ToListAsync();
            return Ok(Seats);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Seat = _context.Seats.Find(id);
            if (Seat == null)
                return NotFound("Seat Not Found");
            return Ok(Seat);
        }

      
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create(Seatdto seat)
        {
            if (ModelState.IsValid)
            {
                Seat seat1 = new()
                {
                   SeatNumber=seat.SeatNumber,
                   IsReserved=seat.IsReserved,
                   ShowtimeId=seat.ShowtimeId,
                   HallId=seat.HallId

                };
                _context.Seats.AddAsync(seat1);
                await _context.SaveChangesAsync();
                return Ok("Seat is Created Succefully");
            }
            return BadRequest(ModelState);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeat(int id, [FromBody] Seatdto seat)
        {

            var existingseat = await _context.Seats.FindAsync(id);
            if (existingseat == null)
                return NotFound("Seat not found.");

            existingseat.SeatNumber = seat.SeatNumber;
            existingseat.IsReserved = seat.IsReserved;
            existingseat.ShowtimeId = seat.ShowtimeId;
            existingseat.HallId = seat.HallId;


            _context.Seats.Update(existingseat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            var seat = await _context.Seats.FindAsync(id);
            if (seat == null)
                return NotFound("cinema not found.");

            _context.Seats.Remove(seat);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
