using AutoMapper;
using Domain_BLL.DTOs.Country;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public  class CountryProfile:Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, ReadCountryDTO>();
        }
    }
}
