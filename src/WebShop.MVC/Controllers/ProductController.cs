using Microsoft.AspNetCore.Mvc;
using WebShop.BLL.Interfaces;
using WebShop.MVC.ViewModels;

namespace WebShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService service, ICategoryService categoryService)
        {
            _productService = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            var vm = products.Select(ProductViewModel.FromEntity).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(ProductViewModel.FromEntity(product));
        }

        public async Task<IActionResult> Create() 
        {
            var categories = await _categoryService.GetAllAsync();

            var productViewModel = ProductViewModel.FromEntity(new DAL.Models.Product() { Code = "", Name ="" }, categories);

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _productService.CreateAsync(vm.ToEntity());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            var categories = await _categoryService.GetAllAsync();
            var productViewModel = ProductViewModel.FromEntity(product, categories);

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return View(vm);

            await _productService.UpdateAsync(vm.ToEntity());
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(ProductViewModel.FromEntity(product));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
