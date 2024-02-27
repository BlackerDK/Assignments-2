using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace SignalRAssignment.Pages.Cart
{
    public class RemoveItemModel : PageModel
    {
        private readonly UnitOfWork _context;

        public IEnumerable<Repository.ModelsDbF.Product> Products { get; set; }
        public List<Repository.ModelsDbF.Cart> CartItems { get; set; }

        public RemoveItemModel(UnitOfWork context)
        {
            _context = context;
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
                    // Giảm quality của sản phẩm đã tồn tại trong giỏ hàng
                    existingCartItem.Quality--;

                    // Nếu quality bằng 0 thì xóa sản phẩm khỏi giỏ hàng
                    if (existingCartItem.Quality == 0)
                    {
                        CartItems.Remove(existingCartItem);
                    }
                }
            }

            // Lưu giỏ hàng vào session
            HttpContext.Session.Set("Cart", System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(CartItems));

            return RedirectToPage("/Cart/Index");
        }
    }
}
