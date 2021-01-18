using System.ComponentModel.DataAnnotations;

namespace WebStore_Study.Domain.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required][DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
