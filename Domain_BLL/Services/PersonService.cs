using AutoMapper;
using Domain_BLL.DTOs.Person;
using Domain_BLL.Interfaces;
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

        public async Task<bool> CreatePersonAsync(CreatePersonDTO newPerson)
        {
            if (newPerson is null)
            {
                throw new ArgumentNullException(nameof(newPerson), "New person data cannot be null.");
            }
            Person person = _mapper.Map<Person>(newPerson);
            return await _personData.AddNewAsync(person);
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

        public async Task<bool> UpdatePersonAsync(UpdatePersonDTO person)
        {
            if( person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            Person updatedPerson = _mapper.Map<Person>(person);
            return await _personData.UpdateAsync(updatedPerson);
        }
    }
}
