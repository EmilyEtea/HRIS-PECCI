using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class BeneficiaryInfo
    {
        [Key]
        public int beneficiaryID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string fullName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string relationship { get; set; } = null!;

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [StringLength(20)]
        public string beneficiaryCellNo { get; set; } = null!;
    }
}