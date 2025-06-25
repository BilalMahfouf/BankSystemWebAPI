using Domain_BLL.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.User
{
    public  class ReadUserDTO
    {
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        public string UserName { get; set; } = null!;

       

        public int Permissions { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

       public ReadEmployeeDTO Employee { get; set; }

        public ReadUserDTO(int userID, int employeeID, string userName
            , int permissions, bool isActive, DateTime createdAt, DateTime updatedAt
            , ReadEmployeeDTO employee)
        {
            UserID = userID;
            EmployeeID = employeeID;
            UserName = userName;
           
            Permissions = permissions;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Employee = employee;
        }
    }
}
