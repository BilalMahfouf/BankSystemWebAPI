using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.User
{
    public  class UserDTO
    {

        public int EmployeeID { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Permissions { get; set; }

        public bool IsActive { get; set; }




        public UserDTO( int employeeID, string userName, string password
            , int permissions, bool isActive)
        {
            EmployeeID = employeeID;
            UserName = userName;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;

        }
    }
}
