using AutoMapper;
using Domain_BLL.DTOs.JobTitle;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Mappings
{
    public class JobTitleProfile:Profile
    {
        public JobTitleProfile()
        {
            CreateMap<JobTitle, ReadJobTitleDTO>();
        }
    }
}
