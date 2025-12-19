using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudSpa.Data
{
    public class StudSpaContext : IdentityDbContext<ApplicationUser>
    {
        public StudSpaContext(DbContextOptions<StudSpaContext> options)
            : base(options)
        {
        }
    }
}
