using Core.Domain;
namespace Core.Abstractions.Repository
{
    public interface IProductRepository
    {
        void Insert(Proizvod proizvod);
    }
}
