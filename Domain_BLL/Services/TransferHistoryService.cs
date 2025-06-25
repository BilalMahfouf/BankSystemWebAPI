using AutoMapper;
using Domain_BLL.DTOs.TransferHistory;
using Domain_BLL.Interfaces;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public  class TransferHistoryService:ITransferHistoryService
    {
        private readonly ITransferHistory _transferHistoryData;
        private readonly IMapper _mapper;

        public TransferHistoryService(ITransferHistory transferHistoryData, IMapper mapper)
        {
            _transferHistoryData = transferHistoryData;
            _mapper = mapper;
        }

        public async Task<bool> CreateTransferHistoryAsync(TransferHistoryDTO createTransferHistory)
        {
            if(createTransferHistory is null)
            {
                throw new ArgumentNullException(nameof(createTransferHistory));
            }
            TransferHistory newTransferHistory = _mapper
                .Map<TransferHistory>(createTransferHistory);

            newTransferHistory.CreatedAt = DateTime.Now.ToUniversalTime();
            newTransferHistory.UpdatedAt = DateTime.Now.ToUniversalTime();

            return await _transferHistoryData.AddNewAsync(newTransferHistory);
        }

        public Task<bool> DeleteTransferHistoryAsync(int transferHistoryID)
        {
            if(transferHistoryID < 0)
            {
                throw new ArgumentNullException($"{nameof(transferHistoryID)}.");
            }
            return _transferHistoryData.DeleteAsync(transferHistoryID);
        }

        public async Task<IEnumerable<ReadTransferHistoryDTO>> GetAllTransferHistoriesAsync()
        {
            IEnumerable<TransferHistory> transferHistories = await
                _transferHistoryData.GetAllAsync();
            IEnumerable<ReadTransferHistoryDTO> readTransferHistories =
                _mapper.Map<IEnumerable<ReadTransferHistoryDTO>>(transferHistories);

            return readTransferHistories;
        }

        public async Task<ReadTransferHistoryDTO?> GetTransferHistoryByIdAsync(int transferHistoryID)
        {
            if(transferHistoryID < 0)
            {
                throw new ArgumentNullException(nameof(transferHistoryID));
            }
            var transferHistory = await _transferHistoryData.FindByIDAsync(transferHistoryID);
            ReadTransferHistoryDTO readTransferHistory = _mapper
                .Map<ReadTransferHistoryDTO>(transferHistory);
            return readTransferHistory;
        }
    }
}
