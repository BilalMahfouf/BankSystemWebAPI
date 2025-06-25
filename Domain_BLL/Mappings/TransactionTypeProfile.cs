using AutoMapper;
using Domain_BLL.DTOs.TransactionType;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class TransactionTypeProfile:Profile
    {
        public TransactionTypeProfile()
        {
            CreateMap<TransactionType, ReadTransactionTypeDTO>();
        }
    }
}
