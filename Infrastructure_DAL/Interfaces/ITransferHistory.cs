using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public interface ITransferHistory
    {
        Task<IEnumerable<TransferHistory>> GetAllTransferHistoriesAsync();
        Task<TransferHistory?> FindByIDAsync(int TransferHistoryID);
        Task<bool> AddNewAsync(TransferHistory NewTransferHistory);
        Task<bool> UpdateAsync( TransferHistory TransferHistory);
        Task<bool> DeleteAsync(int TransferHistoryID);
    }
}

