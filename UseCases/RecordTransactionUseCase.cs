using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIdUseCase getProductByIdUseCase;

        public RecordTransactionUseCase(ITransactionRepository transactionRepository, IGetProductByIdUseCase getProductByIdUseCase = null)
        {
            this.transactionRepository = transactionRepository;
            this.getProductByIdUseCase = getProductByIdUseCase;
        }
        public void Execute(string cashierName, int productId, int qyt)
        {
            var product = getProductByIdUseCase.Execute(productId);
            transactionRepository.Save(cashierName, productId,product.Name, product.Price.Value,product.Quantity.Value, qyt);
        }
    }
}
