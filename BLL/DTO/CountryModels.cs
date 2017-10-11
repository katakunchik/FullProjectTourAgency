using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CountryIndexViewModel
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
