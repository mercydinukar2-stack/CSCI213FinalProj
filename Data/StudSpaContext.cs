using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudSpa.Data;

namespace StudSpa.Data
{
    public class StudSpaContext(DbContextOptions<StudSpaContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
    }
}
