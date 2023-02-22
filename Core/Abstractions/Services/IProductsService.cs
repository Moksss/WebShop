using Core.Domain;
using Models.ViewModels;

namespace Core.Abstractions.Services
{
    public interface IProductsService
    {
        ProductViewModel? GetById(int productId);
        List<ProductViewModel?> GetAllProducts();
        void Insert(ProductViewModel product);
        bool Update(int productId, ProductViewModel product);
        bool Delete(int productId);
        List<ProductViewModel?> SearchByKeyWord(string keyoword);
    }
}