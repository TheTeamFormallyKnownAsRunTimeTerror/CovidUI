using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    public class HistoricCountryData
    {
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("active")]
        public int Active { get; set; }
        [JsonPropertyName("confirmed")]
        public int Confirmed { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("recovered")]
        public int Recovered { get; set; }
    }
}
