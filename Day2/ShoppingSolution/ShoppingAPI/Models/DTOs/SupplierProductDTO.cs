namespace ShoppingAPI.Models.DTOs
{
    public class SupplierProductDTO
    {
        public string SupplierId { get; set; }= string.Empty;

        public string SupplierName { get; set; } = string.Empty;

        public List<Product>? products { get; set; }
    }
}
