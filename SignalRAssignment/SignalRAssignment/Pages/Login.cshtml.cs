using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        public LoginModel(ApplicationDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _context.Accounts.SingleOrDefaultAsync(u => u.UserName == Username);

            if (user != null && user.Password == Password)
            {
                if (user.Type == 1)
                {
                    return RedirectToPage("/ProductList");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Do you not premission!");
                    ViewData["ErrorMessage"] = "Do you not premission!";
                    return Page();
                    
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                ViewData["ErrorMessage"] = "Invalid username or password";
                return Page();
            }
        }
    }
}
