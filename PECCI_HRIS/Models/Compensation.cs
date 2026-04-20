using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PECCI_HRIS.Models
{
    public class Compensation
    {
        [Key]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal monthlyBasicSalary { get; set; }
    }
}