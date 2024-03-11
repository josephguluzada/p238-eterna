namespace EternaMVC.Models
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public string Url { get; set; }

        public Product Product { get; set; }
    }
}
