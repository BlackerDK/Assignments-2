using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Repository;
using Repository.ModelsDbF;

namespace SignalRAssignment.Pages.Category
{
    public class IndexModel : PageModel
    {

        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Repository.ModelsDbF.Category> Categories { get; set; }

        public IActionResult OnGet(string searchTerm)
        {
            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    Categories = unitOfWork.CategoryRepository.Get(c => c.CategoryName.Contains(searchTerm));
                    return RedirectToPage("/Category/Index");
                }
                else
                {
                    Categories = unitOfWork.CategoryRepository.Get();
                    return RedirectToPage("/Category/Index");
                }
            }else
            {
               return RedirectToPage("/Login");
            }
        }
    }
}
