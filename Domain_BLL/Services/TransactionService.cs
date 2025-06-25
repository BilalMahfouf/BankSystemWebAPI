using AutoMapper;
using Domain_BLL.DTOs.Misc;
using Domain_BLL.DTOs.Transaction;
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
    public class TransactionService:ITransactionService
    {

        private readonly ITransactionData _transactionData;
        private readonly IMapper _mapper;
        private readonly ITransferHistoryService _transferHistoryService;
        private readonly IClientService _clientService;

        private enum enTransactionType { eDeposit=1,eWithdraw=2,eTransfer=3}
        
        
        public TransactionService(ITransactionData transactionData, IMapper mapper
            ,ITransferHistoryService transferHistory,IClientService clientService)
        {
            _transactionData = transactionData;
            _mapper = mapper;
            _transferHistoryService = transferHistory;
            _clientService = clientService;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionID)
        {
            return await _transactionData.DeleteAsync(transactionID);
        }

        public async Task<bool> Deposit(TransactionDTO transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            Transaction deposit = _mapper.Map<Transaction>(transaction);
            // 1 is accepted
            deposit.TransactionStatus = 1;
            deposit.TransactionTypeID = Convert.ToInt32(enTransactionType.eDeposit);
            deposit.CreatedAt = DateTime.UtcNow;
            deposit.UpdatedAt= DateTime.UtcNow;

            return await  _transactionData.AddNewAsync(deposit);
        }

        public async Task<IEnumerable<ReadTransactionDTO>> GetAllTransactionsAsync()
        {
            IEnumerable<Transaction> transactions = await _transactionData.GetAllAsync();
            IEnumerable<ReadTransactionDTO> readTransactions = _mapper
                .Map<IEnumerable<ReadTransactionDTO>>(transactions);
            return readTransactions;
        }

        public async Task<ReadTransactionDTO?> GetTransactionByIdAsync(int transactionID)
        {
            if(transactionID < 0)
            {
                throw new ArgumentNullException(nameof(transactionID));
            }
            var transaction=await _transactionData.FindByIDAsync(transactionID);
            ReadTransactionDTO readTransaction = _mapper
                .Map<ReadTransactionDTO>(transaction);
            return readTransaction;
        
        }
        
        public async Task<bool> TransferAsync(TransferRequestDTO transferRequest)
        {
           if(transferRequest is null)
            {
                throw new ArgumentNullException(nameof(transferRequest));
            }
            // 1. Withdraw from source
            TransactionDTO withdrawDTO = new(transferRequest.FromClientID, transferRequest.Amount
                , transferRequest.TransferDate, transferRequest.Notes, transferRequest.CreatedByUserID, null);
            bool IsWithdraw = await Withdraw(withdrawDTO);
            if (!IsWithdraw) return false;

            // 2. Deposit to destination 
            TransactionDTO depositDTO = new TransactionDTO(transferRequest.ToClientID
                , transferRequest.Amount, transferRequest.TransferDate
                , transferRequest.Notes, transferRequest.CreatedByUserID, null);
            bool IsDeposit = await Deposit(depositDTO);
            if (!IsDeposit) return false;

            // 3. Log transfer history
            TransferHistoryDTO transferHistory = new TransferHistoryDTO
                (transferRequest.FromClientID, transferRequest.ToClientID
                , transferRequest.TransferDate, transferRequest.CreatedByUserID);
            return await _transferHistoryService.CreateTransferHistoryAsync(transferHistory);
        }

        public async Task<bool> Withdraw(TransactionDTO transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            if (!(await _clientService.CanWithdraw(transaction.ClientID, transaction.Amount)))
            {
                return false;
            }
            
            Transaction withdraw = _mapper.Map<Transaction>(transaction);
            // 1 is accepted
            withdraw.TransactionStatus = 1;
            withdraw.TransactionTypeID = Convert.ToInt32(enTransactionType.eWithdraw);
            withdraw.CreatedAt = DateTime.UtcNow;
            withdraw.UpdatedAt = DateTime.UtcNow;

            return await _transactionData.AddNewAsync(withdraw);
        }
    }

    }

