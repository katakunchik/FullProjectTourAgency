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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        public CityService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }
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
                if(city != null)
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
            if(city != null)
            {
                model = new CityEditViewModel
                {
                    Id = city.Id,
                    Name= city.Name,
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
    }
}
