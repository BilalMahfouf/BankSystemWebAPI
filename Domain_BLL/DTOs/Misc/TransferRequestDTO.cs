using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Misc
{
    public  class TransferRequestDTO
    {
        public int FromClientID { get; set; }
        public int ToClientID { get; set; }
        public DateTime TransferDate { get; set; }
        public decimal Amount { get; set; }
        public string ? Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public TransferRequestDTO(int fromClientID, int toClientID, DateTime transferDate
            , decimal amount, string? notes, int createdByUserID)
        {
            FromClientID = fromClientID;
            ToClientID = toClientID;
            TransferDate = transferDate;
            Amount = amount;
            Notes = notes;
            CreatedByUserID = createdByUserID;
        }
    }
}
