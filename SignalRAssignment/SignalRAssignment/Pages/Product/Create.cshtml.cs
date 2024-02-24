using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using Repository.ModelsDbF;

namespace SignalRAssignment.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        public IFormFile Image { get; set; }

        public void OnGet()
        {
            CategoryList = _unitOfWork.CategoryRepository.Get()
                        .Select(x => new SelectListItem { Value = x.CategoryId.ToString(), Text = x.CategoryName })
                        .ToList();
            SupplierList = _unitOfWork.SupplierRepository.Get()
            .Select(x => new SelectListItem { Value = x.SupplierId.ToString(), Text = x.CompanyName })
            .ToList();
        }
        public Repository.ModelsDbF.Product Product { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Product.ProductImage = Image.Name;
                _unitOfWork.ProductsRepository.Insert(Product);
                _unitOfWork.Save();
                return RedirectToPage("/Product/Index");
            }
            return Page();
        }
    }
}
