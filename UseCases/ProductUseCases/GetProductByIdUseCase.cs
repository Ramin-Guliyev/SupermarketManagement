using CoreBusiness;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private IProductRepository _productRepository;
        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public Product Execute(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}