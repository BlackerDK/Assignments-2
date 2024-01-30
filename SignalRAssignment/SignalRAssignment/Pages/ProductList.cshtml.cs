using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages
{
    public class ProductListModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public ProductListModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
        public IList<Catelogy> Catelogies { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
            Catelogies = await _context.Catelories.ToListAsync();
        }
    }
}
