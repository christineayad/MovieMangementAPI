using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieMangementAPI.DTO;

using MovieMangementAPI.Model;

namespace MovieMangementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("Researve Seat")]
        public async Task<IActionResult> ReserveSeat([FromBody] Reservationdto reserve)
        {
            try
            {
                var seat = await _context.Seats.Include(x=>x.Showtime).Include(x=>x.Hall)
                    .FirstOrDefaultAsync(s => s.Id == reserve.SeatId && s.ShowtimeId == reserve.ShowtimeId && s.HallId == reserve.HallId);

                if (seat == null)
                    return NotFound("Seat not found for the specified Showtime and Hall.");

                if (seat.IsReserved)
                    return BadRequest("Seat is already reserved.");

                seat.IsReserved = true;
                _context.Seats.Update(seat);
                await _context.SaveChangesAsync();
                Reservation reservation = new Reservation
                {


                    ShowTimeId = seat.ShowtimeId,
                    SeatId = seat.Id,
                    ResearvedAt = DateTime.Now,
                    TotalPrice=seat.Showtime.TicketPrice,
                    
                   // userId= 67de9e1d-34fa-47e1-92fb-1df1d8e780d5
                };
                _context.Reservations.Add(reservation);
                _context.SaveChanges();


                return Ok(new { Message = "Seat reserved successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

          

            
        }
        [HttpPost("CancelReservation")]
        public async Task<IActionResult> CancelReservation(int reserveId)
        {
            var reserveDB = _context.Reservations.Include(u => u.ShowTime).FirstOrDefault(x => x.Id == reserveId );
            if (reserveDB == null)
            {
                return NotFound("Reservation not found");
            }
            if (reserveDB.ShowTime.StartTime <= DateTime.Now)
            {
                return NotFound("Cannot cancel past reservations");
            }
            reserveDB.Seat.IsReserved = false;
            _context.Remove(reserveDB);
            _context.SaveChanges();
            return Ok("Reservation Canceled");

        }

        [HttpGet("GetAllReservation")]
        public async Task<IActionResult> GetAllReservation()
        {
            //Include(u => u.ApplicationUser)
            var reservations = await _context.Reservations.ToListAsync();//Include(u => u.ShowTime.Movie).Include(u => u.Seat).Where(u => u.Seat.IsReserved).ToListAsync();
            // var reservespecificUser = context.Reservations.Include(r => r.ShowTime).Include(r => r.Seat).OrderBy(r => r.ShowTime.ShowDate).ToList();
            return Ok(reservations);

        }

    }
}
