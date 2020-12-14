using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebStore_Study.ViewModels
{
    public class LoginViewModel
    {



        [Required]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить меня")]
        public bool RememberMe { get; set; }

        [HiddenInput(DisplayValue =false)]
        public string ReturnUrl { get; set; }
    }
}
