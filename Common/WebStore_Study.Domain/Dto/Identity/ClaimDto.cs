using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebStore_Study.Domain.Dto.Identity
{
    public abstract class ClaimDto : UserDto
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
    public class AddClaimDto:ClaimDto { }
    public class RemoveClaimDto : ClaimDto { }

    public class ReplaceClaimDto : UserDto
    {
        public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }
    }
}
