using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace SignalRAssignment.Pages.Cart
{
    public class AddItemModel : PageModel
    {
		private readonly UnitOfWork _context;

		public IEnumerable<Repository.ModelsDbF.Product> Products { get; set; }
		public List<Repository.ModelsDbF.Cart> CartItems { get; set; }

		public AddItemModel(UnitOfWork context)
		{
			_context = context;
			//CartItems = new List<Repository.ModelsDbF.Product>();
		}
        public IActionResult OnGet(int? productId)
        {
            if (productId == null)
            {
                return RedirectToPage("/Cart/Index");
            }

            var product = _context.ProductsRepository.GetByID(productId);

            // Lấy giỏ hàng từ session
            if (HttpContext.Session.TryGetValue("Cart", out byte[] cartData))
            {
                CartItems = System.Text.Json.JsonSerializer.Deserialize<List<Repository.ModelsDbF.Cart>>(cartData);

                // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
                var existingCartItem = CartItems.FirstOrDefault(item => item.Product.ProductId == productId);
                if (existingCartItem != null)
                {
                    // Tăng quality của sản phẩm đã tồn tại trong giỏ hàng
                    existingCartItem.Quality++;
                }
                else
                {
                    // Nếu sản phẩm chưa tồn tại trong giỏ hàng, thêm mới vào
                    var newCartItem = new Repository.ModelsDbF.Cart
                    {
                        Product = product,
                        Quality = 1
                    };
                    CartItems.Add(newCartItem);
                }
            }
            else
            {
                // Nếu chưa có giỏ hàng, tạo mới giỏ hàng và thêm sản phẩm vào
                CartItems = new List<Repository.ModelsDbF.Cart>
                {
                    new Repository.ModelsDbF.Cart
                    {
                        Product = product,
                        Quality = 1
                    }
                };
            }

            // Lưu giỏ hàng vào session
            HttpContext.Session.Set("Cart", System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(CartItems));

            return RedirectToPage("/Cart/Index");
        }
       
	}
}
