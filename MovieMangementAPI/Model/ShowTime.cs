namespace MovieMangementAPI.Model
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; } 
        public ICollection<Seat> AvailableSeats { get; set; }
    }
}
