using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public interface IEmployeeData
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> FindByIDAsync(int EmployeeID);
        Task<int> AddNewAsync(Employee NewEmployee);
        Task<bool> UpdateAsync(Employee Employee);
        Task<bool> DeleteAsync(int EmployeeID);

        Task<bool> isExistByIDAsync(int personID);
    }
}
