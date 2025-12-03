using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Humanizer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.DAL.Models;

namespace WebShop.MVC.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Categories = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public required string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("Category name")]
        public string? CategoryName { get; set; }

        public int? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        internal static ProductViewModel FromEntity(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description == null ? "Empty description" : product.Description,
                CategoryName = product.Category == null ? "No category" : product.Category.Name,
                CategoryId = product.CategoryId
            };
        }

        internal static ProductViewModel FromEntity(Product product, List<Category> categories = null)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                CategoryName = product.Category == null ? "---" : product.Category.Name,
                CategoryId = product.CategoryId,
                Categories = categories.Select(model => new SelectListItem
                {
                    Value = model.Id.ToString(),
                    Text = model.Code + "-" + model.Name,
                    Selected = model.Id == product.CategoryId
                }).ToList()
            };
        }

        internal Product ToEntity()
        {
            return new Product
            {
                Id = this.Id,
                Code = this.Code.Trim(),
                Name = this.Name.Trim(),
                Description = this.Description?.Trim(),
                CategoryId = this.CategoryId
            };
        }
    }
}
