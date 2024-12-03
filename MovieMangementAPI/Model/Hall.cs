namespace MovieMangementAPI.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Capacity { get; set; } // عدد المقاعد
        public int CinemaId { get; set; } 
        public virtual Cinema? Cinema { get; set; } 
        public ICollection<ShowTime> ShowTimes { get; set; }
    }
}
