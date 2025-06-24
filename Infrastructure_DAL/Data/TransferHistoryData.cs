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
    class TransferHistoryData : ITransferHistory
    {
        private readonly BankSystemDbContext _context;
        public TransferHistoryData(BankSystemDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> AddNewAsync(TransferHistory NewTransferHistory)
        {

            if (NewTransferHistory is null)
            {
                throw new ArgumentNullException(nameof(NewTransferHistory));
            }

            await _context.TransferHistories.AddAsync(NewTransferHistory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int TransferHistoryID)
        {
            var TransferHistory = await _context.TransferHistories.FindAsync(TransferHistoryID);
            if (TransferHistory is null) 
            {
            return false;
            }
            _context.TransferHistories.Remove(TransferHistory);
            return await _context.SaveChangesAsync() > 0;
        
        }

        public async Task<TransferHistory?> FindByIDAsync(int TransferHistoryID)
        {
            return await _context.TransferHistories.Include(t => t.FromClient)
                .Include(t => t.ToClient).Include(t => t.CreatedByUser)
                .FirstOrDefaultAsync(t => t.TransferID == TransferHistoryID);
        }

        public async Task<IEnumerable<TransferHistory>> GetAllTransferHistoriesAsync()
        {
            return await _context.TransferHistories.ToListAsync();
        }

        public async Task<bool> UpdateAsync(TransferHistory TransferHistory)
        {

            if (TransferHistory is null)
            {
                throw new ArgumentNullException(nameof(TransferHistory));
            }

             _context.TransferHistories.Update(TransferHistory);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
