namespace MovieMangementAPI.DTO
{
    public class AvailableSeatdto
    {
        public int SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public string HallName { get; set; }
        public string CinemaName { get; set; }
        public string MovieName { get; set; }
        public DateTime ShowtimeStart { get; set; }
    }
}
