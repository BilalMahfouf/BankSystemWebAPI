using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_BLL.DTOs.TransferHistory;

namespace Domain_BLL.Interfaces
{
    public interface ITransferHistoryService
    {
        Task<IEnumerable<ReadTransferHistoryDTO?>> GetAllTransferHistoriesAsync();
        Task<ReadTransferHistoryDTO?> GetTransferHistoryByIdAsync(int transferHistoryID);
        Task<bool> CreateTransferHistoryAsync(CreateTransferHistoryDTO createTransferHistory);
        Task<bool> UpdateTransferHistoryAsync(UpdateTransferHistoryDTO transferHistory);
        Task<bool> DeleteTransferHistoryAsync(int transferHistoryID);
    }
}
