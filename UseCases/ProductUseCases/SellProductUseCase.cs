using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(int productId,int qtyToSell)
        {
            var product = _productRepository.GetProductById(productId);
            if (product is null)
                return;
            product.Quantity -= qtyToSell;
            _productRepository.UpdateProduct(product);
        }
    }
}