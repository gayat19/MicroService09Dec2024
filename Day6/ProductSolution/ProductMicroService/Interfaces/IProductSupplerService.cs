using ProductMicroService.Models;
using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Interfaces
{
    public interface IProductSupplerService :IProductCommonService
    {
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProductPrice(ProductPriceUpdateRequestDTO product);
        public Task<Product> UpdateProductStock(ProductStockUpdateRequestDTO product);
    }
}
