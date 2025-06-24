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
        private readonly BankSystemDbContext _context;
        public TransactionTypeData(BankSystemDbContext contex)
        {
            _context = contex;
        }

        public async Task<IEnumerable<TransactionType>> GetAllTransactionTypes()
        {
            return await _context.TransactionTypes.ToListAsync();
        }
    }
}
