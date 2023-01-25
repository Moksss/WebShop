using Core.Abstractions.Repositories;
using Core.Domain;

namespace Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Proizvod> _products;

        public ProductRepository()
        {
            _products = new List<Proizvod>();
        }

        public void Insert(Proizvod product)
        {
            _products.Add(product);
        }
    }
}