using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;
using System;
using System.Security.Claims;
using System.Collections.Generic;

namespace PECCI_HRIS.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var today = DateTime.Today;
            var currentUserId = User.FindFirstValue("EmployeeID");

            // 1. Initialize the ViewModel
            var viewModel = new DashboardViewModel();

            // 2. Fetch the Logged-in User Info
            var currentUserAccount = _context.UserAccounts
                .FirstOrDefault(u => u.employeeID == currentUserId);

            if (currentUserAccount != null)
            {
                viewModel.User = currentUserAccount;
                viewModel.IsOnLeave = _context.LeaveRequests.Any(l =>
                    l.employeeID == currentUserAccount.employeeID &&
                    l.supervisorStatus == "Approved" &&
                    l.gmStatus == "Approved" &&
                    today >= l.startDate && today <= l.endDate);
            }

            // 3. Sprint 1 Admin Stats - Only calculate these if the user is an Admin
            if (User.IsInRole("Admin"))
            {
                // Summary Card Queries using your actual Model property names
                viewModel.TotalEmployees = _context.UserAccounts.Count();

                // Fixed: isActive is a bool in your model, no need for '== 1'
                viewModel.ActiveEmployees = _context.UserAccounts.Count(u => u.isActive);

                // Fixed: using 'employeeDepartment' instead of 'department'
                viewModel.TotalDepartments = _context.UserAccounts
                    .Select(u => u.employeeDepartment)
                    .Distinct()
                    .Count();

                // Fixed: using 'createdDate' instead of 'dateCreated'
                var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                viewModel.RecentHiresCount = _context.UserAccounts
                    .Count(u => u.createdDate >= thirtyDaysAgo);

                // 4. Fetch Recent Employees for the Table
                viewModel.RecentEmployees = _context.UserAccounts
                    .OrderByDescending(u => u.createdDate)
                    .Take(5)
                    .Select(u => new EmployeeListViewModel
                    {
                        // Using userName as the display name for now per your model
                        FullName = u.userName,
                        Department = u.employeeDepartment,
                        Status = _context.LeaveRequests.Any(l =>
                                    l.employeeID == u.employeeID &&
                                    today >= l.startDate &&
                                    today <= l.endDate)
                                 ? "On Leave" : "Active"
                    }).ToList();
            }

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminApprovalQueue()
        {
            return View();
        }
    }
}