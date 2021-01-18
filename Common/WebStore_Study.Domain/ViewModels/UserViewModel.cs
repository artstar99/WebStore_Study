using System.ComponentModel.DataAnnotations;

namespace WebStore_Study.Domain.ViewModels
{
    public class UsersViewModel
    {
      
        public string Id { get; set; }


        /// <summary> Имя </summary>
        [Required (ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        /// <summary> Фамилия </summary>
        [Required (ErrorMessage = "Не указана фамилия")]
        public string LastName { get; set; }

        public string Email { get; set; }
       
        /// <summary> Возраст </summary>
        public int Age { get; set; }
        
    }
}
