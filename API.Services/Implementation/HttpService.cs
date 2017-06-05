using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using APIServices.Exceptions;

namespace APIServices.Helpers
{
    public abstract class HttpService
    {
        protected string BaseUrl { get; set; }

        public string AuthToken { get; set;  }

        public HttpService()
        {

        }

        public async Task<string> Get(string relativeUri)
        {
            var handler = new HttpClientHandler();

            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Get, relativeUri);
            request.Headers.Add("Authorization", this.AuthToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }
            else
            {
                throw new UnsuccessfulQueryException(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<string> Post(string messageContent, string relativeUri)
        {
            var handler = new HttpClientHandler();

            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri)
            {
                Content = new StringContent(messageContent, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrEmpty(this.AuthToken))
            {
                request.Headers.Add("Authorization", this.AuthToken);

            }

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            
            if ((response.StatusCode == System.Net.HttpStatusCode.OK) || (response.StatusCode == System.Net.HttpStatusCode.Created))
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }
            else
            {
                throw new UnsuccessfulQueryException(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<string> Post(string relativeUri)
        {
            var handler = new HttpClientHandler();

            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Post, relativeUri);
            
            request.Headers.Add("Authorization", "Bearer " + this.AuthToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }
            else
            {
                throw new UnsuccessfulQueryException(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<string> Put(string messageContent, string relativeUri)
        {
            var handler = new HttpClientHandler();

            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Put, relativeUri)
            {
                Content = new StringContent(messageContent, Encoding.UTF8, "application/json")
            };
            
            request.Headers.Add("Authorization", this.AuthToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (!string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return "OK";
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }
            else
            {
                throw new UnsuccessfulQueryException(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<string> Delete(string relativeUri)
        {
            var handler = new HttpClientHandler();

            var _httpClient = new HttpClient(handler) { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Delete, relativeUri);
            request.Headers.Add("Authorization", this.AuthToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }
            else
            {
                throw new UnsuccessfulQueryException(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
