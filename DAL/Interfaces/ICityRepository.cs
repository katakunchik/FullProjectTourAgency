using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICityRepository : IDisposable
    {
        City Add(City city);
        IQueryable<City> GetAllCities();
        City GetCityByName(string name);
        City GetCityById(int id);
        City GetCityInCountry(int countryId, string cityName);
        void SaveChange();
    }
}
