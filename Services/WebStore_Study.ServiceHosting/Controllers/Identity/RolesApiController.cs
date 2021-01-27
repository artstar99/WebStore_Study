using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Services.Contracts.V1;

namespace WebStore_Study.ServiceHosting.Controllers.Identity
{
    [Route(ApiRoutes.Identity.Role)]
    [ApiController]
    public class RolesApiController : ControllerBase
    {
        private readonly RoleStore<Role> roleStore;
        public RolesApiController(WebStore_StudyDb db)
        {
            roleStore = new RoleStore<Role>(db);
        }
    }
}
