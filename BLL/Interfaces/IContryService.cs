using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        CountryStatusViewModel CountryCreate(CountryCreateViewModel createCountry);
        IEnumerable<CountryIndexViewModel> Countries();
        CountryStatusViewModel CountryEdit(CountryEditViewModel editCountry);
        CountryEditViewModel GetCountryEditById(int id);
    }
}
