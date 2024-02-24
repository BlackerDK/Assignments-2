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

        public async Task OnGetAsync()
        {
            Products = _context.ProductsRepository.Get(filter: null,
            orderBy: q => q.OrderBy(x => x.ProductName),
            includeProperties: "Supplier,Category",
            pageIndex: 1,
            pageSize: 10);
            Catelogies = _context.CategoryRepository.Get();
        }
        public IActionResult OnPost()
        {
            // Handle button click and redirect to another Razor Page
            return RedirectToPage("Product/Create");
        }
    }
}
