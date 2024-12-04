using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
