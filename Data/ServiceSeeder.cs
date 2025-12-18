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

                // MASSAGES
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
                    Name = "Hot Stone Massage",
                    DurationMinutes = 75,
                    Price = 110,
                    IsActive = true
                },
                new Service
                {
                    Name = "Aromatherapy Massage",
                    DurationMinutes = 60,
                    Price = 95,
                    IsActive = true
                },

                // FACIALS & SKIN
                new Service
                {
                    Name = "Facial Treatment",
                    DurationMinutes = 45,
                    Price = 65,
                    IsActive = true
                },
                new Service
                {
                    Name = "Deep Cleansing Facial",
                    DurationMinutes = 60,
                    Price = 85,
                    IsActive = true
                },
                new Service
                {
                    Name = "Anti-Aging Facial",
                    DurationMinutes = 75,
                    Price = 110,
                    IsActive = true
                },

                // BODY & WELLNESS
                new Service
                {
                    Name = "Body Scrub",
                    DurationMinutes = 45,
                    Price = 70,
                    IsActive = true
                },
                new Service
                {
                    Name = "Detox Body Wrap",
                    DurationMinutes = 90,
                    Price = 130,
                    IsActive = true
                },

                // RELAXATION / SPECIALTY
                new Service
                {
                    Name = "Reflexology",
                    DurationMinutes = 30,
                    Price = 50,
                    IsActive = true
                },
                new Service
                {
                    Name = "Couples Massage",
                    DurationMinutes = 60,
                    Price = 160,
                    IsActive = true
                }
            );

            await db.SaveChangesAsync();
        }
    }
}


