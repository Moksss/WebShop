using Core.Abstractions.Services;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models.ViewModels;

namespace WebApplication1.Controllers
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

        public ProductController()
        {

        }


        [HttpPost("product")]
        public IActionResult Insert([FromBody]ProizvodModel productModel)
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
