using Core.Abstractions.Repository;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Proizvod> products;

        public ProductRepository()
        {
            products = new List<Proizvod>();
        }
        public void Insert(Proizvod product)
        {
            products.Add(product);
        }
    }
}
