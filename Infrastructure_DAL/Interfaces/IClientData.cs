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
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client>? FindByID(int ClientID);
        Task<int> AddNew(Client NewClient);
        Task<bool> Update(int ClientID, Client Client);
        Task<bool> Delete(int ClientID);
    }
}
