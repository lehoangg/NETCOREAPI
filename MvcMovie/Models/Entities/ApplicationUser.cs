using Microsoft.AspNetCore.Identity;
namespace MvcMovie.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? FullName { get; set; }
    }
}