namespace MovieMangementAPI.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ResearvedAt { get; set; }
        public int userId { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }

        public int ShowTimeId { get; set; }
        public virtual ShowTime? ShowTime { get; set; }
        public int SeatId { get; set; }
        public virtual Seat? Seat { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
