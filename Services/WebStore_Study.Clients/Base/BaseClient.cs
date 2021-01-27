using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStore_Study.Clients.Base
{
    public abstract class BaseClient:IDisposable
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

        #region GET
        protected T Get<T>(string url) => GetAsync<T>(url).Result;
        protected async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken=default)
        {
            var response = await Http.GetAsync(url, cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadAsAsync<T>(cancellationToken);
        }
        #endregion


        #region POST
        protected HttpResponseMessage Post<T>(string url, T item) => PostAsync(url, item).Result;
        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T item, CancellationToken cancellationToken = default)
        {
            
            var response = await Http.PostAsJsonAsync(url, item, cancellationToken);
            return response.EnsureSuccessStatusCode();
        }
        #endregion

        #region PUT
        protected HttpResponseMessage Put<T>(string url, T item) => PutAsync(url, item).Result;
        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken cancellationToken = default)
        {
            var response = await Http.PutAsJsonAsync(url, item, cancellationToken);
            return response.EnsureSuccessStatusCode();
        }
        #endregion

        #region DELETE
        protected HttpResponseMessage Delete(string url) => DeleteAsync(url).Result;
        protected async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            var response = await Http.DeleteAsync(url, cancellationToken);
            return response;
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose( bool disposing)
        {
            if (disposing)
            {
                //освобождение управляемых ресурсов
                Http.Dispose();
            }

            //освобождени е неуправляемых ресурсов
        }





    }
}
