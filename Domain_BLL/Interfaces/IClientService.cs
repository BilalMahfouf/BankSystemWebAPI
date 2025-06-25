using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.Transaction;
using Domain_BLL.DTOs.TransferHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Interfaces
{
    public  interface IClientService
    {
        Task<IEnumerable<ReadClientDTO>> GetAllClientsAsync();
        Task<ReadClientDTO?> FindClientByIDAsync(int ClientID);
        Task<bool> CreateClientAsync(ClientDTO NewClient);
        Task<bool> UpdateClientAsync(int clientID,ClientDTO Client);
        Task<bool> DeleteClientAsync(int ClientID);
        Task<bool> ActivateClient(int clientID);
        Task<bool> DeActivateClient(int clientID);

        Task<bool> CanWithdraw(int clientID, decimal amount);
        

    }
}
