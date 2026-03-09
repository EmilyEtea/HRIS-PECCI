using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class LeaveRequest
    {
        [Key]
        public int leaveRequestID { get; set; } // INT AUTO-INCREMENT

        [Required]
        public string employeeID { get; set; } = null!; // VARCHAR(10)

        public string leaveType { get; set; } = null!; // VARCHAR(50)

        public DateTime startDate { get; set; } // DATE

        public DateTime endDate { get; set; } // DATE

        public string? supervisorSignature { get; set; } // VARCHAR(100) (URL)

        public string supervisorStatus { get; set; } = "Pending"; // VARCHAR(15)

        public string? gmSignature { get; set; } // VARCHAR(100) (URL)

        public string gmStatus { get; set; } = "Pending"; // VARCHAR(15)

        public DateTime? dateFiled { get; set; } = DateTime.Now; // DATETIME

        // Logic: Calculate total days automatically based on start and end date
        public int TotalDays => (endDate - startDate).Days + 1;
    }
}