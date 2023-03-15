using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agro.Integration.Tests
{
    public class Base
    {
        protected readonly HttpClient _identityClient;
        protected readonly HttpClient _client;

        public Base()
        {
            var identityFactory = new WebApplicationFactory<Identity.Api.Startup>();
            _identityClient = identityFactory.CreateClient();
            var factory = new WebApplicationFactory<Okaps.Api.Startup>();
            _client = factory.CreateClient();
        }

        protected static StringContent GetContent(object body) => new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

        protected async Task Auth()
        {
            var response = await _identityClient.PostAsync("/api/Account/login", GetContent(new
            {
                login = "910613350495",
                password = "123456"
            }));
            
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var responseObject = JsonConvert.DeserializeObject<JObject>(content);
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {responseObject["accessToken"]}");
            }
        }
    }
}
