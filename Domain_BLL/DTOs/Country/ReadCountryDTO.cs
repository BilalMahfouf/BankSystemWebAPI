using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.DTOs.Country
{
    public  class ReadCountryDTO
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public ReadCountryDTO(int  ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
