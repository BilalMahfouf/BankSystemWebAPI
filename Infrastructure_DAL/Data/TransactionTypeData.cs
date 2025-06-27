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
    public  class TransactionTypeData
    {
        private readonly BankSystemDb3Context _context;
        public TransactionTypeData(BankSystemDb3Context contex)
        {
            _context = contex;
        }

        public  async Task<IEnumerable<TransactionType>> GetAllTransactionTypesAsync()
        {
            return await _context.TransactionTypes.ToListAsync();
        }
    }
}
