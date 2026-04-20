using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class Attendance
    {
        [Key]
        public int attendanceID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        public DateTime attendanceDate { get; set; }

        [Required]
        public TimeSpan timeIn { get; set; }

        [Required]
        public TimeSpan timeOut { get; set; } 

        // These remain nullable (?) because "Allow Nulls" is checked in SSMS
        public short? tardinessMins { get; set; }

        public short? undertimeMins { get; set; }
    }
}