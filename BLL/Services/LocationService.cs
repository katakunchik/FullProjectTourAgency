using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LocationService: ILocationService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        public LocationService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        #region CountryPart

        public CountryIndexViewModel Countries(int page, int itemsOnPage, CountrySearchViewModel search)
        {
            int pageNumber = page - 1;

            var query = _countryRepository.GetAllCountries();

            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(q => q.Name.Contains(search.Name));
            }

            if(!string.IsNullOrEmpty(search.Priority))
            {
                int priority;
                int.TryParse(search.Priority, out priority);
                query = query.Where(q => q.Priority == priority);
            }
            
            var model = new CountryIndexViewModel();
            model.Countries = query
                .OrderBy(c => c.Id)
                .Skip(itemsOnPage * pageNumber)
                .Take(itemsOnPage)
                .Select(c => new CountryItemViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DateCreate = c.DateCreate,
                    Priority = c.Priority
                });

            int count = _countryRepository.countCountries();
            model.TotalPages = (int)Math.Ceiling((double)count / itemsOnPage);
            model.CurrentPage = page;
            model.itemsOnPage = itemsOnPage;
            model.Search = search;

            return model;
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
                if (country != null)
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

        #endregion

        #region CityPart

        public IEnumerable<CityIndexViewModel> Cities()
        {
            var cities = _cityRepository.GetAllCities()
                .Select(c => new CityIndexViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    DateCreate = c.DateCreate,
                    Priority = c.Priority,
                    Country = c.Country.Name
                });
            return cities.AsEnumerable();
        }

        public CityStatusViewModel CityCreate(CityCreateViewModel createCity)
        {
            var searchCity = _cityRepository.GetCityInCountry(createCity.CountryId, createCity.Name);
            if (searchCity != null)
                return CityStatusViewModel.CountryDublicate;
            var city = new City
            {
                Name = createCity.Name,
                Priority = createCity.Priority,
                DateCreate = DateTime.Now,
                CountryId = createCity.CountryId
            };

            _cityRepository.Add(city);
            _cityRepository.SaveChange();
            return CityStatusViewModel.Success;
        }

        public CityStatusViewModel CityEdit(CityEditViewModel editCity)
        {
            try
            {
                var searchCity = _cityRepository.GetCityInCountry(editCity.CountryId, editCity.Name);
                if (searchCity != null)
                    return CityStatusViewModel.CountryDublicate;
                var city = _cityRepository.GetCityById(editCity.Id);
                if (city != null)
                {
                    city.Name = editCity.Name;
                    city.Priority = editCity.Priority;
                    city.CountryId = editCity.CountryId;
                    _cityRepository.SaveChange();
                    return CityStatusViewModel.Success;
                }
            }
            catch { }
            return CityStatusViewModel.Error;
        }

        public CityEditViewModel GetCityEditById(int id)
        {
            CityEditViewModel model = null;
            var city = _cityRepository.GetCityById(id);
            if (city != null)
            {
                model = new CityEditViewModel
                {
                    Id = city.Id,
                    Name = city.Name,
                    Priority = city.Priority,
                    CountryId = city.CountryId,
                    Countries = _countryRepository.GetAllCountries()
                    .Select(c => new SelectItemViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList()
                };
            }
            return model;
        }

        #endregion
    }
}
