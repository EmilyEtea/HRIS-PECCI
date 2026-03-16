using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class EmployeeInfo
    {
        [Key]
        public string employeeID { get; set; } = null!; // Fixed

        public string lastName { get; set; } = null!; // Fixed

        public string firstName { get; set; } = null!; // Fixed

        public string middleName { get; set; } = null!; // Fixed

        public string? suffix { get; set; } // Already handled by ?

        public string sex { get; set; } = null!; // Fixed

        public DateTime? dateOfBirth { get; set; } // Added ? to match SSMS

        public string? placeOfBirth { get; set; }

        public string civilStatus { get; set; } = null!; // Fixed

        public string? nameOfSpouse { get; set; }

        public string? areaCode { get; set; }

        public string personalEmail { get; set; }

        public string? homeTelNo { get; set; }

        public string? cellNo { get; set; }

        public string tinNo { get; set; } = null!; // Fixed

        public string? sssNo { get; set; }

        public string? bankName { get; set; }

        public string? atmNo { get; set; }

        public byte[]? employeeimage { get; set; }
    }
}