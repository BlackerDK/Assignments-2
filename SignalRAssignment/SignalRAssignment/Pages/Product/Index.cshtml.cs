using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.ModelsDbF;


namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _context = new UnitOfWork();

        public IEnumerable<Repository.ModelsDbF.Product> Products { get; set; }
        public IEnumerable<Repository.ModelsDbF.Category> Catelogies { get; set; }

    public IActionResult OnGet()
        {
            var username = HttpContext.Session.GetString("UserName");
            if (username != null)
            {
            Products = _context.ProductsRepository.Get(filter: null,
            orderBy: q => q.OrderBy(x => x.ProductName),
            includeProperties: "Supplier,Category",
            pageIndex: 1,
            pageSize: 10);
                Catelogies = _context.CategoryRepository.Get();
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }

        }
        public IActionResult OnPost()
        {
            // Handle button click and redirect to another Razor Page
            return RedirectToPage("Product/Create");
        }
    }
}
