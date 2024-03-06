using System.ComponentModel.DataAnnotations;

namespace EternaMVC.Models
{
    public class Slider: BaseEntity
    {
        [Required]
        [StringLength(maximumLength:20)]
        public string Title1 { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Title2 { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
    }
}
