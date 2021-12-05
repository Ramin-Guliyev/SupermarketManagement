using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;
        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product{CategoryId = 1, Name ="Ice Tea",ProductId=1,Price=1.99,Quantity=100},
                new Product{CategoryId = 1, Name ="Ginger Ale",ProductId =2,Price=2.99,Quantity=200},
                new Product{CategoryId = 3, Name ="Wheat Bread",ProductId=3,Price=1.59,Quantity =300},
                new Product{CategoryId = 3,Name="White Bread",ProductId=4,Price=1.50,Quantity=250},
                new Product{CategoryId = 2, Name ="Beef",ProductId =5,Price=19.99,Quantity=25}
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
                return;

            if (products is not null && products.Count > 0)
            {
                var id = products.Max(x => x.ProductId);
                product.ProductId = id + 1;
            }
            else
                product.ProductId = 1;

            products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate is null)
                return;

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
            productToUpdate.CategoryId = product.CategoryId;
        }
        public  Product GetProductById(int productId)
        {
            return products.FirstOrDefault(x => x.ProductId == productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}
