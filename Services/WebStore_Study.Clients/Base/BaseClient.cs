using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebStore_Study.Clients.Base
{
    public abstract class BaseClient
    {
        protected HttpClient Http { get; }
        public string Address { get; }

        protected BaseClient(IConfiguration configuration, string Address)
        {
            Http = new HttpClient
            {
                BaseAddress = new Uri(configuration["WebApiUrl"]),
                DefaultRequestHeaders =
                {
                    Accept = {new MediaTypeWithQualityHeaderValue("application/json")}
                }
            };
            this.Address = Address;
        }
    }
}
