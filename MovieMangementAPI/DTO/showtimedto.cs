using MovieMangementAPI.Model;

namespace MovieMangementAPI.DTO
{
    public class showtimedto
    {
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        
        public int CinemaId { get; set; }
     
        public int HallId { get; set; }

        public decimal TicketPrice { get; set; }
    }
}
