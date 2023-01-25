using Core.Domain;

namespace Core.Abstractions.Services
{
    public interface IProductService
    {
        void InsertProduct(Proizvod product);
    }
}