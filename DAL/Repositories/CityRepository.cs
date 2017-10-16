using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IEFContext _context;
        public CityRepository(IEFContext context)
        {
            _context = context;
        }
        public City Add(City city)
        {
            _context.Set<City>().Add(city);
            return city;
        }

        public IQueryable<City> GetAllCities()
        {
            return _context.Set<City>().Include(c=>c.Country);
        }

        public City GetCityById(int id)
        {
            return GetAllCities().SingleOrDefault(c => c.Id == id);
        }

        public City GetCityByName(string name)
        {
            return GetAllCities().SingleOrDefault(c => c.Name == name);
        }
        public City GetCityInCountry(int countryId, string cityName)
        {
            return _context.Set<City>().SingleOrDefault(c => c.Name==cityName && c.CountryId == countryId);
        }
        public int countCities()
        {
            return GetAllCities().Count();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
    }
}
