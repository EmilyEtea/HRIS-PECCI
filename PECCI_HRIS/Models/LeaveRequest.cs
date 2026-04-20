using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class LeaveRequest
    {
        [Key]
        public int leaveRequestID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string leaveType { get; set; } = null!;

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }

        // Nullable because these are filled during the approval process
        [StringLength(100)]
        public string? supervisorSignature { get; set; }

        [StringLength(15)]
        public string? supervisorStatus { get; set; }

        [StringLength(100)]
        public string? gmSignature { get; set; }

        [StringLength(15)]
        public string? gmStatus { get; set; }

        public DateTime? dateFiled { get; set; }
    }
}