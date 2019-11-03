using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using RunpathCodingTest.Configuration;

namespace RunpathCodingTest.WebApi.HttpClient
{
    public class PhotoRequestor : IPhotoRequestor
    {
        System.Net.Http.HttpClient httpClient;

        System.Net.Http.HttpClient GetClient()
        {
            httpClient = new System.Net.Http.HttpClient { BaseAddress = new Uri(ApiSettings.Settings.BaseUrl) };
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        public T GetRequest<T>(string url)
        {
            if (httpClient == null)
            {
                httpClient = GetClient();
            }

            var response = httpClient
                .GetAsync(url)
                .GetAwaiter()
                .GetResult();

            return GetResponse<T>(response);
        }

        T GetResponse<T>(HttpResponseMessage response)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}