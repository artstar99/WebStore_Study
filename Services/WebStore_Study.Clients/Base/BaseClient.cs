using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebStore_Study.Clients.Base
{
    public abstract class BaseClient
    {
        protected HttpClient Http { get; }
        public string Address { get; }

        protected BaseClient(HttpClient client, string Address )
        {
            Http = client;
            this.Address = Address;
        }
    }
}
