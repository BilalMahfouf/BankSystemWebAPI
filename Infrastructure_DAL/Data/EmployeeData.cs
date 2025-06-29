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
    public class EmployeeData : IEmployeeData
    {
        private readonly BankSystemDb3Context _context;
        public EmployeeData(BankSystemDb3Context context)
        {
            _context = context;
        }

        public async Task<int> AddNewAsync(Employee NewEmployee)
        {
            if(NewEmployee is null)
            {
                throw new ArgumentNullException(nameof(NewEmployee));
            }
           await _context.Employees.AddAsync(NewEmployee);
            await _context.SaveChangesAsync();
            return NewEmployee.EmployeeID;
        }

        public async Task<bool> DeleteAsync(int EmployeeID)
        {
            var Employee = await FindByIDAsync(EmployeeID);
            if (Employee is null) return false;

            _context.Employees.Remove(Employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Employee?> FindByIDAsync(int EmployeeID)
        {
            return await _context.Employees.Include(e => e.Person).
                Include(e => e.CreatedByUser).Include(e => e.JobTitle)
                .FirstOrDefaultAsync(e => e.EmployeeID == EmployeeID);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Include(e => e.Person).Include(e => e.JobTitle)
                .Include(e => e.CreatedByUser).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Employee Employee)
        {
            if(Employee is null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }

            _context.Employees.Update(Employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> isExistByIDAsync(int personID)
        {
            return await _context.Employees.AnyAsync(e => e.PersonID == personID);
        }
    }
}
