using ShoppingAPI.Models;

namespace ShoppingAPI.Interfaces
{
    public interface IProductGeneralService
    {
        public List<Product> GetProducts();
    }
}
