using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;
using System;

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

            var viewModel = _context.UserAccounts.Select(user => new DashboardViewModel
            {
                User = user,
                IsOnLeave = _context.LeaveRequests.Any(l =>
                    l.employeeID == user.employeeID &&
                    l.supervisorStatus == "Approved" &&
                    l.gmStatus == "Approved" &&
                    today >= l.startDate && today <= l.endDate)
            }).ToList();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminApprovalQueue()
        {
            return View();
        }
    }
}