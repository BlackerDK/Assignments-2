using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using Repository.ModelsDbF;

namespace SignalRAssignment.Pages.Category
{
    public class IndexModel : PageModel
    {

        private  UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<Repository.ModelsDbF.Category> Categories { get; set; }

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
