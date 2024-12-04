namespace MovieMangementAPI.Model
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Horror,
        Romance,
        SciFi, 
        Thriller,
        Documentary,
        Animation,
        Fantasy
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        //public ICollection<ShowTime> ShowTime { get; set; }

    }
}
