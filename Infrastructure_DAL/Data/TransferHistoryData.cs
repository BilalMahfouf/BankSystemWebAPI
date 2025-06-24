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
    class TransferHistoryData : ITransferHistory
    {
        private readonly BankSystemDbContext _context;
        public TransferHistoryData(BankSystemDbContext context) 
        {
         _context = context;
        }

        public async Task<int> AddNewAsync(TransferHistory NewTransferHistory)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int TransferHistoryID)
        {
            throw new NotImplementedException();
        }

        public async Task<TransferHistory>? FindByIDAsync(int TransferHistoryID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TransferHistory>> GetAllTransferHistoriesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int TransferHistoryID, TransferHistory TransferHistory)
        {
            throw new NotImplementedException();
        }
    }
}
