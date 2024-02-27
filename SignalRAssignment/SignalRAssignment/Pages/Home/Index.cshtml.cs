using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;


namespace SignalRAssignment.Pages.Home
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnGetAddItem(int? productId)
        {
            
                return RedirectToPage("/Cart/AddItem", new { productId = productId });
            
        }
    }
}
