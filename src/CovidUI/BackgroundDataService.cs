using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CovidUI.Responses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace CovidUI
{
    public class BackgroundDataService : IBackgroundDataService
    {
        //private ILogger _logger;
        private string baseUrl = "http:localhost:80";

        public BackgroundDataService(/*ILogger<BackgroundDataService> logger*/)
        {
            //_logger = logger;
            StartService();
        }

        public async void StartService()
        {
            //_logger.LogDebug("Starting Service");

            //_logger.LogDebug("Fetching Country Data");

            await GetCountriesWithData();

            await GetStaticCountriesData();


        }

        private async Task GetCountriesWithData()
        {
            using (var client = GetHttpClient())
            {
                //_logger.LogDebug($"Calling Api with at {baseUrl+ "api/Country/countries"}");

                var response = await client.GetAsync(baseUrl + "api/Country/countries");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<CountryData>>(content);

                CovidCountryData = result;
            }
        }

        private async Task GetStaticCountriesData()
        {
            using (var client = GetHttpClient())
            {
                //_logger.LogDebug($"Calling Api with at {baseUrl + "api/Country/base"}");

                var response = await client.GetAsync(baseUrl + "api/Country/base");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<StaticCountryInformation>>(content);

                StaticCountryData = result;
            }
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public List<CountryData> CovidCountryData { get; set; }
        public List<StaticCountryInformation> StaticCountryData{ get; set; }


    }
}
