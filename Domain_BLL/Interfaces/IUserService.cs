using Domain_BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Interfaces
{
    public  interface IUserService
    {
        Task<IEnumerable<ReadUserDTO>> GetAllUserNamesAsync();
        Task<ReadUserDTO?> FindUserByIDAsync(int userID);
        Task<bool> CreateUserAsync(CreateUserDTO newUserName);
        Task<bool> UpdateUserAsync(int userID, UpdateUserDTO updatedUserName);
        Task<bool> DeleteUserAsync(int userID);
    }
}
