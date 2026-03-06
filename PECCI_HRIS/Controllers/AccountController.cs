using Microsoft.AspNetCore.Mvc;
using PECCI_HRIS.Data;
using PECCI_HRIS.Models;
using System.Linq;

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
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // We check the database for the user you just added via SQL
                var user = _context.UserAccounts
                    .FirstOrDefault(u => u.userName == model.UserName && u.userPassword == model.Password);

                if (user != null)
                {
                    // For now, we redirect to Home if successful
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}