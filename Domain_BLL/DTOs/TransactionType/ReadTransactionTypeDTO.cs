using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.TransactionType
{
    public class ReadTransactionTypeDTO
    {
        public int TransactionTypeID { get; set; }

        public string TransactionName { get; set; } = null!;

        public decimal TransactionFees { get; set; }

        public string? TransactionDescription { get; set; }

        public ReadTransactionTypeDTO(int transactionTypeID, string transactionName
            , decimal transactionFees, string? transactionDescription)
        {
            TransactionTypeID = transactionTypeID;
            TransactionName = transactionName;
            TransactionFees = transactionFees;
            TransactionDescription = transactionDescription;
        }
    }
}
