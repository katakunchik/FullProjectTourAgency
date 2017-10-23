using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CountryItemViewModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Дата створення")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Пріорітет")]
        public int Priority { get; set; }
    }
    public class CountryIndexViewModel
    {
        public IEnumerable<CountryItemViewModel> Countries { get; set; }
        public int TotalPages { get; set; }
        public int  CurrentPage { get; set; }
        [Display(Name = "К-сть об’єктів на сторінці")]
        [Range(1, short.MaxValue)]
        public int itemsOnPage { get; set; }
        public CountrySearchViewModel Search { get; set; }
    }

    public class CountrySearchViewModel
    {
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Пріорітет")]
        public string Priority { get; set; }
    }

    public class CountryCreateViewModel
    {
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Range(1, 100, ErrorMessage = "Допустиме значення від 1 до 100")]
        [Display(Name = "Пріорітет")]
        public int Priority { get; set; }
    }
    public class CountryEditViewModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Range(1, 100, ErrorMessage = "Допустиме значення від 1 до 100")]
        [Display(Name = "Пріорітет")]
        public int Priority { get; set; }
    }

    public enum CountryStatusViewModel
    {
        Success = 0,
        Dublication = 1,
        Error = 2
    }
}
