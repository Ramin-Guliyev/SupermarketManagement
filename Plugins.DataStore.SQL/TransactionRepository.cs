using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePlaginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketDbContext marketDbContext;

        public TransactionRepository(MarketDbContext marketDbContext)
        {
            this.marketDbContext = marketDbContext;
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            return marketDbContext.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return marketDbContext.Transactions.Where(x => x.TimeStamp.Date == date.Date);
            else
                return marketDbContext.Transactions.Where(x =>
                    EF.Functions.Like(x.CashierName, $"%{cashierName}%") &&
                    x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productId, string productName, double price, int beforeQyt, int qyt)
        {

            marketDbContext.Transactions.Add(new Transaction
            {
                ProductId = productId,
                TimeStamp = DateTime.UtcNow,
                Price = price,
                ProductName = productName,
                SoldQyt = qyt,
                BeforeQyt = beforeQyt,
                CashierName = cashierName
            });
            marketDbContext.SaveChanges();
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return marketDbContext.Transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);

            return marketDbContext.Transactions.Where(x =>
                x.TimeStamp.Date >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date &&
                string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));

        }
    }
}
