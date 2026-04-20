using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class EmployeeInfo
    {
        [Key]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string lastName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string firstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string middleName { get; set; } = null!;

        [StringLength(10)]
        public string? suffix { get; set; } // Nullable in SQL

        [Required]
        [StringLength(1)]
        public string sex { get; set; } = null!;

        [Required]
        public DateTime dateOfBirth { get; set; } // NOT NULL in SQL

        [StringLength(100)]
        public string? placeOfBirth { get; set; } // Nullable in SQL

        [Required]
        [StringLength(10)]
        public string civilStatus { get; set; } = null!;

        [StringLength(100)]
        public string? nameOfSpouse { get; set; } // Nullable in SQL

        [StringLength(5)]
        public string? areaCode { get; set; } // Nullable in SQL

        [StringLength(20)]
        public string? homeTelNo { get; set; } // Nullable in SQL

        [StringLength(20)]
        public string? cellNo { get; set; } // Nullable in SQL

        [Required]
        [StringLength(20)]
        public string tinNo { get; set; } = null!; // NOT NULL in SQL

        [StringLength(20)]
        public string? sssNo { get; set; } // Nullable in SQL

        [StringLength(10)]
        public string? bankName { get; set; } // Nullable in SQL

        [StringLength(50)]
        public string? atmNo { get; set; } // Nullable in SQL

        public byte[]? employeeimage { get; set; } // Nullable varbinary(MAX)

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string personalEmail { get; set; } = null!; // NOT NULL in SQL
    }
}