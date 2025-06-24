using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using Infrastructure_DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Data
{
    public class PersonData : IPersonData
    {
        private readonly BankSystemDbContext _context;
        public PersonData(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Person NewPerson)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int PersonID)
        {
            throw new NotImplementedException();
        }

        public async Task<Person>? FindByIDAsync(int PersonID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int PersonID, Person Person)
        {
            throw new NotImplementedException();
        }
    }
}
