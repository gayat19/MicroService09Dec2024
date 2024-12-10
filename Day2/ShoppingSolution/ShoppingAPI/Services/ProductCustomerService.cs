using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Repositories;

namespace ShoppingAPI.Services
{
    public class ProductCustomerService : IProductGeneralService
    {
        private readonly IRepository<Product, int> _productRepository;

        public ProductCustomerService(IRepository<Product,int> productRepository)//Taking the injection
        {
            _productRepository= productRepository;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.Get().OrderBy(p => p.PricePerUnit);//sorting the products based on price in ascending order
            return products.ToList();
        }
    }
}
