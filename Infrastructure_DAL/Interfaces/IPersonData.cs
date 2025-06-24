using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_DAL.Interfaces
{
    public interface IPersonData
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person>? FindByID(int PersonID);
        Task<int> AddNew(Person NewPerson);
        Task<bool> Update(int PersonID, Person Person);
        Task<bool> Delete(int PersonID);
    }
}
