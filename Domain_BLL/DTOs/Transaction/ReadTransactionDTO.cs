using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.TransactionType;
using Domain_BLL.DTOs.TransferHistory;
using Domain_BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Transaction
{
    public class ReadTransactionDTO
    {
        public int TransactionID { get; set; }

        public int TransactionTypeID { get; set; }

        public int ClientID { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public byte TransactionStatus { get; set; }

        public string? Notes { get; set; }

        public int CreatedByUserID { get; set; }

        public int? TransferID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public  ReadClientDTO Client { get; set; } = null!;

        public  ReadUserDTO CreatedByUser { get; set; } = null!;

        public  ReadTransactionTypeDTO TransactionType { get; set; } = null!;

        public  ReadTransferHistoryDTO? Transfer { get; set; }

        public ReadTransactionDTO(int transactionID, int transactionTypeID, int clientID
            , decimal amount, DateTime transactionDate, byte transactionStatus
            , string? notes, int createdByUserID, int? transferID, DateTime createdAt
            , DateTime updatedAt, ReadClientDTO client, ReadUserDTO createdByUser
            , ReadTransactionTypeDTO transactionType, ReadTransferHistoryDTO? transfer)
        {
            TransactionID = transactionID;
            TransactionTypeID = transactionTypeID;
            ClientID = clientID;
            Amount = amount;
            TransactionDate = transactionDate;
            TransactionStatus = transactionStatus;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            TransferID = transferID;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Client = client;
            CreatedByUser = createdByUser;
            TransactionType = transactionType;
            Transfer = transfer;
        }
    }
}
