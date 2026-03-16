using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class BeneficiaryInfo
    {
        [Key]
        public int beneficiaryID { get; set; }
        public string employeeID { get; set; }
        public string fullName { get; set; }
        public string relationship { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string beneficiaryCellNo { get; set; }
    }
}