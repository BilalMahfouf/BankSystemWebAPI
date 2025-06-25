using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public interface IClientData
    {
        Task<IEnumerable<Client>> GetAllCAsync();
        Task<Client?> FindByIDAsync(int ClientID);
        Task<bool> AddNewAsync(Client NewClient);
        Task<bool> UpdateAsync(Client Client);
        Task<bool> DeleteAsync(int ClientID);
        Task<decimal> GetBalanceAsync(int ClientID);
    }
}
