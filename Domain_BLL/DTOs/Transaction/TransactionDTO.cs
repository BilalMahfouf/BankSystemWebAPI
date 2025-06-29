using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Transaction
{
    public class TransactionDTO
    {

        
        public int ClientID { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Notes { get; set; }

        public int CreatedByUserID { get; set; }

        public TransactionDTO( int clientID
            , decimal amount, DateTime transactionDate
            , string? notes, int createdByUserID)
        {
            ClientID = clientID;
            Amount = amount;
            TransactionDate = transactionDate;
            
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }
    }
}
