using ComplaintLoggingSystem.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComplaintLoggingSystem.Services
{
    public class ServiceAgent
    {
        IHttpClientFactory _httpClientFactory;
        HttpClient _httpClient;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly string _TodoListScope = string.Empty;
        private readonly string _TodoListBaseAddress = string.Empty;

        public ServiceAgent(IHttpClientFactory httpClientFactory, ITokenAcquisition tokenAcquisition, IConfiguration configuration, string clientName = "")
        {
            _httpClientFactory = httpClientFactory;
            this._tokenAcquisition = tokenAcquisition;
            this._TodoListScope = configuration["TodoList:TodoList"];
            this._TodoListBaseAddress = configuration["TodoList:TodoListBaseAddress"];
            switch (clientName)
            {
                case UserConstants.CORELIBRARYHTTPCLIENT:
                    this._httpClient = GetHttpClient();
                    break;

                default:
                    this._httpClient = GetHttpClient();
                    break;

            }

        }

        public async Task<T> GetData<T>(string Url)
        {
            await PrepareAuthenticatedClient();

            if (Url.Contains("?"))
            {
                if (Url.Contains("&"))
                {
                    Url = Url.Split(new string[] { "?" }, StringSplitOptions.None)[0] + "?" + Url.Split(new string[] { "?" }, StringSplitOptions.None)[1].Split(new string[] { "&" }, StringSplitOptions.None).Where(n => n[n.Length - 1] != '=').Aggregate((i, j) => i + "&" + j);
                }
                else
                {
                    Url = Url[Url.Length - 1] != '=' ? Url : Url.Split(new string[] { "?" }, StringSplitOptions.None)[0];
                }
            }

            var response = await _httpClient.GetAsync(Url);
            return await ParseResponse<T>(response);
        }

        public async Task<T> PostData<T>(string Url, object postObject)
        {
            await PrepareAuthenticatedClient();

            var postJsonObject = JsonConvert.SerializeObject(postObject);
            var buffer = System.Text.Encoding.UTF8.GetBytes(postJsonObject);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync(Url, byteContent);

            return await ParseResponse<T>(response);

        }

        public async Task<T> PutData<T>(string Url, object postObject)
        {
            await PrepareAuthenticatedClient();

            var postJsonObject = JsonConvert.SerializeObject(postObject);
            var buffer = System.Text.Encoding.UTF8.GetBytes(postJsonObject);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PutAsync(Url, byteContent);

            return await ParseResponse<T>(response);

        }

        public async Task<T> DeleteData<T>(string Url)
        {
            await PrepareAuthenticatedClient();

            var response = await _httpClient.DeleteAsync(Url);
            return await ParseResponse<T>(response);
        }

        private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return default(T);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Endpoint " + response.RequestMessage.RequestUri.AbsoluteUri + " not found");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                var serviceResponse = JsonConvert.DeserializeObject<T>(stringResult);
                return serviceResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                var serviceResponse = JsonConvert.DeserializeObject<T>(stringResult);
                return serviceResponse;
            }
            else
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                try
                {
                    throw new Exception();
                }
                catch (JsonReaderException ex)
                {

                    throw new Exception("Internal Server Error");
                }
            }
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = UserConstants.CORELIBRARYHTTPCLIENT;
            var client = _httpClientFactory.CreateClient(httpClient);
            return client;
        }

        private async Task PrepareAuthenticatedClient()
        {
            var accessToken = await this._tokenAcquisition.GetAccessTokenForAppAsync(this._TodoListScope + "/.default");
            this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            this._httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
