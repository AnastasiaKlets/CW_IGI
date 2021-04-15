using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Не указано ФИО")]
        public string Fio { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Не указан возраст")]
        public int Age { get; set; }
    }
}
