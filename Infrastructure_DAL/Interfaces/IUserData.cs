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
        Task<IEnumerable<User>> GetAllUsers();
        Task<User>? FindByID(int UserID);
        Task<int> AddNew(Client NewUser);
        Task<bool> Update(int UserID, User User);
        Task<bool> Delete(int UserID);
    }
}
