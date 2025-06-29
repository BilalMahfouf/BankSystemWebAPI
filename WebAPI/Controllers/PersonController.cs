using Domain_BLL.DTOs.Person;
using Domain_BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("All",Name ="GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReadPersonDTO>>> GetAllPeopleAsync()
        {
            var People = await _personService.GetAllPeopleAsync();
            if (People is null || !People.Any()) return NoContent(); 
            return Ok(People);
        }

        [HttpGet("{PersonID}",Name ="GetPersonByIDAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetPersonByIDAsync(int PersonID)
        {
            if(PersonID <= 0) return BadRequest();
            var Person= await _personService.FindPersonByIDAsync(PersonID);
            if(Person is null)
            {
                return NotFound();
            }
            return Ok(Person);
        }

        [HttpPost("Post",Name ="CreatePersonAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreatePersonAsync(PersonDTO person)
        {
            if (person is null)
            {
                return BadRequest();
            }
            var insertedID = await _personService.CreatePersonAsync(person);
            if (insertedID <= 0) return BadRequest();
            return CreatedAtRoute("GetPersonByIDAsync", new { PersonID = insertedID }
            , null);
        }

        [HttpPut("{personID}", Name = "UpdatePersonAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePersonAsync(int personID,PersonDTO person)
        {
            if (person is null)
            {
                return BadRequest();
            }
            if (await _personService.UpdatePersonAsync(personID, person)) 
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{personID}", Name = "DeletePersonAsync")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeletePersonAsync(int personID)
        {
            if (personID <= 0) return BadRequest();
            var result = await _personService.DeletePersonAsync(personID);
            return result ? NoContent() : Conflict();
        }


    }
}
