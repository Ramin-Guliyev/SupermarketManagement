using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _transactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase transactionUseCase)
        {
            _productRepository = productRepository;
            _transactionUseCase = transactionUseCase;
        }

        public void Execute(string cashierName,int productId,int qtyToSell)
        {
            var product = _productRepository.GetProductById(productId);
            if (product is null)
                return;
            _transactionUseCase.Execute(cashierName, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            _productRepository.UpdateProduct(product);
           
        }
    }
}