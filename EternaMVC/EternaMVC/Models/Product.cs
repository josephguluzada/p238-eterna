using System.ComponentModel.DataAnnotations;

namespace EternaMVC.Models
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(300)]
        public string Desc { get; set; }
        public string? Client { get; set; }
        public string? ProjectUrl { get; set; }
        public Category? Category { get; set; }

        public List<ProductImage>? ProductImages { get; set; }
    }
}
