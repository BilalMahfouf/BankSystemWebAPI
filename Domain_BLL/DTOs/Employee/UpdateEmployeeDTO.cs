using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Employee
{
    public class UpdateEmployeeDTO
    {
        public int? PersonID { get; set; }

        public int? JobTitleID { get; set; }

        public decimal? Salary { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? CreatedByUserID { get; set; }

      public UpdateEmployeeDTO(int ? personID, int? jobTitleID, decimal? salary
            , DateTime? hireDate, DateTime? createdAt, DateTime? updatedAt, int? createdByUserID)
        {
            PersonID = personID;
            JobTitleID = jobTitleID;
            Salary = salary;
            HireDate = hireDate;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedByUserID = createdByUserID;
        }

    }
}
