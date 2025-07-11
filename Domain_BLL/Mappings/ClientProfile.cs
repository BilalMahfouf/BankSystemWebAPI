﻿using AutoMapper;
using Domain_BLL.DTOs.Client;
using Domain_BLL.DTOs.Country;
using Domain_BLL.DTOs.Person;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ReadClientDTO>();
            CreateMap<Person, ReadPersonDTO>();
            CreateMap<Country, ReadCountryDTO>();
          
            CreateMap<ClientDTO, Client>()
                .ForMember(dest => dest.ClientID, opt => opt.Ignore())
          .ForMember(dest => dest.Person, opt => opt.Ignore())
          .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
          .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
