using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.User
{
    public  class UpdateUserDTO
    {
        public int? EmployeeID { get; set; }

        public string? UserName { get; set; } 

        public string? Password { get; set; } 

        public int? Permissions { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }



        public UpdateUserDTO( int employeeID, string userName, string password
            , int permissions, bool isActive, DateTime createdAt, DateTime updatedAt)
        {
            EmployeeID = employeeID;
            UserName = userName;
            Password = password;
            Permissions = permissions;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
