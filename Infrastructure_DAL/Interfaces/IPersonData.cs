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
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> FindByIDAsync(int PersonID);
        Task<int> AddNewAsync(Person NewPerson);
        Task<bool> UpdateAsync(Person Person);
        Task<bool> DeleteAsync(int PersonID);
    }
}
