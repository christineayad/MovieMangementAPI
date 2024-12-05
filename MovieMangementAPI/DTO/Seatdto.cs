using MovieMangementAPI.Model;

namespace MovieMangementAPI.DTO
{
    public class Seatdto
    {
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public int ShowtimeId { get; set; }
        public int HallId { get; set; }
        
    }
}
