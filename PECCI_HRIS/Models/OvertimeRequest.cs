using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PECCI_HRIS.Models
{
    public class OvertimeRequest
    {
        [Key]
        public int overtimeRequestID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        public DateTime overtimeDate { get; set; }

        [StringLength(255)]
        public string? overtimeReason { get; set; } // Nullable in SQL

        [Required]
        public TimeSpan startTime { get; set; } // time(7)

        [Required]
        public TimeSpan endTime { get; set; } // time(7)

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal numOfHours { get; set; }

        [Required]
        [StringLength(100)]
        public string supervisorSignature { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string supervisorStatus { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string gmSignature { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string gmStatus { get; set; } = null!;

        [Required]
        public DateTime dateFiled { get; set; }
    }
}