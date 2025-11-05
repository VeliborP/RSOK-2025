using Microsoft.AspNetCore.Mvc;
using WebShop.MVC.Models.Product;

namespace WebShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<ProductViewModel> products =
            [
                new ProductViewModel
                {
                    Id = 1,
                    Code = "001",
                    Name = "RAM memorija"
                },
                new ProductViewModel
                {
                    Id = 2,
                    Code = "002",
                    Name = "LG monitor"
                },
            ];

            return View(products);
        }
    }
}
