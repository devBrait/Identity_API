using Microsoft.AspNetCore.Identity;

namespace Identity_API.Models
{
    public class User : IdentityUser
    {
        public string Document { get; set; } = string.Empty;
    }
}
