using AutoMapper;
using Domain_BLL.DTOs.Country;
using Infrastructure_DAL.Data;
using Infrastructure_DAL.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_BLL.Services
{
    public class CountryService
    {
        private readonly CountryData _countryData;
        private readonly IMapper _mapper;

        public CountryService(CountryData countryData, IMapper mapper)
        {
            _countryData = countryData;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadCountryDTO>>GetAllCountiesAsync()
        {
            IEnumerable<Country> countries = await _countryData.GetAllCountriesAsync();

            var readCountries = _mapper.Map<IEnumerable<ReadCountryDTO>>(countries);
            return readCountries;
        }
    }
}
