using AutoMapper;
using Domain_BLL.DTOs.Person;
using Domain_BLL.Interfaces;
using Infrastructure_DAL.Data;
using Infrastructure_DAL.Interfaces;
using Infrastructure_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class PersonService:IPersonService
    {
        private readonly IPersonData _personData;
        private readonly IMapper _mapper;

        public PersonService(IPersonData personData,IMapper mapper)
        {
            _personData = personData;
            _mapper = mapper;
        }

        public async Task<int> CreatePersonAsync(PersonDTO newPerson)
        {
            if (newPerson is null)
            {
                throw new ArgumentNullException(nameof(newPerson), "New person data cannot be null.");
            }
            Person person = _mapper.Map<Person>(newPerson);

            person.CreatedAt = DateTime.Now.ToUniversalTime();
            person.UpdatedAt = DateTime.Now.ToUniversalTime();
            int insertedID = await _personData.AddNewAsync(person);
            return insertedID;
        }
        

        public async Task<bool> DeletePersonAsync(int personID)
        {
            return await _personData.DeleteAsync(personID);
        }

        public async Task<ReadPersonDTO?> FindPersonByIDAsync(int personID)
        {
            Person? person = await _personData.FindByIDAsync(personID);
            ReadPersonDTO? readPerson = _mapper.Map<ReadPersonDTO?>(person);
            return readPerson;
        }

        public async Task<IEnumerable<ReadPersonDTO>> GetAllPeopleAsync()
        {
            IEnumerable<Person> people = await _personData.GetAllAsync();
            IEnumerable<ReadPersonDTO> readPeople = _mapper.Map
                <IEnumerable<ReadPersonDTO>>(people);
            return readPeople;
        }

        public async Task<bool> UpdatePersonAsync(int personID, PersonDTO person)
        {
            if( person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            // ✅ Step 1: Get the existing tracked entity
            var existingPerson = await _personData.FindByIDAsync(personID);
            if (existingPerson is null) return false;

            // ✅ Step 2: Apply changes to the tracked instance (in-place)
            _mapper.Map(person, existingPerson);

            // ✅ Step 3: Update timestamp
            existingPerson.UpdatedAt = DateTime.UtcNow;

            // ✅ Step 4: Save — no need for .Update()
            return await _personData.UpdateAsync(existingPerson);
        }
    }
}
