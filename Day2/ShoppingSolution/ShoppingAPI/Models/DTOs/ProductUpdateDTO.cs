namespace ShoppingAPI.Models.DTOs
{
    public class ProductUpdateDTO
    {
        public ProductPriceUpdateRquestDTO? PriceChange { get; set; }
        public ProductStockUpdateRquestDTO? StockChange { get; set; }
    }
}
