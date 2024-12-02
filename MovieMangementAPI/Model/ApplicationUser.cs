using Microsoft.AspNetCore.Identity;

namespace MovieMangementAPI.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string? FullName { get; set; }


        public bool Active { get; set; }
        public ApplicationUser()
        {


            Active = false;
        }
        public string Mobile { get; set; }
    }
}
