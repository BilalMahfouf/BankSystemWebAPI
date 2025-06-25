using Domain_BLL.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<ReadEmployeeDTO>> GetAllEmployeesAsync();
        Task<ReadEmployeeDTO?> FindByIDAsync(int EmployeeID);
        Task<bool> CreateEmployeeAsync(EmployeeDTO NewEmployee);
        Task<bool> UpdateEmployeeAsync(int employeeID,EmployeeDTO Employee);
        Task<bool> DeleteEmployeeAsync(int EmployeeID);
        Task<bool> CanCreateEmployeeAsync(int personID);
    }
}
