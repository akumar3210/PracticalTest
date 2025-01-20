using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PracticalTest.Data;
using PracticalTest.Model;
using System;

namespace PracticalTest.Pages.Customer
{
    [BindProperties]
    public class PlaceOrderModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PlaceOrderModel(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public OrderDetails OrderDetail { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            //get the user id
            var userId = int.Parse(HttpContext.Session.GetString("UserId"));
            // new order 
            var order = new Orders
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                OrderBy = _context.Users.First(u => u.UserId == userId).FirstName,
                OrderDetails = new List<OrderDetails>()
            };
          // new orderdetails
            var newOrderDetail = new OrderDetails
            {
                ItemName = OrderDetail.ItemName,
                Qty = OrderDetail.Qty,
                ItemAmount = OrderDetail.ItemAmount,
                DiscountAmount = OrderDetail.DiscountAmount,
                FinalAmount = (OrderDetail.Qty * OrderDetail.ItemAmount) - OrderDetail.DiscountAmount,
                CreatedOn = DateTime.Now
            };

            // Adding the detail to the order's details list
            order.OrderDetails.Add(newOrderDetail);

            // OrderTotal
            order.OrderTotal = order.OrderDetails.Sum(d => d.FinalAmount);

            // save to the database
            _context.Orders.Add(order);
            _context.SaveChanges();


            return RedirectToPage("/Customer/MyOrders");
        }
    }
}
