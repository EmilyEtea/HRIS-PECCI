using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PECCI_HRIS.Controllers
{
    [Authorize] // Requires users to be logged in
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. READ: The page where leaves are listed (Admins see all, Employees see their own)
        public IActionResult Index()
        {
            var isUserAdmin = User.IsInRole("Admin");
            var currentUserId = User.FindFirstValue("EmployeeID");

            // Backend Logic: Determine what data to fetch based on role
            var leaves = isUserAdmin
                ? _context.LeaveRequests.OrderByDescending(l => l.dateFiled).ToList()
                : _context.LeaveRequests.Where(l => l.employeeID == currentUserId).OrderByDescending(l => l.dateFiled).ToList();

            return View(leaves);
        }

        // 2. GET: Serves the empty form to the user
        public IActionResult Apply()
        {
            return View();
        }

        // 3. POST: Handles the data when the user clicks "Submit"
        [HttpPost]
        public async Task<IActionResult> Apply(LeaveRequest model)
        {
            // Automatically grab the ID of the person logged in
            var employeeId = User.FindFirstValue("EmployeeID");

            if (employeeId != null)
            {
                // Set the default backend values before saving to the database
                model.employeeID = employeeId;
                model.dateFiled = DateTime.Now;
                model.supervisorStatus = "Pending";
                model.gmStatus = "Pending";

                _context.LeaveRequests.Add(model);
                await _context.SaveChangesAsync();

                // Send them back to the list so they can see their new "Pending" request
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}