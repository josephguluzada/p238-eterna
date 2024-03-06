using System.ComponentModel.DataAnnotations;

namespace EternaMVC.Models
{
    public class Feature:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Desc { get; set; }
        public string RedirectUrl { get; set; }
        public string IconClass { get; set; }
    }
}
