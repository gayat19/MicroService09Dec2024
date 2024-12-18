namespace ProductMicroService.Models.DTOs
{
    public class ProductPriceUpdateRequestDTO
    {
        public int ProdcutId { get; set; }
        public float NewPrice { get; set; }
    }
}
