namespace MovieMangementAPI.Model
{
    public class Seat
    {
        public int Id { get; set; } 
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public int ShowtimeId { get; set; }
        public ShowTime? Showtime { get; set; }

        public int HallId { get; set; }
        public Hall? Hall { get; set; }
    }
}
