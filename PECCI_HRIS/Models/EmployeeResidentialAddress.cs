using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class EmployeeResidentialAddress
    {
        [Key] // 1-to-1 relationship, employeeID is the Primary Key
        public string employeeID { get; set; }
        public string residentialAddress { get; set; }
        public string region { get; set; }
        public string province { get; set; }
        public string municipality { get; set; }
        public string barangay { get; set; }
        public string streetNo { get; set; }
        public string streetName { get; set; }
        public string zipCode { get; set; }
        public string villageSubdivisionCondoName { get; set; }
        public string lotUnitNo { get; set; }
        public string blockNo { get; set; }
    }
}