using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization; // Added for security
using System.Security.Claims;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace PECCI_HRIS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- EXISTING LOGIN/LOGOUT LOGIC ---

        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts
                    .FirstOrDefault(u => u.userName == model.UserName && u.userPassword == model.Password);

                if (user != null)
                {
                    if (!user.isActive)
                    {
                        ModelState.AddModelError("", "This account has been deactivated. Please contact HR.");
                        return View(model);
                    }

                    string userRole = (user.roleId == 1) ? "Admin" : "Employee";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(ClaimTypes.Role, userRole),
                        new Claim("EmployeeID", user.employeeID)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    user.lastLoginDate = DateTime.Now;
                    user.failedLoginAttempts = 0;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Dashboard");
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        // --- NEW SPRINT 1: USER MANAGEMENT (CRUD) ---

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UserManagement()
        {
            // This returns the "Add Employee" form view
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UserManagement(AddEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 1. Map to Account Table (tbl_user_account)
                var newAccount = new UserAccount // Ensure this matches your context entity name
                {
                    employeeID = model.EmployeeID,
                    userName = model.UserName,
                    userPassword = model.UserPassword, // Note: Hashing is a Sprint 1 goal to implement later
                    roleId = model.RoleId,
                    isActive = true,
                    createdDate = DateTime.Now,
                    employeeDepartment = model.EmployeeDepartment,
                    employmentStatus = model.EmploymentStatus
                };

                // 2. Map to Profile Table (tbl_employee_info)
                var newProfile = new EmployeeInfo // Ensure this matches your context entity name
                {
                    employeeID = model.EmployeeID,
                    firstName = model.FirstName,
                    lastName = model.LastName,
                    middleName = model.MiddleName,
                    sex = model.Sex,
                    dateOfBirth = model.DateOfBirth,
                    civilStatus = model.CivilStatus
                };

                try
                {
                    _context.Add(newAccount);
                    _context.Add(newProfile);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Employee successfully added!";
                    return RedirectToAction("Index", "Dashboard");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Database error: " + ex.Message);
                }
            }
            return View(model);
        }
    }
}