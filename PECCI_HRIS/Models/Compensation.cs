using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class Compensation
    {
        [Key] // In a 1-to-1 table, the Foreign Key acts as the Primary Key
        public string employeeID { get; set; }
        public decimal monthlyBasicSalary { get; set; }
    }
}