using StudSpa.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudSpa.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        // CUSTOMER
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        // SERVICE
        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        // 🔹 EMPLOYEE (SERVICE PROVIDER)
        public string? EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public ApplicationUser? Employee { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}




