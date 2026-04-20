using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class UserAccount
    {
        [Key]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string employmentStatus { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string employeeDepartment { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string userName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string userPassword { get; set; } = null!;

        [Required]
        public int roleId { get; set; }

        [Required]
        public bool isActive { get; set; } // Matches 'bit' in SQL

        [Required]
        public int failedLoginAttempts { get; set; }

        // Nullable because 'Allow Nulls' is checked in SSMS
        public DateTime? passwordChangeDate { get; set; }

        public DateTime? lastLoginDate { get; set; }

        [Required]
        public DateTime createdDate { get; set; }
    }
}