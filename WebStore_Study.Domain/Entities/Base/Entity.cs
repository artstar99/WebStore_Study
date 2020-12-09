using System;
using System.Collections.Generic;
using System.Text;
using WebStore_Study.Domain.Entities.Base.Interfaces;

namespace WebStore_Study.Domain.Entities.Base
{
    public abstract class Entity : IEntity
    {
       public int Id { get; set; }
    }
}
