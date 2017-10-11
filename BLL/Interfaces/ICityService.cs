using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICityService
    {
        CityStatusViewModel CityCreate(CityCreateViewModel createCity);
        IEnumerable<CityIndexViewModel> Cities();
        CityStatusViewModel CityEdit(CityEditViewModel editCity);
        CityEditViewModel GetCityEditById(int id);
    }
}
