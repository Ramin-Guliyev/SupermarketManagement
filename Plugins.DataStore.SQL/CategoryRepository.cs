using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketDbContext marketDbContext;

        public CategoryRepository(MarketDbContext marketDbContext)
        {
            this.marketDbContext = marketDbContext;
        }
        public void AddCategory(Category category)
        {
            marketDbContext.Categories.Add(category);
            marketDbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = marketDbContext.Categories.Find(categoryId);
            if (category is null)
                return;
            marketDbContext.Categories.Remove(category);
            marketDbContext.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return marketDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return marketDbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var cat = marketDbContext.Categories.Find(category.CategoryId);
            cat.Name = category.Name;
            cat.Description = category.Description;
            marketDbContext.SaveChanges();
        }
    }
}