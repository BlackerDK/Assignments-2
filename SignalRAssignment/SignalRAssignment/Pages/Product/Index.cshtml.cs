using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = new UnitOfWork(context);
        }

        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Categories> Catelogies { get; set; }

        public async Task OnGetAsync()
        {
            Products = _context.ProductsRepository.Get(filter: null,
            orderBy: q => q.OrderBy(x => x.ProductName),
            includeProperties: "Supplier,Category",
            pageIndex: 1,
            pageSize: 10);
            Catelogies = _context.CategoryRepository.Get();
        }
    }
}
