using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("halls")]
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

    }
}
