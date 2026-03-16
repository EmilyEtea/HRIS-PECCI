using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class PayrollRecord
    {
        [Key]
        public int payrollID { get; set; }
        public string employeeID { get; set; }
        public DateTime cutoffStartDate { get; set; }
        public DateTime cutoffEndDate { get; set; }
        public decimal basicPayAmt { get; set; }
        public decimal overtimePayAmt { get; set; }
        public decimal premiumPayAmt { get; set; }
        public decimal paidLeaveAmt { get; set; }
        public decimal absenceDeductionAmt { get; set; }
        public decimal tardinessDeductionAmt { get; set; }
        public decimal undertimeDeductionAmt { get; set; }
        public decimal allowanceAmt { get; set; }
        public decimal adjustmentAmt { get; set; }
        public decimal grossPay { get; set; }
    }
}