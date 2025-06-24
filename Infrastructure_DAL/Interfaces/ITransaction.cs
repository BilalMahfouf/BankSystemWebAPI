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
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Employee>? FindByID(int TransactionID);
        Task<int> AddNew(Transaction NewTransaction);
        Task<bool> Update(int TransactionID, Transaction Transaction);
        Task<bool> Delete(int TransactionID);
    }
}
