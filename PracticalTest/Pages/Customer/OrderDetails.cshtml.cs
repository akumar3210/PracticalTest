using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Customer
{
    public class OrderDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderDetails> OrderDetails { get; set; }

        public void OnGet(int id)
        {
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id && o.UserId == userId);

            if (order == null)
            {
                RedirectToPage("");
                return;
            }

            OrderDetails = _context.OrderDetails
                                   .Where(od => od.OrderId == id)
                                   .ToList();
        }
    }
}
