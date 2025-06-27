using AutoMapper;
using Domain_BLL.DTOs.TransferHistory;
using Domain_BLL.DTOs.User;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public  class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, ReadUserDTO>();

            CreateMap<UserDTO, User>()
              .ForMember(dest => dest.UserID, opt => opt.Ignore())
              .ForMember(dest => dest.Employee, opt => opt.Ignore())
              .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
              .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
