using Microsoft.AspNetCore.Identity;

namespace MovieStoreMVC.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
