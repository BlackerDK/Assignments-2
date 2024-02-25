using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using Repository.ModelsDbF;
using System.Reflection.Metadata;

namespace SignalRAssignment.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Repository.ModelsDbF.Product Product { get; set; } = new Repository.ModelsDbF.Product();
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
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
        public IActionResult OnPost()
        {
            if (Image != null && Image.Length > 0)
            {
                string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(Image.FileName);
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", newFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    Image!.CopyToAsync(stream);
                }
                Product.ProductImage = newFileName;
                if (!ModelState.IsValid)
                {
                    Product.ProductImage = newFileName;
                    _unitOfWork.ProductsRepository.Insert(Product);
                    _unitOfWork.Save();
                    return RedirectToPage("/Product/Index");
                }
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
