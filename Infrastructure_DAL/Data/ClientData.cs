using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{

    public class ClientData : IClientData
    {
        private readonly BankSystemDb3Context _context;
        public ClientData(BankSystemDb3Context context)
        {
            _context = context;
        }

        public async Task<bool> AddNewAsync(Client NewClient)
        {
            if(NewClient is null)
            {
                throw new ArgumentNullException(nameof(NewClient));
            }
           await _context.Clients.AddAsync(NewClient);
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<bool> DeleteAsync(int ClientID)
        {
             var client = await FindByIDAsync(ClientID);
            if(client is null) return false;

            _context.Clients.Remove(client);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<Client?> FindByIDAsync(int ClientID)
        {
            return await _context.Clients.Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.ClientID == ClientID);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c=>c.Person).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Client Client)
        {
            if(Client is null)
            {
                throw new ArgumentNullException(nameof(Client));
            }

            _context.Clients.Update(Client);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<decimal> GetBalanceAsync(int ClientID)
        {
            return await _context.Clients.Where(c=>c.ClientID==ClientID).Select(c => c.Balance).FirstOrDefaultAsync();
                
        }

    }
}
