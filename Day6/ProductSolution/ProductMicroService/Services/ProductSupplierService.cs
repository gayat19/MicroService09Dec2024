using ProductMicroService.Interfaces;
using ProductMicroService.Models;
using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Services
{
    public class ProductSupplierService : ProductService, IProductSupplerService
    {
        private readonly IAuditLogService _auditLogService;

        public ProductSupplierService(IRepository<int, Product> repository,
                                        IAuditLogService auditLogService) : base(repository)
        {
            _auditLogService = auditLogService;
        }

        public async Task<Product> AddProduct(Product product)
        {
            if(product == null)
            {
                throw new Exception("Product cannot be null");
            }
            if(product.PricePerUnit <= 0)
            {
                throw new Exception("Price cannot be less than or equal to 0");
            }
            if (product.StockAvailable < 0)
            {
                throw new Exception("Stock cannot be less than 0");
            }
            return (await _repository.Add(product));
        }

        public async Task<Product> UpdateProductPrice(ProductPriceUpdateRequestDTO product)
        {
            var prod = await _repository.GetById(product.ProdcutId);
            if (prod == null)
            {
                throw new Exception("Product not found");
            }
            if(product.NewPrice <= 0)
            {
                throw new Exception("Price cannot be less than or equal to 0");
            }
            var result = await InsertIntoAuditLog("Product", "Price", prod.PricePerUnit, product.NewPrice);
            prod.PricePerUnit = product.NewPrice;
            return (await _repository.Update(prod));
        }

        private async Task<AuditLogDTO> InsertIntoAuditLog(string tableName, string fieldName, float pricePerUnit, float newPrice)
        {
            AuditLogDTO auditLogDTO = new AuditLogDTO()
            {
                TableName = tableName,
                ColumnName = fieldName,
                OldValue = pricePerUnit.ToString(),
                NewValue = newPrice.ToString(),
                ModifiedAt = DateTime.Now,
                ModifiedBy = "Supplier"
            };
            var result = await _auditLogService.LogAudit(auditLogDTO);
            if (result == null)
            {
                throw new Exception("Failed to log audit");
            }
            return result;
        }

        public async Task<Product> UpdateProductStock(ProductStockUpdateRequestDTO product)
        {
            var prod = await _repository.GetById(product.ProductId);
            if (prod == null)
            {
                throw new Exception("Product not found");
            }
            if (product.StockToBeAdded <= 0)
            {
                throw new Exception("Quantity cannot be less than or equal to 0");
            }
            var result = await InsertIntoAuditLog("Product", "Stock", prod.StockAvailable, prod.StockAvailable +product.StockToBeAdded);
            prod.StockAvailable   += product.StockToBeAdded;
            
            return (await _repository.Update(prod));
        }
    }
}
