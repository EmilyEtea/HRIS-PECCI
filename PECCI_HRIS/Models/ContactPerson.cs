using System;
using System.ComponentModel.DataAnnotations;

namespace PECCI_HRIS.Models
{
    public class ContactPerson
    {
        [Key]
        public int contactPersonID { get; set; }
        public string employeeID { get; set; }
        public string fullName { get; set; }
        public string relationship { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string contactPersonCellNo { get; set; }
    }
}