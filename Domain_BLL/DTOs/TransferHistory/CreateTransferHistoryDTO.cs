using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.TransferHistory
{
    public class CreateTransferHistoryDTO
    {
        public int TransferID { get; set; }

        public int FromClientID { get; set; }

        public int ToClientID { get; set; }

        public DateTime TransferDate { get; set; }

        

        public int CreatedByUserID { get; set; }

       

        public CreateTransferHistoryDTO(int transferID, int fromClientID, int toClientID
            , DateTime transferDate, int createdByUserID)
        {
            TransferID = transferID;
            FromClientID = fromClientID;
            ToClientID = toClientID;
            TransferDate = transferDate;
            
            CreatedByUserID = createdByUserID;
        }
    }
}
