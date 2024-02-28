using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.ModelsDbF;

namespace SignalRAssignment.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UnitOfWork _context;

        [BindProperty]
        public Repository.ModelsDbF.Account NewAccount { get; set; } = new Repository.ModelsDbF.Account();
       

        public RegisterModel(UnitOfWork context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (NewAccount == null)
            {
                // Xử lý trường hợp NewAccount null
                return Page();
            }
            // Kiểm tra xem tên người dùng đã tồn tại chưa
            var existingUser = _context.AccountRepository.Get(u => u.UserName.Equals( NewAccount.UserName));
            if (existingUser.Any())
            {
                ModelState.AddModelError(string.Empty, "Username already exists. Please choose a different username.");
                return Page();
            }

            // Thêm tài khoản mới vào cơ sở dữ liệu
            _context.AccountRepository.Insert(NewAccount);
            _context.Save();

            return RedirectToPage("/Login"); // Chuyển hướng đến trang chủ hoặc trang đăng nhập
        }
    }
}
