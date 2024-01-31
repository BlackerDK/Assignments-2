using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Category
{
    public class IndexModel : PageModel
    {


        private readonly UnitOfWork unitOfWork;

        public IEnumerable<Categories> Categories { get; set; }

        public IndexModel(ApplicationDBContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        public void OnGet(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                Categories = unitOfWork.CategoryRepository.Get(c => c.CategoryName.Contains(searchTerm)); ;
            }
            else
            {
                Categories = unitOfWork.CategoryRepository.Get();
            }
        }
    }
}
