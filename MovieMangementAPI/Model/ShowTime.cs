namespace MovieMangementAPI.Model
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema? Cinema { get; set; }

        public int HallId { get; set; }
        public virtual Hall? Hall { get; set; }
        public decimal TicketPrice { get; set; }
        public ICollection<Seat> AvailableSeats { get; set; }
    }
}
