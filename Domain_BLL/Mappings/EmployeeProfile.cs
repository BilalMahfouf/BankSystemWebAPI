using AutoMapper;
using Domain_BLL.DTOs.Employee;
using Domain_BLL.DTOs.JobTitle;
using Domain_BLL.DTOs.Person;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<Employee, ReadEmployeeDTO>();
            CreateMap<Person, ReadPersonDTO>();
            CreateMap<JobTitle, ReadJobTitleDTO>();
           
            CreateMap<EmployeeDTO, Employee>()
               .ForMember(dest => dest.EmployeeID, opt => opt.Ignore())
               .ForMember(dest => dest.Person, opt => opt.Ignore())
                .ForMember(dest => dest.JobTitle, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            
        }
    }
}
