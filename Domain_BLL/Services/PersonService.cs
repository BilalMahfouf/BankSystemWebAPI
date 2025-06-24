using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class PersonService
    {
        private readonly IPersonData _personData;

        public PersonService(IPersonData personData)
        {
            _personData = personData;
        }
        public Task<IEnumerable<Person>> GetAllPeopleAsync()
        {
            return _personData.GetAllPeople();
        }
    }
}
