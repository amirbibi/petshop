using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class AuthenticationContext(DbContextOptions<AuthenticationContext> options) : IdentityDbContext<IdentityUser>(options)
    {
    }
}
