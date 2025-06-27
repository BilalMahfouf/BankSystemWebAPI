using AutoMapper;
using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.Transaction;
using Domain_BLL.DTOs.TransferHistory;
using Domain_BLL.DTOs.User;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public  class TransferHistoryProfile:Profile
    {
        public TransferHistoryProfile()
        {
            CreateMap<TransferHistory, ReadTransferHistoryDTO>();
            CreateMap<Client, ReadClientDTO>();
            CreateMap<User, ReadUserDTO>();


            CreateMap<TransferHistoryDTO, TransferHistory>()
                  .ForMember(dest => dest.TransferID, opt => opt.Ignore())
               .ForMember(dest => dest.FromClient, opt => opt.Ignore())
               .ForMember(dest => dest.ToClient, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            
        }
    }
}
