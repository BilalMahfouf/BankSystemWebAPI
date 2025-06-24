using Domain_BLL.DTOs.Client;
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
        Task<bool> CreateClientAsync(CreateClientDTO NewClient);
        Task<bool> UpdateClientAsync(UpdateClientDTO Client);
        Task<bool> DeleteClientAsync(int ClientID);
    }
}
