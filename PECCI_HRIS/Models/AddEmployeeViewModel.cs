namespace PECCI_HRIS.Models
{
    public class AddEmployeeViewModel
    {
        // tbl_user_account
        public string EmployeeID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmploymentStatus { get; set; }
        public int RoleId { get; set; }

        // tbl_employee_info
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string CivilStatus { get; set; }
        public string NameOfSpouse { get; set; }
        public string AreaCode { get; set; }
        public string HomeTelNo { get; set; }
        public string CellNo { get; set; }
        public string TinNo { get; set; }
        public string SssNo { get; set; }
        public string BankName { get; set; }
        public string AtmNo { get; set; }

        // tbl_employee_residential_address
        public string ResidentialAddress { get; set; }
        public string Region { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string ZipCode { get; set; }
        public string VillageSubdivisionCondoName { get; set; }
        public string LotUnitNo { get; set; }
        public string BlockNo { get; set; }
    }
}