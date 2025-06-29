using Domain_BLL.DTOs.Country;
using Domain_BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        public CountryController(CountryService countryService)
        {
            _countryService= countryService;
        }
        [HttpGet("All",Name ="GetAllCountriesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IEnumerable<ReadCountryDTO>>> GetAllCountriesAsync()
        {
            var countries = await _countryService.GetAllCountiesAsync();
            if(countries is null || !countries.Any())
            {
                return NotFound();
            }
            return Ok(countries);
        }
    }
}
