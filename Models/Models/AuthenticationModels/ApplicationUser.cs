using Microsoft.AspNetCore.Identity;

namespace BookMyShow.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
