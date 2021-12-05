using CoreBusiness;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
   
    public class EditProductUseCase : IEditProductUseCase
    {
        public IProductRepository productRepository { get; }

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(Product product)
        {
            productRepository.UpdateProduct(product);
        }
        
    }
}