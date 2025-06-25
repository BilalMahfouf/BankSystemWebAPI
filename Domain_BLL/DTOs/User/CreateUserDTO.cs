using Domain_BLL.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.User
{
    public  class CreateUserDTO
    {
        public int UserID { get; set; }

        public int EmployeeID { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Permissions { get; set; }

        public bool IsActive { get; set; }

       
     

        public CreateUserDTO(int userID, int employeeID, string userName, string password
            , int permissions, bool isActive)
        {
            UserID = userID;
            EmployeeID = employeeID;
            UserName = userName;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;
           
        }
    }
}
