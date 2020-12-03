using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.ViewModels
{
    public class EmployeesViewModel
    {
      
        public int Id { get; set; }


        /// <summary> Имя </summary>
        [Required (ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        /// <summary> Фамилия </summary>
        [Required (ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }
        /// <summary> Отчество </summary>
        [Required (ErrorMessage = "Не указано отчество")]
        public string Patronymic { get; set; }
        /// <summary> Возраст </summary>
        public int Age { get; set; }
        
    }
}
