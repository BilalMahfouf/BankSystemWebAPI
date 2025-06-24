using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public interface ITransaction
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task<Employee?> FindByIDAsync(int TransactionID);
        Task<bool> AddNewAsync(Transaction NewTransaction);
        Task<bool> UpdateAsync(Transaction Transaction);
        Task<bool> DeleteAsync(int TransactionID);
    }
}
