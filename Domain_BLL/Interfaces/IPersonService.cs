using Domain_BLL.DTOs.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Interfaces
{
    public  interface IPersonService
    {
        Task<IEnumerable<ReadPersonDTO>> GetAllPeopleAsync();
        Task<ReadPersonDTO?> FindPersonByIDAsync(int personID);
        Task<bool> CreatePersonAsync(CreatePersonDTO newPerson);
        Task<bool> UpdatePersonAsync(UpdatePersonDTO person);
        Task<bool> DeletePersonAsync(int personID);

    }
}
