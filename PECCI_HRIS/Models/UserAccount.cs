using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class UserAccount
    {
        [Key]
        public string employeeID { get; set; }

        public string employmentStatus { get; set; }
        public string employeeDepartment { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        // NEW: Requested Columns
        public int RoleId { get; set; }
        public bool IsActive { get; set; } // Bit in SQL becomes bool in C#
        public int FailedLoginAttempts { get; set; }
        public DateTime? PasswordChangeDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}