using AutoMapper;
using Domain_BLL.DTOs.Client;
using Domain_BLL.Interfaces;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientData _clientData;
        private readonly IMapper _mapper;

        public ClientService(IClientData clientData,IMapper mapper)
        {
            _clientData = clientData;
            _mapper = mapper;
        }

        public async Task<bool> ActivateClient(int clientID)
        {
            Client? client = await _clientData.FindByIDAsync(clientID);
            if (client is null) return false;

            client.IsActive= true;
            client.UpdatedAt = DateTime.Now.ToUniversalTime();
            return await  _clientData.UpdateAsync(client);
        }
        public async Task<bool> DeActivateClient(int clientID)
        {
            Client? client = await _clientData.FindByIDAsync(clientID);
            if (client is null) return false;

            client.IsActive = false;
            client.UpdatedAt = DateTime.Now.ToUniversalTime();
            return await _clientData.UpdateAsync(client);
        }
        public async Task<bool> CreateClientAsync(ClientDTO NewClient)
        {
            if(NewClient is null)
            {
                throw new ArgumentNullException(nameof(NewClient));
            }
            Client newClient = _mapper.Map<Client>(NewClient);

            newClient.CreatedAt = DateTime.Now.ToUniversalTime();   
            newClient.UpdatedAt = DateTime.Now.ToUniversalTime();
            return await _clientData.AddNewAsync(newClient);
        }
        public Task<bool> DeleteClientAsync(int ClientID)
        {
            return _clientData.DeleteAsync(ClientID);
        }
        public async Task<ReadClientDTO?> FindClientByIDAsync(int ClientID)
        {
            Client? client = await _clientData.FindByIDAsync(ClientID);
            if (client is null) return null;

            ReadClientDTO clientDTO = _mapper.Map<ReadClientDTO>(client);
            return clientDTO;
        }

        public async Task<IEnumerable<ReadClientDTO>> GetAllClientsAsync()
        {
            IEnumerable<Client> clients = await _clientData.GetAllCAsync();
            IEnumerable<ReadClientDTO> readClients = _mapper
                .Map<IEnumerable<ReadClientDTO>>(clients);
            return readClients;
        }

        public async Task<bool> UpdateClientAsync(int clientID, ClientDTO Client)
        {
            if(Client is null)
            {
                throw new ArgumentNullException(nameof(Client));
            }
            Client client= _mapper.Map<Client>(Client);
            client.ClientID= clientID;

            client.UpdatedAt = DateTime.UtcNow.ToUniversalTime();
            return await _clientData.UpdateAsync(client);
        }

        public async Task<bool> CanWithdraw(int clientID,decimal amount)
        {
            return await _clientData.GetBalanceAsync(clientID) >= amount;
        }

    }
}
