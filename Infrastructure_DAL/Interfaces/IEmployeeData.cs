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
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee>? FindByID(int EmployeeID);
        Task<int> AddNew(Employee NewEmployee);
        Task<bool> Update(int EmployeeID, Employee Employee);
        Task<bool> Delete(int EmployeeID);
    }
}
