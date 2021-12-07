using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions;
            return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> GetByDay(string cashierName,DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x=>x.TimeStamp.Date==date.Date);
            return transactions.Where(x => x.TimeStamp.Date == date.Date && string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x=>x.TimeStamp>=startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
            
            return transactions.Where(x => 
                x.TimeStamp.Date  >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date &&
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public void Save(string cashierName,int productId,string productName ,double price,int beforeQyt, int qyt)
        {
            int maxId;
            if(transactions is not null && transactions.Count>0)
                  maxId = transactions.Max(x => x.TransactionId)+1;
            else
                maxId = 1;
            transactions.Add(new Transaction
            {
                ProductId = productId,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                ProductName = productName,
                SoldQyt = qyt,
                BeforeQyt=beforeQyt,
                TransactionId = maxId,
                CashierName=cashierName
            }) ;

        }
    }
}
