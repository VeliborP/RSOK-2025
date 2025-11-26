using System.ComponentModel.DataAnnotations;
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
        public string? CategoryName { get; set; }

        public int? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        internal static string? FromEntity(Product product)
        {
            throw new NotImplementedException();
        }

        internal Product ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
