using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services.Identity
{
    public interface IUsersClient :
        IUserRoleStore<User>,
        IUserClaimStore<User>,
        IUserPasswordStore<User>,
        IUserTwoFactorStore<User>,
        IUserEmailStore<User>,
        IUserPhoneNumberStore<User>,
        IUserLoginStore<User>,
        IUserLockoutStore<User>
    {
    }
}
