using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    //TODO 
    public class CountryData
    {
        [JsonPropertyName("activeCases")]
        public int ActiveCases { get; set; }
        [JsonPropertyName("confirmedCases")]
        public int ConfirmedCases { get; set; }
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
        [JsonPropertyName("recovered")]
        public int Recovered { get; set; }
    }
}
