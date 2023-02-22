using Core.Domain;

namespace Core.Abstractions.Repositories
{
    public interface IProductRepository
    {
        Product? GetById(int productId);
        List<Product> GetAllProducts();
        bool Insert(Product product);
        bool Update(int productId, Product product);
        bool Delete(int productId);
        List<Product> SearchByKeyWord(string keyoword);
    }
}