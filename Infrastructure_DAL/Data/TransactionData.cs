using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{
    public class TransactionData : ITransactionData
    {
        private readonly BankSystemDb3Context _context;
        public TransactionData(BankSystemDb3Context context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Transaction NewTransaction)
        {
           if (NewTransaction is null)
            {
                throw new ArgumentNullException(nameof(NewTransaction));
            }
           
            await _context.Transactions.AddAsync(NewTransaction);
             await _context.SaveChangesAsync();
            return NewTransaction.TransactionID;
        }

        public async Task<bool> DeleteAsync(int TransactionID)
        {
            var Transaction = await _context.Transactions.FindAsync(TransactionID);
            if (Transaction is null) return false;

            _context.Transactions.Remove(Transaction);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Transaction?> FindByIDAsync(int TransactionID)
        {
            return await _context.Transactions.Include(t => t.TransactionType)
                .Include(t => t.Client).Include(t => t.CreatedByUser)
                .FirstOrDefaultAsync(t => t.TransactionID == TransactionID);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Transaction Transaction)
        {
            if (Transaction is null)
            {
                throw new ArgumentNullException(nameof(Transaction));
            }

             _context.Transactions.Update(Transaction);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
