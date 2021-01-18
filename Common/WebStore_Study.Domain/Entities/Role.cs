
using Microsoft.AspNetCore.Identity;

namespace WebStore_Study.Domain.Entities
{
    public class Role : IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string User = "Users";

    }
}
