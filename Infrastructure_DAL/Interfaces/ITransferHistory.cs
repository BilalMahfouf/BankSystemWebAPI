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
        Task<IEnumerable<TransferHistory>> GetAllTransferHistories();
        Task<TransferHistory>? FindByID(int TransferHistoryID);
        Task<int> AddNew(TransferHistory NewTransferHistory);
        Task<bool> Update(int TransferHistoryID, TransferHistory TransferHistory);
        Task<bool> Delete(int TransferHistoryID);
    }
}
}
