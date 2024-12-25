using Microsoft.AspNetCore.Identity;

namespace Pathology.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string Name { get; set; }

    }
}
