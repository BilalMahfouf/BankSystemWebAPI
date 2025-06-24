using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{
    public class TransactionData : ITransaction
    {
        private readonly BankSystemDbContext _context;
        public TransactionData(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Transaction NewTransaction)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int TransactionID)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee>? FindByIDAsync(int TransactionID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int TransactionID, Transaction Transaction)
        {
            throw new NotImplementedException();
        }
    }
}
