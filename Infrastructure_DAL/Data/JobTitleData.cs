using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{
    public class JobTitleData
    {
        private readonly BankSystemDbContext _context;
        public JobTitleData(BankSystemDbContext contex) 
        { 
        _context=contex;
        }

        public async Task<IEnumerable<JobTitle>> GetAllJobTitles()
        {
            return await _context.JobTitles.ToListAsync();
        }
    }
}
