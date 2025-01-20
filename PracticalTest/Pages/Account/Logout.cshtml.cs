using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PracticalTest.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            //adding logout clearing session state data
            HttpContext.Session.Clear(); 
            return RedirectToPage("/Account/Login");
        }
    }
}
