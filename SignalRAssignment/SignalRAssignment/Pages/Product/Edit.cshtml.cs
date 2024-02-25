using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace SignalRAssignment.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> SupplierList { get; set; }
        public IFormFile Image { get; set; }
        public EditModel(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }
        [BindProperty]
        public Repository.ModelsDbF.Product Product { get; set; } = new Repository.ModelsDbF.Product();
        public void OnGet(int? id)
        {
            var product = unitOfWork.ProductsRepository.GetByID(id);
            if (id == null)
            {
                Response.Redirect("/Product/Index");
                return;
            }
            if (product == null)
            {
                Response.Redirect("/Product/Index");
                return;
            }
            CategoryList = unitOfWork.CategoryRepository.Get()
                        .Select(x => new SelectListItem { Value = x.CategoryId.ToString(), Text = x.CategoryName })
                        .ToList();
            SupplierList = unitOfWork.SupplierRepository.Get()
            .Select(x => new SelectListItem { Value = x.SupplierId.ToString(), Text = x.CompanyName })
            .ToList();
            Product = product;
        }
        public IActionResult OnPost(int? id)
        {
            var product = unitOfWork.ProductsRepository.GetByID(id);
            if (product == null)
            {
                Response.Redirect("/Product/Index");
            }
            string newFileName = Image.FileName;
            Product.ProductImage = newFileName;
            if (Image != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(Product.ProductImage);
                string imagePath = environment.WebRootPath + "/Images/" + newFileName;
                using (var stream = System.IO.File.Create(imagePath))
                {
                    Image!.CopyTo(stream);
                }
                string oldImagePath = environment.WebRootPath + "/Images/" + product.ProductImage;
                System.IO.File.Delete(oldImagePath);
            }
            if (!ModelState.IsValid)
            {
                product.ProductImage = newFileName;
                product.UnitPrice = Product.UnitPrice;
                product.ProductName = Product.ProductName;
                product.CategoryId = Product.CategoryId;
                product.SupplierId = Product.SupplierId;
                product.QuantityPerUnit = Product.QuantityPerUnit;
                unitOfWork.ProductsRepository.Update(product);
                unitOfWork.Save();
                Product = product;
                return RedirectToPage("/Product/Index");

            }
            return Page();
        }
    }
}
