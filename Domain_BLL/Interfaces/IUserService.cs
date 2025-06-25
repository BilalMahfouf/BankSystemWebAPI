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
        Task<bool> CreateUserAsync(UserDTO newUserName);
        Task<bool> UpdateUserAsync(int userID, UserDTO updatedUserName);
        Task<bool> DeleteUserAsync(int userID);
        Task<bool> CanCreateUserAsync(int employeeID);
        Task<bool> ActivateUser(int userID);
        Task<bool> DeActivateUser(int userID);

    }
}
