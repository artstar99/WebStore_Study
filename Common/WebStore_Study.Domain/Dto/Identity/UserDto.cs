using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Domain.Dto.Identity
{
    //для коммита
    public abstract class UserDto
    {
        public User User { get; set; }
    }
    public class AddLoginDto:UserDto
    {
        public UserLoginInfo UserLoginInfo { get; set; }
    }

    public class PasswordHashDto : UserDto
    {
        public string Hash { get; set; }
    }
    public class AddClaimsDto : UserDto
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class RemoveClaimsDto:UserDto
    {
      public IEnumerable<Claim> Claims { get; set; }
    }
    public class ReplaceClaimsDto:UserDto
    {
       public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }
    }

    public class SetLockoutDto:UserDto
    {
        public DateTimeOffset? LockoutEnd { get; set; }
    }




}
