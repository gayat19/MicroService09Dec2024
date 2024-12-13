using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Interfaces
{
    public interface ISupplierProductService
    {
        public ICollection<SupplierBasicDTO> GetSupplierList();
    }
}
