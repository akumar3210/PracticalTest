using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public User User { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            // checking if user already exists
            if (_context.Users.Any(u => u.Email == User.Email))
            {
                ModelState.AddModelError("User.Email", "Email already exists!");
                return Page();
            }
            // Creating and inserting user data in database
            User.CreatedOn = DateTime.Now;
            _context.Users.Add(User);
            _context.SaveChanges();

            return RedirectToPage("/Account/Login");
        }
    }
}
