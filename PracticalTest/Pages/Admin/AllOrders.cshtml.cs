using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Admin
{
   
    public class AllOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AllOrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Orders> Orders { get; set; }

        public IActionResult OnGet()
        {
            // checking role for authorization
            var role = HttpContext.Session.GetString("Role");
            if (role != "Admin")
            {
                return RedirectToPage("/Account/Login");
            }
            //loding orders if admin
            Orders = _context.Orders.Include(o => o.User).Include(o => o.OrderDetails).ToList();
            return Page();
        }
    }
}
