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
    public class UserData : IUserData
    {
        private readonly BankSystemDb3Context _context;
        public UserData(BankSystemDb3Context context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(User NewUser)
        {
            if (NewUser is null)
            {
                throw new ArgumentNullException(nameof(NewUser));
            }

            await _context.Users.AddAsync(NewUser);
            await _context.SaveChangesAsync();
            return NewUser.UserID;
        }

        public async Task<bool> DeleteAsync(int UserID)
        {
            var User = await _context.Users.FindAsync(UserID);
            if (User is null)
            {
                return false;
            }
            _context.Users.Remove(User);
            return await _context.SaveChangesAsync() > 0;
            
        }

        public async Task<User?> FindByIDAsync(int UserID)
        {
            return await _context.Users.Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.UserID == UserID);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UpdateAsync(User User)
        {
            if (User is null)
            {
                throw new ArgumentNullException(nameof(User));
            }

            _context.Users.Update(User);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> isExistByIDAsync(int employeeID)
        {
            return await _context.Users.AnyAsync(u => u.EmployeeID == employeeID);
        }
    }
}
