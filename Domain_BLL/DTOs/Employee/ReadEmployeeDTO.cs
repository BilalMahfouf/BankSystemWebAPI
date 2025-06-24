using Domain_BLL.DTOs.JobTitle;
using Domain_BLL.DTOs.Person;
using Domain_BLL.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Employee
{
    public class ReadEmployeeDTO
    {
        public int EmployeeID { get; set; }

        public int PersonID { get; set; }

        public int JobTitleID { get; set; }

        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CreatedByUserID { get; set; }

        public ReadPersonDTO Person { get; set; }
        public ReadJobTitleDTO JobTitle { get; set; }
        public ReadUserDTO CreatedByUser { get; set; }

        public ReadEmployeeDTO(int employeeID, int personID, int jobTitleID, decimal salary
            , DateTime hireDate, DateTime createdAt, DateTime updatedAt, int createdByUserID
            ,ReadPersonDTO person,ReadJobTitleDTO jobTitle,ReadUserDTO createdByUser)
        {
            EmployeeID = employeeID;
            PersonID = personID;
            JobTitleID = jobTitleID;
            Salary = salary;
            HireDate = hireDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedByUserID = createdByUserID;
            Person = person;
            JobTitle = jobTitle;
            CreatedByUser= createdByUser;

        }
    }
}
