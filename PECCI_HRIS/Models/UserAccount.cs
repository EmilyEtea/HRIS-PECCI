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

        // MATCHING SQL CASING: lowercase first letters
        public int roleId { get; set; }
        public bool isActive { get; set; }
        public int failedLoginAttempts { get; set; }
        public DateTime? passwordChangeDate { get; set; }
        public DateTime? lastLoginDate { get; set; }
        public DateTime createdDate { get; set; }
    }
}