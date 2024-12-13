using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingAPI.Models
{
    public enum Status
    {
        Active,
        Inactive,
        OutOfStock
    }
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }//By default it will be treated as primary key
        public string Title { get; set; } = string.Empty;
        public float PricePerUnit { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StockAvailable { get; set; }

        public Status Status
        {
            get
            {
                if (StockAvailable == 0)
                {
                    return Status.OutOfStock;
                }
                else
                {
                    return Status.Active;
                }
            }
        }


        public bool Equals(Product? other)//parameter is nullable product object
        {
            if (other == null) return false;
            Product p1 = this;
            Product p2 = other;
            return p1.Title == p2.Title;
        }
        public string? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }//Navigation property
    }
}
