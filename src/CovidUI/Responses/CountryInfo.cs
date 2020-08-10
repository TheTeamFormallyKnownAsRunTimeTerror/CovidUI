using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    public class CountryInfo
    {
        [JsonPropertyName("countryId")]
        public string CountryId { get; set; }
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("latitude")]
        //TODO will need to check data types in db
        public float Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }
    }
}
