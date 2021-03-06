﻿using System.ComponentModel.DataAnnotations;

namespace WebStore_Study.Domain.ViewModels
{ 
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Необходимо указать E-mail")]
        [EmailAddress(ErrorMessage ="Некорректный адрес")]
        [Display(Name ="Ваш E-mail")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введите пароль")]
        public string Password { get; set; }
        

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage ="Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Необходимо указать имя")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Имя должно содержать не меньше 3 и не больше 20 букв")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Необходимо указать фамилию")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Фамилия должна содержать не меньше 3 и не больше 20 букв")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Необходимо указать возраст")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }


       


    }
}
