using Core.Abstractions.Services;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebShop.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public List<ProductViewModel?> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpPost("products")]
        public IActionResult Insert([FromBody] ProductViewModel productModel)
        {
            _productService.Insert(productModel);

            return Ok();
        }

        [HttpGet("products/search/{keyword}")]
        public List<ProductViewModel?> SearchByKeyword(string keyword)
        {
            return _productService.SearchByKeyWord(keyword);
        }

        [HttpGet("products/{productId}")]
        public ProductViewModel? GetById(int productId)
        {
            return _productService.GetById(productId);
        }

        [HttpDelete("products/{productId}")]
        public bool DeleteById(int productId)
        {
            return _productService.Delete(productId);
        }

        [HttpPut("products")]
        public bool UpdateProducts(int productId, ProductViewModel productViewModel)
        {
            return _productService.Update(productId, productViewModel);
        }
    }
}