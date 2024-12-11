using ShoppingAPI.Models;
using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Interfaces
{
    public interface IProductSupplierService:IProductGeneralService
    {
        public Product AddProduct(Product product);
        public Product UpdatePrice(ProductPriceUpdateRquestDTO productDto);
        public Product UpdateStock(ProductStockUpdateRquestDTO productDto);
    }
}
