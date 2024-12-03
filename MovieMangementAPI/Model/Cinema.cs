using System;

namespace MovieMangementAPI.Model
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //public ICollection<Movie> Movies { get; set; } 
        //public ICollection<Hall> Halls { get; set; } 
    }
}
