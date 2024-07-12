using Identity_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_API.Data
{
    public class AppDbContext(DbContextOptions options) 
        : IdentityDbContext<User>(options);
}
