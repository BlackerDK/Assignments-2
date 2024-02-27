using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.ModelsDbF;
using System.Linq;

namespace SignalRAssignment.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private readonly UnitOfWork _context;

        public CheckoutModel(UnitOfWork context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.TryGetValue("Cart", out byte[] cartData))
            {
                // Deserialize giỏ hàng từ session
                var cartItems = System.Text.Json.JsonSerializer.Deserialize<List<Repository.ModelsDbF.Cart>>(cartData);

                // Tính tổng tiền của hóa đơn
                decimal totalMoney = (decimal)cartItems.Sum(item => item.Product.UnitPrice * item.Quality);

                ViewData["TotalMoney"] = totalMoney;
            }
            // Lấy giỏ hàng từ session
            

            return Page();
        }
    }
}
