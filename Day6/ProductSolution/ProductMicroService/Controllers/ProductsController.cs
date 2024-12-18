using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroService.Filters;
using ProductMicroService.Interfaces;
using ProductMicroService.Models;
using ProductMicroService.Models.DTOs;

namespace ProductMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomExceptionFilter]
    public class ProductsController : ControllerBase
    {
        private readonly IProductSupplerService _productService;

        public ProductsController(IProductSupplerService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> GetProducts(ProductsRequestDTO productsRequestDTO)
        {
            var products = await _productService.GetAllProducts(productsRequestDTO);
            return Ok(products);
        }
        [HttpPost("NewProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var newProduct = await _productService.AddProduct(product);
            return Ok(newProduct);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestDTO product)
        {
            if(product.StockUpdate != null)
            {
                var updatedProduct = await _productService.UpdateProductStock(product.StockUpdate);
                return Ok(updatedProduct);
            }
            if(product.PriceUpdate != null)
            {
                var updatedProduct = await _productService.UpdateProductPrice(product.PriceUpdate);
                return Ok(updatedProduct);
            }
            return BadRequest("Invalid request");
        }


    }
}
