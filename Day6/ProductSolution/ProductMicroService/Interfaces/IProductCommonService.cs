using ProductMicroService.Models;
using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Interfaces
{
    public interface IProductCommonService
    {
        public Task<IEnumerable<Product>> GetAllProducts(ProductsRequestDTO productsRequestDTO);
    }
}
