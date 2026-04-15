using System.Collections.Generic;

namespace PECCI_HRIS.Models
{
    public class DashboardViewModel
    {
        // Your existing data
        public UserAccount User { get; set; } = null!;
        public bool IsOnLeave { get; set; }

        // Summary Cards 
        public int TotalEmployees { get; set; }
        public int ActiveEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int RecentHiresCount { get; set; }

        // --- NEW: List for the "Recent Employees" Table ---
        public List<EmployeeListViewModel> RecentEmployees { get; set; } = new List<EmployeeListViewModel>();
    }

    // Helper class to represent a row in your table mockup
    public class EmployeeListViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Status { get; set; } = "Active"; // Active, On Leave, Inactive
        public string? ProfilePictureUrl { get; set; } // For the circular avatars in mockup
    }
}