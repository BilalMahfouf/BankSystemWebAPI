using AutoMapper;
using Domain_BLL.DTOs.TransactionType;
using Infrastructure_DAL.Data;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class TransactionTypeService
    {
        private readonly IMapper _mapper;
        private readonly TransactionTypeData _transactionTypeData;

        public TransactionTypeService(TransactionTypeData transactionTypeData,IMapper mapper)
        {
            _transactionTypeData = transactionTypeData;
            _mapper = mapper;
        }

        public  async Task<IEnumerable<ReadTransactionTypeDTO>>GetAllTransactionTypesAsync()
        {
            IEnumerable<TransactionType> transactionTypes =
                await _transactionTypeData.GetAllTransactionTypesAsync();
            var readTransactionTypes = _mapper.Map<IEnumerable<ReadTransactionTypeDTO>>
                (transactionTypes);
            return readTransactionTypes;
        }
    }
}
