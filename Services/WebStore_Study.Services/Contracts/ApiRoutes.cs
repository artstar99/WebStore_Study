using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore_Study.Services.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string root = "api";
        //public const string version = "v1";
        public const string baseRoute = root +"/";

        public static class Values
        {
            public const string Get = baseRoute +"/values";
        }
    }
}
