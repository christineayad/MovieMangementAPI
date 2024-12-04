using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;

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
        public async Task<IActionResult> GetAll()
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
        
    }
}
