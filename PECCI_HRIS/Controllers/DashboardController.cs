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

            var viewModel = new DashboardViewModel();

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

            if (User.IsInRole("Admin"))
            {
                // --- ADMIN VIEW LOGIC ---
                viewModel.TotalEmployees = _context.UserAccounts.Count();
                viewModel.ActiveEmployees = _context.UserAccounts.Count(u => u.isActive);
                viewModel.TotalDepartments = _context.UserAccounts
                    .Select(u => u.employeeDepartment).Distinct().Count();

                var thirtyDaysAgo = DateTime.Now.AddDays(-30);
                viewModel.RecentHiresCount = _context.UserAccounts
                    .Count(u => u.createdDate >= thirtyDaysAgo);

                viewModel.RecentEmployees = _context.UserAccounts
                    .OrderByDescending(u => u.createdDate)
                    .Take(5)
                    .Select(u => new EmployeeListViewModel
                    {
                        FullName = u.userName,
                        Department = u.employeeDepartment,
                        Status = _context.LeaveRequests.Any(l =>
                                    l.employeeID == u.employeeID &&
                                    today >= l.startDate &&
                                    today <= l.endDate)
                                 ? "On Leave" : "Active"
                    }).ToList();
            }
            else
            {
                // --- EMPLOYEE VIEW LOGIC (Sprint 1 Self-Service) ---

                // 1. Personal Stats (Mapping to your card properties)
                // In a real scenario, you'd pull from an Attendance table. 
                // For now, let's show their personal Leave Request count as a stat.
                viewModel.TotalEmployees = _context.LeaveRequests.Count(l => l.employeeID == currentUserId);
                // We can label this "My Requests" in the View

                viewModel.ActiveEmployees = _context.LeaveRequests.Count(l => l.employeeID == currentUserId && l.gmStatus == "Approved");
                // Label: "Approved Leaves"

                // 2. Personal History (Recent Requests instead of Recent Employees)
                viewModel.RecentEmployees = _context.LeaveRequests
                    .Where(l => l.employeeID == currentUserId)
                    .OrderByDescending(l => l.startDate)
                    .Take(5)
                    .Select(l => new EmployeeListViewModel
                    {
                        FullName = l.leaveType ?? "Leave Request",
                        Department = l.startDate.ToString("MM/dd/yyyy"), // Use Dept field to show Date
                        Status = l.gmStatus ?? "Pending"
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