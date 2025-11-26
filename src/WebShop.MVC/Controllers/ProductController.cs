using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using WebShop.BLL.Interfaces;
using WebShop.MVC.ViewModels;
//using WebShop.DAL;
//using WebShop.DAL.Models;

namespace WebShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllAsync();
            var vm = products.Select(ProductViewModel.FromEntity).ToList();
            return View(vm);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(ProductViewModel.FromEntity(product));
        }

        // GET: Product/Create
        public IActionResult Create() => View();

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.CreateAsync(vm.ToEntity());
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(ProductViewModel.FromEntity(product));
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel vm)
        {
            if (id != vm.Id) return BadRequest();
            if (!ModelState.IsValid) return View(vm);

            await _service.UpdateAsync(vm.ToEntity());
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            return View(ProductViewModel.FromEntity(product));
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
