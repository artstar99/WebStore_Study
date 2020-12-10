using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebStore_Study.Domain.Entities.Base;

namespace WebStore_Study.Domain.Entities
{
    public class Employee:Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        public int Age { get; set; }

    }
}
