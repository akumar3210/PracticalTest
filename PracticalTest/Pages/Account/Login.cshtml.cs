using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public User LoginUser { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            // checking if email or password is empty
            if (string.IsNullOrWhiteSpace(LoginUser.Email) || string.IsNullOrWhiteSpace(LoginUser.Email))
            {
                ModelState.AddModelError("", "Both email and password are required.");
                return Page();
            }
            // checking email & password matching with our existing users
            var user = _context.Users.FirstOrDefault(u => u.Email == LoginUser.Email && u.Password == LoginUser.Password);

            if (user == null)
            {
                // if user does not exist
                ModelState.AddModelError("", "Invalid email or password!");
                return Page();
            }
            // setting session state  vairable for user 
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("Role", user.Role);

            //redirecting based on roles
            if (user.Role == "Admin")
            {
                return RedirectToPage("/Admin/AllOrders");
            }
            else if (user.Role == "Customer")
            {
                return RedirectToPage("/Customer/MyOrders");
            }

            return RedirectToPage("/Account/Login");
        }
    }
}
