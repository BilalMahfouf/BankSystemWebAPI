using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.TransferHistory
{
    public class UpdateTransferHistoryDTO
    {
        public int? FromClientID { get; set; }

        public int? ToClientID { get; set; }

        public DateTime? TransferDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? CreatedByUserID { get; set; }



        public UpdateTransferHistoryDTO( int? fromClientID, int? toClientID
            , DateTime? transferDate, DateTime? createdAt, DateTime? updatedAt
            , int? createdByUserID)
        {
           
            FromClientID = fromClientID;
            ToClientID = toClientID;
            TransferDate = transferDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedByUserID = createdByUserID;
        }
    }
}
