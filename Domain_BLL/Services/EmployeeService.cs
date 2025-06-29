using AutoMapper;
using Domain_BLL.DTOs.Employee;
using Domain_BLL.Interfaces;
using Domain_BLL.Mappings;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public  class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeData _employeeData;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeData employeeData, IMapper mapper)
        {
            _employeeData = employeeData;
            _mapper = mapper;
        }

        public async Task<bool> CanCreateEmployeeAsync(int personID)
        {
           return !(await _employeeData.isExistByIDAsync(personID));
        }

        public async Task<int> CreateEmployeeAsync(EmployeeDTO NewEmployee)
        {
            if (NewEmployee == null)
            {
                throw new ArgumentNullException(nameof(NewEmployee));
            }

            bool canCreateEmployee = await CanCreateEmployeeAsync(NewEmployee.PersonID);
            if (!canCreateEmployee) return 0;


            Employee newEmployee = _mapper.Map<Employee>(NewEmployee);

            newEmployee.CreatedAt = DateTime.Now.ToUniversalTime();
            newEmployee.UpdatedAt = DateTime.Now.ToUniversalTime();
            var insertedID = await _employeeData.AddNewAsync(newEmployee);
            return insertedID;
        }

        public Task<bool> DeleteEmployeeAsync(int EmployeeID)
        {
          return _employeeData.DeleteAsync(EmployeeID);
        }

        public async Task<ReadEmployeeDTO?> FindByIDAsync(int EmployeeID)
        {
            Employee? employee = await _employeeData.FindByIDAsync(EmployeeID);
            if (employee == null) return null;

            ReadEmployeeDTO readEmployee = _mapper.Map<ReadEmployeeDTO>(employee);
            return readEmployee;
        }

        public async Task<IEnumerable<ReadEmployeeDTO>> GetAllEmployeesAsync()
        {
            IEnumerable<Employee> employees = await _employeeData.GetAllAsync();
            
                IEnumerable<ReadEmployeeDTO> readEmployees = _mapper
                .Map<IEnumerable<ReadEmployeeDTO>>(employees);
                return readEmployees;
        }

        public async Task<bool> UpdateEmployeeAsync(int employeeID,EmployeeDTO Employee)
        {
            if (Employee == null) 
            { 
                throw new ArgumentNullException(nameof(Employee)); 
            }
            var updatedEmployee=await _employeeData.FindByIDAsync(employeeID);
            if (updatedEmployee is null) return false;

            _mapper.Map(Employee, updatedEmployee);
            updatedEmployee.EmployeeID = employeeID;
            updatedEmployee.UpdatedAt = DateTime.Now.ToUniversalTime();
            return await _employeeData.UpdateAsync(updatedEmployee);
        }
    }
}
