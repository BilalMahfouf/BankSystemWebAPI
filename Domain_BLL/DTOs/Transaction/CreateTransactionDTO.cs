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
    public class CreateTransactionDTO
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

       

        public CreateTransactionDTO(int transactionID, int transactionTypeID, int clientID
            , decimal amount, DateTime transactionDate, byte transactionStatus
            , string? notes, int createdByUserID, int? transferID, DateTime createdAt
            , DateTime updatedAt)
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
        }
    }
}
