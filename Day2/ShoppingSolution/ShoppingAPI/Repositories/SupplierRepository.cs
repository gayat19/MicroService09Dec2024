using ShoppingAPI.Contexts;
using ShoppingAPI.Exceptions;
using ShoppingAPI.Models;

namespace ShoppingAPI.Repositories
{
    public class SupplierRepository : Repository<Supplier, string>
    {
        public SupplierRepository(ShoppingContext context)
        {
            _shoppingContext = context;
        }
        public override ICollection<Supplier> Get()
        {
            var suppliers = _shoppingContext.Suppliers.ToList();
            if(suppliers.Count == 0)
            {
                throw new RepositoryEmptyException("No Sppliers in the database");
            }
            return suppliers;
        }

        public override Supplier Get(string key)
        {
            var supplier = _shoppingContext.Suppliers.SingleOrDefault(s => s.SupplierId == key);
            if (supplier == null)
            {
                throw new EntityNotFoundException("No Supplier with teh given ID");
            }
            return supplier;
        }
    }
}
