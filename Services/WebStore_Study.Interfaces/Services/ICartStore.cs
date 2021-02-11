using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
