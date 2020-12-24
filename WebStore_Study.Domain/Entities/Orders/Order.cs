using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore_Study.Domain.Entities.Base;

namespace WebStore_Study.Domain.Entities.Orders
{
   public class Order: NamedEntity
    {
        [Required]
        public User User { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Adress { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    }

   public class OrderItem : Entity
   {
       [Required]
       public Order Order { get; set; }
       
       [Required]
       public Product Product { get; set; }
       [Column(TypeName = "decimal(18,2)")]
       public decimal Price { get; set; }

        [Required]
        public  int Quantity { get; set; }
   }
}
