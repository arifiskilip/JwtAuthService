using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string City { get; set; }
    }
}
