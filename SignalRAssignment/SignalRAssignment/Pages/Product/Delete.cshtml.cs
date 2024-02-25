using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace SignalRAssignment.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Product/Index");
                return;
            }
            var product = unitOfWork.ProductsRepository.GetByID(id);
            if (product == null)
            {
                Response.Redirect("/Product/Index");
                return;
            }
            unitOfWork.ProductsRepository.Delete(product);
            unitOfWork.Save();
            Response.Redirect("/Product/Index");
        }
    }
}
