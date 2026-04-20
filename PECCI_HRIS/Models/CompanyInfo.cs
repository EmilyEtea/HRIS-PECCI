using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class CompanyInfo
    {
        [Key]
        public int companyInfoID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string employeeCompany { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string costCenter { get; set; } = null!;

        [Required]
        public DateTime dateHired { get; set; }

        [Required]
        public DateTime dateResignedCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string officeNo { get; set; } = null!;

        [StringLength(20)]
        public string? officeTelNo { get; set; } // Nullable in SQL

        [Required]
        [StringLength(100)]
        public string previousCompany { get; set; } = null!;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string officeEmailAddress { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string principalIDNo { get; set; } = null!;

        public DateTime? dateResignedPECCI { get; set; } // Nullable in SQL

        [Required]
        [StringLength(50)]
        public string status { get; set; } = null!;
    }
}