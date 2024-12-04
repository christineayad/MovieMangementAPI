namespace MovieMangementAPI.DTO
{
    public class Reservationdto
    {
        public int SeatId { get; set; }        // رقم تعريف المقعد
        public int ShowtimeId { get; set; }   // رقم تعريف العرض (Showtime)
        public int HallId { get; set; }       // رقم تعريف القاعة
        public int CinemaId { get; set; }
    }
}
