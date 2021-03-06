﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore_Study.Interfaces.Contracts
{
    public static class ApiRoutes
    {


        public static class Version1
        {
            //Новый коммит
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