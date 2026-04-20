using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PECCI_HRIS.Models
{
    public class PayrollRecord
    {
        [Key]
        public int payrollID { get; set; }

        [Required]
        [StringLength(10)]
        public string employeeID { get; set; } = null!;

        // Nullable in SQL (Allow Nulls checked)
        public DateTime? cutoffStartDate { get; set; }
        public DateTime? cutoffEndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal basicPayAmt { get; set; }

        // All these are Nullable in SQL (Allow Nulls checked)
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? overtimePayAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? premiumPayAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? paidLeaveAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? absenceDeductionAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? tardinessDeductionAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? undertimeDeductionAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? allowanceAmt { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? adjustmentAmt { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal grossPay { get; set; }
    }
}