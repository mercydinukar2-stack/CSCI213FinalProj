using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudSpa.Models
{
    public class Review
    {
        public int Id { get; set; }

        // ⭐ Rating 1–5
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        // Optional comment
        [StringLength(500)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // -------------------------
        // CUSTOMER
        // -------------------------
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        // (optional navigation if you want it later)
        // public ApplicationUser Customer { get; set; }

        // -------------------------
        // SERVICE
        // -------------------------
        [Required]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = null!;

        // -------------------------
        // APPOINTMENT
        // -------------------------
        [Required]
        public int AppointmentId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } = null!;
    }
}


