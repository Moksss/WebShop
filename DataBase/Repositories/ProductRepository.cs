using Core.Abstractions.Repositories;
using Core.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string fileName = "WebShopProducts.json";

        private Dictionary<int, Product> _products = new Dictionary<int, Product>();
        private int _id = 0;

        public ProductRepository()
        {
            LoadDatabase();
        }

        public Product? GetById(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                return _products[productId];
            }

            return null;
        }

        public List<Product> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        public bool Insert(Product product)
        {
            product.Id = ++_id;
            _products.Add(product.Id, product);
            SaveDatabase();
            return true;
        }

        public bool Update(int productId, Product product)
        {
            if (!_products.ContainsKey(productId))
            {
                return false;
            }

            _products[productId] = product;
            SaveDatabase();
            return true;
        }

        public bool Delete(int productId)
        {
            if (_products.Remove(productId))
            {
                SaveDatabase();
                return true;
            }

            return false;
        }

        public List<Product> SearchByKeyWord(string keyword)
        {
            return _products
                    .Values
                    .Where(p =>
                        p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                        || p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
        }

        private void LoadDatabase()
        {
            if (File.Exists(fileName))
            {
                try
                {
                    _products = JsonSerializer.Deserialize<Dictionary<int, Product>>(
                        File.ReadAllText(fileName));
                }
                catch (Exception ex)
                {
                }
            }

            if (_products == null)
                _products = new Dictionary<int, Product>();

            _id = _products.Count == 0
                ? 0
                : _products.Values.Select(p => p.Id).Max();
        }

        void SaveDatabase()
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(_products));
        }
    }
}