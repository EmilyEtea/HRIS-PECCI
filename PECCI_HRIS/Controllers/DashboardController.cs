using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;
using System;
using System.Security.Claims; // Added to access User Claims

namespace PECCI_HRIS.Controllers
{
    [Authorize] // Ensures only logged-in users enter
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dashboard
        public IActionResult Index()
        {
            var today = DateTime.Today;

            // Get the unique ID of the logged-in user from their claims
            var currentUserId = User.FindFirstValue("EmployeeID");

            // Define the base query for user accounts
            var userQuery = _context.UserAccounts.AsQueryable();

            // RBAC Logic: Filter data if the user is not an Admin
            if (!User.IsInRole("Admin"))
            {
                userQuery = userQuery.Where(u => u.employeeID == currentUserId);
            }

            var viewModel = userQuery.Select(user => new DashboardViewModel
            {
                User = user,
                // Automated leave status logic
                IsOnLeave = _context.LeaveRequests.Any(l =>
                    l.employeeID == user.employeeID &&
                    l.supervisorStatus == "Approved" &&
                    l.gmStatus == "Approved" &&
                    today >= l.startDate && today <= l.endDate)
            }).ToList();

            return View(viewModel);
        }

        // Restricted to Admins only
        [Authorize(Roles = "Admin")]
        public IActionResult AdminApprovalQueue()
        {
            return View();
        }
    }
}