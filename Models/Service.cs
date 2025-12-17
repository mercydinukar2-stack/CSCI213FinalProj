using System.ComponentModel.DataAnnotations;

namespace StudSpa.Models
{
    public class Service
    {
        public int Id { get; set; }   // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0, 1000)]
        public decimal Price { get; set; }

        // Duration in minutes (30, 60, 90)
        [Range(15, 240)]
        public int DurationMinutes { get; set; }

        // Allows admin to disable a service without deleting it
        public bool IsActive { get; set; } = true;
    }
}


