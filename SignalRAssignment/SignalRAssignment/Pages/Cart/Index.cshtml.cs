using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRAssignment.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _context;

        public IEnumerable<Repository.ModelsDbF.Product> Products { get; set; }
        public List<Repository.ModelsDbF.Cart> CartItems { get; set; }

        public IndexModel(UnitOfWork context)
        {
            _context = context;
            //CartItems = new List<Repository.ModelsDbF.Product>();
        }

        public async Task OnGetAsync()
        {

            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                Products = _context.ProductsRepository.Get(filter: null,
                orderBy: q => q.OrderBy(x => x.ProductName),
                includeProperties: "Supplier,Category",
                pageIndex: 1,
                pageSize: 10);

                // Lấy giỏ hàng từ session
                if (HttpContext.Session.TryGetValue("Cart", out byte[] cartData))
                {
                    CartItems = System.Text.Json.JsonSerializer.Deserialize<List<Repository.ModelsDbF.Cart>>(cartData);
                }
            }
            else
            {
                RedirectToPage("/Login");
            }
        }
        //public async Task<IActionResult> OnPostAddAsync(int productId)
        //{
        //    // Thêm sản phẩm vào giỏ hàng ở đây
        //    // Ví dụ: 
        //     var product = _context.ProductsRepository.GetByID(productId);
        //     //var cart = HttpContext.Session.Get<List<Repository.ModelsDbF.Product>>("Cart") ?? new List<Product>();
        //    // cart.Add(product);
        //    // HttpContext.Session.Set("Cart", cart);

        //    return RedirectToPage("Index");
        //}

		//public void OnGet(int? id)
		//{
		//	if (id == null)
		//	{
		//		Response.Redirect("/Product/Index");
		//		return;
		//	}
		//	var product = _context.ProductsRepository.GetByID(id);
		//	if (product == null)
		//	{
		//		Response.Redirect("/Product/Index");
		//		return;
		//	}
		
		//	Response.Redirect("/Product/Index");
		//}

		public IActionResult OnPost(int productId)
        {
            //// Lấy sản phẩm từ cơ sở dữ liệu
            //var product = _context.ProductsRepository.GetByID(productId);

            //// Lấy giỏ hàng từ session
            //if (HttpContext.Session.TryGetValue("Cart", out byte[] cartData))
            //{
            //    CartItems = System.Text.Json.JsonSerializer.Deserialize<List<Repository.ModelsDbF.Product>>(cartData);
            //}

            //// Thêm sản phẩm vào giỏ hàng
            //CartItems.Add(product);

            //// Lưu giỏ hàng vào session
            //HttpContext.Session.Set("Cart", System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(CartItems));

            //// Chuyển hướng người dùng đến trang giỏ hàng
            return RedirectToPage("Index");
        }
    }
}
