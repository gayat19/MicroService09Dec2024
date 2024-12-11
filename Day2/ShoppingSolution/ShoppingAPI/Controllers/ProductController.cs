using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ShoppingAPI.Interfaces;
using ShoppingAPI.Models;
using ShoppingAPI.Models.DTOs;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]//attribute routing
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSupplierService _productService;

        public ProductController(IProductSupplierService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<ICollection<Product>> GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorDTO { ErrorNumber=400,ErrorMessage=e.Message});
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<Product> AddProduct(Product product)
        {
            try
            {
                var newProduct = _productService.AddProduct(product);
                return Created("", newProduct);
            }
            catch (Exception e)
            {

                return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = e.Message });
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public ActionResult<Product> UpdateProduct(ProductUpdateDTO productDto)
        {
            string message = "";
            try
            {
                if (productDto.PriceChange != null)
                {
                    var updatedProduct = _productService.UpdatePrice(productDto.PriceChange);
                    return Ok(updatedProduct);
                }
                else if (productDto.StockChange != null)
                {
                    var updatedProduct = _productService.UpdateStock(productDto.StockChange);
                    return Ok(updatedProduct);
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return BadRequest(new ErrorDTO { ErrorNumber = 400, ErrorMessage = message });
        }
       
    }
}
