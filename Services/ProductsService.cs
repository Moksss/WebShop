using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.Domain;
using Models.ViewModels;

namespace Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _repository;

        public ProductsService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ProductViewModel? GetById(int productId)
        {
            return MapToViewModel(_repository.GetById(productId));
        }

        public List<ProductViewModel?> GetAllProducts()
        {
            return _repository
                .GetAllProducts()
                .Select<Product?, ProductViewModel?>(p => MapToViewModel(p))
                .Where(p => p != null)
                .ToList();
        }

        public void Insert(ProductViewModel productViewModel)
        {
            Product? product = MapFromViewModel(productViewModel);

            if (product == null)
                throw new ArgumentNullException(nameof(productViewModel));

            _repository.Insert(product);
        }

        public bool Update(int productId, ProductViewModel productViewModel)
        {
            Product? product = MapFromViewModel(productViewModel);

            if (product == null)
                throw new ArgumentNullException(nameof(productViewModel));

            return _repository.Update(productId, product);
        }

        public bool Delete(int productId)
        {
            return _repository.Delete(productId);
        }

        public List<ProductViewModel?> SearchByKeyWord(string keyword)
        {
            return _repository
                .SearchByKeyWord(keyword)
                .Select<Product?, ProductViewModel?>(p => MapToViewModel(p))
                .Where(p => p != null)
                .ToList();
        }

        private ProductViewModel? MapToViewModel(Product? p)
        {
            if (p == null)
                return null;

            return new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
            };
        }

        private Product? MapFromViewModel(ProductViewModel? p)
        {
            if (p == null)
                return null;

            return new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                Description = p.Description,
            };
        }

    }
}