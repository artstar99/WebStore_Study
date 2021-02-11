using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore_Study.Services.Contracts.V1
{
    public static class ApiRoutes
    {
        public static class Version1
        {
            private const string v1 = "v1";

            public const string Values = "api" + v1 + "/values";

            public const string Products = "api" + v1 + "/products";

            public const string Orders = "api" + v1 + "/orders";

            public static class Identity
            {
                public const string User = "api" + v1 + "/users";
                public const string Role = "api" + v1 + "/roles";
            }
        }

    }
}
