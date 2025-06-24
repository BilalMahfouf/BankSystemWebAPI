using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.JobTitle
{
    public  class ReadJobTitleDTO
    {
        public int JobID { get; set; }

        public string Title { get; set; } = null!;

        public ReadJobTitleDTO (int jobID, string title)
        {
            JobID = jobID;
            Title = title;
        }
    }
}
