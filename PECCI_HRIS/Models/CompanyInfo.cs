using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class CompanyInfo
    {
        [Key]
        public int companyInfoID { get; set; }
        public string employeeID { get; set; }
        public string employeeCompany { get; set; }
        public string costCenter { get; set; }
        public DateTime dateHired { get; set; }
        public DateTime? dateResignedCompany { get; set; } // Nullable because they might not have resigned
        public string officeNo { get; set; }
        public string officeTelNo { get; set; }
        public string previousCompany { get; set; }
        public string officeEmailAddress { get; set; }
        public string principalIdNo { get; set; }
        public DateTime? dateResignedPECCI { get; set; } // Nullable
        public string status { get; set; }
    }
}