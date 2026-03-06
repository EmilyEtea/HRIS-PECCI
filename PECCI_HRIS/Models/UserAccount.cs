using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class UserAccount
    {
        [Key]
        public string employeeID { get; set; } = null!; // varchar(10) - Required

        public string employmentStatus { get; set; } = null!; // varchar(50) - Required

        public string employeeDepartment { get; set; } = null!; // varchar(50) - Required

        public string userName { get; set; } = null!; // varchar(50) - Required

        public string userEmail { get; set; } = null!; // varchar(100) - Required

        public string userPassword { get; set; } = null!; // varchar(50) - Required
    }
}