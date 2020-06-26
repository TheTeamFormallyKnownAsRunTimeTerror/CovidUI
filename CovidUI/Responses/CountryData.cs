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
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("recovered")]
        public int Recovered { get; set; }
    }
}
