using Core.Abstractions.Repository;
using Core.Abstractions.Services;
using Core.Domain;

namespace Services
{
    public class ProductServices : IProductService
    {

        private readonly IProductRepository repository;
        public ProductServices(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public void InsertProduct(Proizvod proizvod)
        {
            // ovde ide validacija
            if (proizvod == null) throw new ArgumentException(nameof(proizvod));
            repository.Insert(proizvod);

        }
    }
}
