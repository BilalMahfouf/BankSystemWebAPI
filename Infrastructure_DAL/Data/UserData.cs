using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{
    public class UserData : IUserData
    {
        private readonly BankSystemDbContext _context;
        public UserData(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Client NewUser)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<User>? FindByIDAsync(int UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int UserID, User User)
        {
            throw new NotImplementedException();
        }
    }
}
