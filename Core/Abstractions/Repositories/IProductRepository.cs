using Core.Domain;

namespace Core.Abstractions.Repositories
{
    public interface IProductRepository
    {
        void Insert(Proizvod product);
    }
}