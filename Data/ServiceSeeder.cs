using StudSpa.Models;
using Microsoft.EntityFrameworkCore;

namespace StudSpa.Data
{
    public static class ServiceSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext db)
        {
            // TEMP: clear table so seed always runs
            db.Services.RemoveRange(db.Services);
            await db.SaveChangesAsync();

            db.Services.AddRange(
                new Service
                {
                    Name = "Swedish Massage",
                    DurationMinutes = 60,
                    Price = 80,
                    IsActive = true
                },
                new Service
                {
                    Name = "Deep Tissue Massage",
                    DurationMinutes = 90,
                    Price = 120,
                    IsActive = true
                },
                new Service
                {
                    Name = "Facial Treatment",
                    DurationMinutes = 45,
                    Price = 65,
                    IsActive = true
                }
            );

            await db.SaveChangesAsync();
        }

    }
}

