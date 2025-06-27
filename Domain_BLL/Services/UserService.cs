using AutoMapper;
using Domain_BLL.DTOs.User;
using Domain_BLL.Interfaces;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class UserService:IUserService
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;

        public UserService(IUserData userData, IMapper mapper)
        {
            _userData = userData;
            _mapper = mapper;
        }

        public async Task<bool> ActivateUser(int userID)
        {
            if(userID < 0)
            {
                throw new ArgumentException(nameof(userID));    
            }
            var user = await _userData.FindByIDAsync(userID);
            if (user is null) return false;
            
            user.IsActive = true;
            user.UpdatedAt = DateTime.UtcNow;
            return await _userData.UpdateAsync(user);
        }

        public Task<bool> CanCreateUserAsync(int employeeID)
        {
            if(employeeID < 0)
            {
                throw new ArgumentNullException(nameof(employeeID));
            }
            return _userData.isExistByIDAsync(employeeID);
        }

        public async Task<bool> CreateUserAsync(UserDTO newUser)
        {
            if(newUser is null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }
            User NewUser = _mapper.Map<User>(newUser);
            NewUser.CreatedAt = DateTime.UtcNow;
            NewUser.UpdatedAt = DateTime.UtcNow;
            return await _userData.AddNewAsync(NewUser);
        }

        public async Task<bool> DeActivateUser(int userID)
        {
            if (userID < 0)
            {
                throw new ArgumentException(nameof(userID));
            }
            var user = await _userData.FindByIDAsync(userID);
            if (user is null) return false;

            user.IsActive = false;
            user.UpdatedAt = DateTime.UtcNow;
            return await _userData.UpdateAsync(user);
        }

        public async Task<bool> DeleteUserAsync(int userID)
        {
            if(userID < 0)
            {
                throw new ArgumentException(nameof(userID));
            }
            return await _userData.DeleteAsync(userID);
        }

        public async Task<ReadUserDTO?> FindUserByIDAsync(int userID)
        {
            if (userID < 0)
            {
                throw new ArgumentException(nameof(userID));
            }
            var User = await _userData.FindByIDAsync(userID);
            if (User is null) return null;

            var readUser = _mapper.Map<ReadUserDTO>(User);
            return readUser;
        }

        public async Task<IEnumerable<ReadUserDTO>> GetAllUserNamesAsync()
        {
            IEnumerable<User> users = await _userData.GetAllAsync();
            IEnumerable<ReadUserDTO> readUsers = _mapper.Map<IEnumerable<ReadUserDTO>>(users);
            return readUsers;
        }

        public async Task<bool> UpdateUserAsync(int userID, UserDTO userdto)
        {
           if(userID < 0)
            {
                throw new ArgumentException(nameof(userID));
            }
            var updatedUser = await _userData.FindByIDAsync(userID);
            if (updatedUser is null) return false;

            _mapper.Map(userdto, updatedUser);
            updatedUser.UserID = userID;
            updatedUser.UpdatedAt = DateTime.UtcNow;
            return await _userData.UpdateAsync(updatedUser);
        }
    }
}
