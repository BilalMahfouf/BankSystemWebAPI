using AutoMapper;
using Domain_BLL.DTOs.Country;
using Domain_BLL.DTOs.Person;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class PersonProfile:Profile
    {
       public PersonProfile()
        {
            CreateMap<Person, ReadPersonDTO>();
            
            CreateMap<PersonDTO, Person>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.NationalityCountry, opt => opt.Ignore())
                .ForMember(dest=>dest.CreatedAt,opt=>opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<ReadPersonDTO, PersonDTO>();

        }
    }
}
