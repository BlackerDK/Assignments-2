using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.ModelsDbF;
using Microsoft.AspNetCore.Http;

namespace SignalRAssignment.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UnitOfWork _context = new UnitOfWork();

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var user = _context.AccountRepository.Get(u => u.UserName == Username && u.Password == Password).FirstOrDefault();
                if (user != null)
                {
                    if (user.Type == 1)
                    {
                        HttpContext.Session.SetString("Username", user.UserName);
                        return RedirectToPage("/Product/Index");

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
            }catch (Exception ex)
            {
                return RedirectToPage("/Privacy");
            }
            
        }

    }
}
