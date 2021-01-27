﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore_Study.Clients.Base;
using WebStore_Study.Services.Contracts.V1;

namespace WebStore_Study.Clients.Identity
{
    public class UsersClient : BaseClient
    {
        public UsersClient(IConfiguration configuration) : base(configuration, ApiRoutes.Identity.User)
        {
        }
    }
}
