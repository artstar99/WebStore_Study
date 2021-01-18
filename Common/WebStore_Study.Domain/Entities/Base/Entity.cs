using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
    }
}
