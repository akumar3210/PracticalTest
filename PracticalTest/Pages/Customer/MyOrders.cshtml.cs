using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Customer
{
    public class MyOrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MyOrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Orders> Orders { get; set; }

        public void OnGet()
        {
            //
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            Orders = _context.Orders
                             .Where(o => o.UserId == userId)
                             .Include(o => o.User)
                             .ToList();
        }
    }
}
