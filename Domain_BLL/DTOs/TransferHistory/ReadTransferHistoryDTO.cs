using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.User;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.TransferHistory
{
    public class ReadTransferHistoryDTO
    {
        public int TransferID { get; set; }

        public int FromClientID { get; set; }

        public int ToClientID { get; set; }

        public DateTime TransferDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CreatedByUserID { get; set; }

        public  ReadUserDTO CreatedByUser { get; set; } = null!;

        public  ReadClientDTO FromClient { get; set; } = null!;

        public  ReadClientDTO ToClient { get; set; } = null!;

        public ReadTransferHistoryDTO(int transferID, int fromClientID, int toClientID
            , DateTime transferDate, DateTime createdAt, DateTime updatedAt
            , int createdByUserID, ReadUserDTO createdByUser, ReadClientDTO fromClient
            , ReadClientDTO toClient)
        {
            TransferID = transferID;
            FromClientID = fromClientID;
            ToClientID = toClientID;
            TransferDate = transferDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedByUserID = createdByUserID;
            CreatedByUser = createdByUser;
            FromClient = fromClient;
            ToClient = toClient;
        }
    }
}
