using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Employee
{
    public class CreateEmployeeDTO
    {
        public int EmployeeID { get; set; }

        public int PersonID { get; set; }

        public int JobTitleID { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

       

        public int CreatedByUserID { get; set; }

       public CreateEmployeeDTO(int employeeID, int personID, int jobTitleID, decimal salary
           , DateTime hireDate, int createdByUserID)
        {
            EmployeeID = employeeID;
            PersonID = personID;
            JobTitleID = jobTitleID;
            Salary = salary;
            HireDate = hireDate;
           
            CreatedByUserID = createdByUserID;
        }
    }
}
