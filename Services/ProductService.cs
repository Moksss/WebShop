using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.Domain;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public void InsertProduct(Proizvod product)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

            _repository.Insert(product);
        }
    }
}