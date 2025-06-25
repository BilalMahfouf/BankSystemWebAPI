using AutoMapper;
using Domain_BLL.DTOs.Employee;
using Domain_BLL.DTOs.Transaction;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile() 
        {
            CreateMap<Transaction, ReadTransactionDTO>();

            CreateMap<TransactionDTO, Transaction>()
               .ForMember(dest => dest.TransactionID, opt => opt.Ignore())
               .ForMember(dest => dest.TransactionTypeID, opt => opt.Ignore())
               .ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionType, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

           
        }
    }
}
