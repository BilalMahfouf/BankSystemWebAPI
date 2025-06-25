using AutoMapper;
using Domain_BLL.DTOs.Country;
using Domain_BLL.DTOs.JobTitle;
using Infrastructure_DAL.Data;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class JobTitleService
    {
        private readonly JobTitleData _jobTitleData;
        private readonly IMapper _mapper;

        public JobTitleService(JobTitleData jobTitleData, IMapper mapper)
        {
            _jobTitleData = jobTitleData;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadJobTitleDTO>> GetAllCountiesAsync()
        {
            IEnumerable<JobTitle> jobs = await _jobTitleData.GetAllJobTitlesAsync();

            var readJobTitles= _mapper.Map<IEnumerable<ReadJobTitleDTO>>(jobs);
            return readJobTitles;
        }
    }
}
