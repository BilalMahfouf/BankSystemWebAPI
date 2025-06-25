using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public  interface IUserData
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> FindByIDAsync(int UserID);
        Task<bool> AddNewAsync(User NewUser);
        Task<bool> UpdateAsync(User User);
        Task<bool> DeleteAsync(int UserID);
        Task<bool> isExistByIDAsync(int employeeID);
    }
}
