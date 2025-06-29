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
        Task<int> CreatePersonAsync(PersonDTO newPerson);
        Task<bool> UpdatePersonAsync(int personID,PersonDTO person);
        Task<bool> DeletePersonAsync(int personID);

    }
}
