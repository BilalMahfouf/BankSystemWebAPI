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
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> FindByIDAsync(int EmployeeID);
        Task<bool> AddNewAsync(Employee NewEmployee);
        Task<bool> UpdateAsync(Employee Employee);
        Task<bool> DeleteAsync(int EmployeeID);
    }
}
