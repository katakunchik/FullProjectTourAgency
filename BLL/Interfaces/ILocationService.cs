using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILocationService
    {
        #region CountryPart

        CountryStatusViewModel CountryCreate(CountryCreateViewModel createCountry);
        IEnumerable<CountryIndexViewModel> Countries();
        CountryStatusViewModel CountryEdit(CountryEditViewModel editCountry);
        CountryEditViewModel GetCountryEditById(int id);

        #endregion

        #region CityPart

        CityStatusViewModel CityCreate(CityCreateViewModel createCity);
        IEnumerable<CityIndexViewModel> Cities();
        CityStatusViewModel CityEdit(CityEditViewModel editCity);
        CityEditViewModel GetCityEditById(int id);

        #endregion
    }
}
