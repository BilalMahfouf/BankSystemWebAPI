using Domain_BLL.DTOs.Person;
using Domain_BLL.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<CreateTransactionDTO>> GetAllTransactionsAsync();
        Task<CreateTransactionDTO?> GetTransactionByIdAsync(int transactionID);
        Task<bool> CreateTransactionAsync(CreateTransactionDTO createTransaction);
        Task<bool> UpdateTransactionAsync(UpdateTransactionDTO transaction);
        Task<bool> DeleteTransactionAsync(int transactionID);
    }
}
