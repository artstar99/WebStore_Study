using Microsoft.AspNetCore.Identity;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services.Identity
{
    public interface IRolesClient : IRoleStore<Role> {}
}