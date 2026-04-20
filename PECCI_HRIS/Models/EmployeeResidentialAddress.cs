using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class EmployeeResidentialAddress
    {
        [Key] // 1-to-1 relationship, employeeID is the Primary Key
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string residentialAddress { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string region { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string province { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string municipality { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string barangay { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string streetNo { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string streetName { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string zipCode { get; set; } = null!;

        // Fields that are nullable
        [StringLength(100)]
        public string? villageSubdivisionCondoName { get; set; }

        [StringLength(10)]
        public string? lotUnitNo { get; set; }

        [StringLength(10)]
        public string? blockNo { get; set; }
    }
}