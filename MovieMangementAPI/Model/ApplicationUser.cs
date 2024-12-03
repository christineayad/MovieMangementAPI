using Microsoft.AspNetCore.Identity;

namespace MovieMangementAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }


        public bool Active { get; set; }
        public ApplicationUser()
        {


            Active = true;
        }
        public string Mobile { get; set; }
       // public ICollection<Reservation> Reservations { get; set; }
    }
}
