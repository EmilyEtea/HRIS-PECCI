using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PECCI_HRIS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            // NEW LOGIC: If the user is already logged in, bounce them back to the Dashboard
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            // Otherwise, show the normal login screen
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
                    // Assign Role: If username contains 'admin', they get the Admin role.
                    string userRole = user.userName.ToLower().Contains("admin") ? "Admin" : "Employee";

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.userName),
                        new Claim(ClaimTypes.Role, userRole),
                        new Claim("EmployeeID", user.employeeID)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // Signs the user in and establishes their role
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    // Redirects to Dashboard on success
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
    }
}