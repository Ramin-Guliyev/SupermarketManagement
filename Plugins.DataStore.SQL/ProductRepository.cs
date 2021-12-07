using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketDbContext marketDbContext;

        public ProductRepository(MarketDbContext marketDbContext)
        {
            this.marketDbContext = marketDbContext;
        }
        public void AddProduct(Product product)
        {
            marketDbContext.Products.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var product = marketDbContext.Products.Find(productId);
            if (product is null)
                return;
            marketDbContext.Products.Remove(product);
            marketDbContext.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return marketDbContext.Products.FirstOrDefault(p=>p.ProductId==productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return marketDbContext.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return marketDbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = marketDbContext.Products.Find(product.ProductId);
            prod.Name = product.Name;
            prod.Category=product.Category;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            prod.CategoryId = product.CategoryId;
            marketDbContext.SaveChanges();
        }
    }
}
