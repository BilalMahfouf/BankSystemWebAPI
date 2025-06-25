using Domain_BLL.DTOs.Misc;
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
        Task<IEnumerable<ReadTransactionDTO>> GetAllTransactionsAsync();
        Task<ReadTransactionDTO?> GetTransactionByIdAsync(int transactionID);
        Task<bool> Deposit(TransactionDTO transaction);
        Task<bool> Withdraw(TransactionDTO transaction);
        Task<bool> DeleteTransactionAsync(int transactionID);
        Task<bool> TransferAsync(TransferRequestDTO transferRequest);
    }

}
