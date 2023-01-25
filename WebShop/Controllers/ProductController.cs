using Core.Abstractions.Services;
using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebShop.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("product")]
        public IActionResult Insert([FromBody] ProizvodModel productModel)
        {
            var p = new Proizvod
            {
                Cena = productModel.Cena,
                Ime = productModel.Ime,
                Kategorija = productModel.Kategorija,
                Opis = productModel.Opis
            };

            _productService.InsertProduct(p);

            return Ok();
        }
    }
}