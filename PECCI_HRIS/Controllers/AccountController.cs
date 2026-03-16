using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                // 1. Fetch the user based on credentials
                var user = _context.UserAccounts
                    .FirstOrDefault(u => u.userName == model.UserName && u.userPassword == model.Password);

                if (user != null)
                {
                    // 2. Security Check: Is the account active?
                    if (!user.isActive)
                    {
                        ModelState.AddModelError("", "This account has been deactivated. Please contact HR.");
                        return View(model);
                    }

                    // 3. Assign Role based on the new roleId column
                    // Rule: 1 = Admin, Anything else = Employee
                    string userRole = (user.roleId == 1) ? "Admin" : "Employee";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(ClaimTypes.Role, userRole),
                        new Claim("EmployeeID", user.employeeID)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // 4. Update Audit Data: Log the login time
                    user.lastLoginDate = DateTime.Now;
                    user.failedLoginAttempts = 0; // Reset attempts on success
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Dashboard");
                }

                // Optional: Increment failedLoginAttempts here if you want to implement lockouts later!
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}