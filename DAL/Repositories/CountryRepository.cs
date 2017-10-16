using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IEFContext _context;
        public CountryRepository(IEFContext context)
        {
            _context = context;
        }

        public Country Add(Country country)
        {
            _context.Set<Country>().Add(country);
            return country;
        }

        public IQueryable<Country> GetAllCountries()
        {
            return _context.Set<Country>();
        }

        public Country GetCountryById(int id)
        {
            return GetAllCountries().SingleOrDefault(c => c.Id == id);
        }

        public Country GetCountryByName(string name)
        {
            return GetAllCountries().SingleOrDefault(c => c.Name == name);
        }

        public int countCountries()
        {
            return GetAllCountries().Count();
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
