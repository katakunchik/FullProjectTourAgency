using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CityIndexViewModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Дата створення")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Пріорітет")]
        public int Priority { get; set; }
        [Display(Name = "Країна")]
        public string Country { get; set; }
    }

    public class CityCreateViewModel
    {
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле є обов’язковим")]
        [Range(1,100,ErrorMessage = "Допустиме значення від 1 до 100")]
        [Display(Name = "Пріорітет")]
        public int Priority { get; set; }
        [Display(Name = "Країна")]
        public int CountryId { get; set; }
        public List<SelectItemViewModel> Countries { get; set; }
    }

    public class CityEditViewModel
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
        [Display(Name = "Країна")]
        public int CountryId { get; set; }
        public List<SelectItemViewModel> Countries { get; set; }
    }

    public enum CityStatusViewModel
    {
        Success = 0,
        CountryDublicate = 1,
        Error = 2
    }
}
