using Infrastructure_DAL.Interfaces;
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
    public class PersonData : IPersonData
    {
        private readonly BankSystemDb3Context _context;
        public PersonData(BankSystemDb3Context context)
        {
            _context = context;
        }

        public async Task<bool> AddNewAsync(Person NewPerson)
        {
            if (NewPerson is null)
            {
                throw new ArgumentNullException(nameof(NewPerson));
            }
            
            await _context.People.AddAsync(NewPerson);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int PersonID)
        {
            var Person = await _context.People.FindAsync(PersonID);
            if (Person is null) return false;

            _context.People.Remove(Person);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Person?> FindByIDAsync(int PersonID)
        {
            return await _context.People.Include(p => p.NationalityCountry)
                .FirstOrDefaultAsync(p => p.ID == PersonID);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.People.Include(p=>p.NationalityCountry).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            _context.People.Update(person);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
