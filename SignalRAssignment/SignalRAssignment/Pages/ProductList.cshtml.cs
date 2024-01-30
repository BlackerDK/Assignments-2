using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;
using SignalRAssignment.Repo;

namespace SignalRAssignment.Pages
{
    public class ProductListModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        ProductService _productService = new ProductService();

        public ProductListModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }
        public IList<Catelogy> Catelogies { get; set; }

        public async Task OnGetAsync()
        {
            Products = _productService.GetAll();
            Catelogies = await _context.Catelories.ToListAsync();
        }
    }
}
