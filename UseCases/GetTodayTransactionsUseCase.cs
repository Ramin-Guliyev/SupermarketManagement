using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePlaginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases
{
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTodayTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return _transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
