using System.ComponentModel.DataAnnotations;

namespace WebShop.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(50)]
        public required string Code { get; set; }
        [StringLength(150)]
        public required string Name { get; set; }
        [StringLength(1500)]
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
