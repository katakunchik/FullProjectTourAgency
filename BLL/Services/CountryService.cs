using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entities;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IEnumerable<CountryIndexViewModel> Countries()
        {
            var countries = _countryRepository.GetAllCountries()
                .Select(c => new CountryIndexViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DateCreate = c.DateCreate,
                    Priority = c.Priority
                });
            return countries.AsEnumerable();
        }

        public CountryStatusViewModel CountryCreate(CountryCreateViewModel createCountry)
        {
            var searchCountry = _countryRepository.GetCountryByName(createCountry.Name);
            if (searchCountry != null)
                return CountryStatusViewModel.Dublication;

            Country country = new Country
            {
                Name = createCountry.Name,
                Priority = createCountry.Priority,
                DateCreate = DateTime.Now
            };

            _countryRepository.Add(country);
            _countryRepository.SaveChange();
            return CountryStatusViewModel.Success;
        }

        public CountryStatusViewModel CountryEdit(CountryEditViewModel editCountry)
        {
            try
            {
                var searchCountry = _countryRepository.GetCountryByName(editCountry.Name);
                if (searchCountry != null && searchCountry.Id != editCountry.Id)
                    return CountryStatusViewModel.Dublication;
                var country = _countryRepository.GetCountryById(editCountry.Id);
                if(country != null)
                {
                    country.Name = editCountry.Name;
                    country.Priority = editCountry.Priority;
                    _countryRepository.SaveChange();
                    return CountryStatusViewModel.Success;
                }
            }
            catch { }
            return CountryStatusViewModel.Error;
        }

        public CountryEditViewModel GetCountryEditById(int id)
        {
            CountryEditViewModel model = null;
            var country = _countryRepository.GetCountryById(id);
            if (country != null)
            {
                model = new CountryEditViewModel
                {
                    Id = country.Id,
                    Name = country.Name,
                    Priority = country.Priority
                };
            }
            return model;
        }
    }
}
