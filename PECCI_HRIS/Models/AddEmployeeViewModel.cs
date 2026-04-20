using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class AddEmployeeViewModel
    {
        // --- tbl_user_account ---
        [Required(ErrorMessage = "Employee ID is required")]
        [StringLength(10)]
        public string EmployeeID { get; set; } = null!;

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string UserPassword { get; set; } = null!;

        [Required]
        public string EmployeeDepartment { get; set; } = null!;

        [Required]
        public string EmploymentStatus { get; set; } = null!;

        [Required]
        public int RoleId { get; set; }

        // --- tbl_employee_info ---
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string MiddleName { get; set; } = null!;

        public string? Suffix { get; set; } // Matches nullable in DB

        [Required]
        public string Sex { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string? PlaceOfBirth { get; set; } // Matches nullable in DB

        [Required]
        public string CivilStatus { get; set; } = null!;

        public string? NameOfSpouse { get; set; } // Matches nullable in DB

        // NEW: Required because we moved it to tbl_employee_info
        [Required]
        [EmailAddress]
        public string PersonalEmail { get; set; } = null!;

        public string? AreaCode { get; set; }
        public string? HomeTelNo { get; set; }
        public string? CellNo { get; set; }

        [Required]
        public string TinNo { get; set; } = null!;

        public string? SssNo { get; set; }
        public string? BankName { get; set; }
        public string? AtmNo { get; set; }

        // --- tbl_employee_residential_address ---
        [Required]
        public string ResidentialAddress { get; set; } = null!;

        [Required]
        public string Region { get; set; } = null!;

        [Required]
        public string Province { get; set; } = null!;

        [Required]
        public string Municipality { get; set; } = null!;

        [Required]
        public string Barangay { get; set; } = null!;

        [Required]
        public string StreetNo { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string ZipCode { get; set; } = null!;

        public string? VillageSubdivisionCondoName { get; set; } // Matches nullable in DB
        public string? LotUnitNo { get; set; }
        public string? BlockNo { get; set; }
    }
}