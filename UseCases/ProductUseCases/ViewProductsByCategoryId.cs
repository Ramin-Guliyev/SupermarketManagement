using System.Collections.Generic;
using CoreBusiness;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class ViewProductsByCategoryId : IViewProductsByCategoryId
    {
        private readonly IProductRepository _productRepository;

        public ViewProductsByCategoryId(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IEnumerable<Product>Execute(int categoryId)
        {
            return _productRepository.GetProductsByCategoryId(categoryId);
        }
    }
}