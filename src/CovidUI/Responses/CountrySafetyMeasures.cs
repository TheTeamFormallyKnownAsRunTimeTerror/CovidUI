using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    public class CountrySafetyMeasures
    {
        [JsonPropertyName("countryId")]
        public int CountryId { get; set; }
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("measureImportances")]
        public string MeasureImportances { get; set; }
        [JsonPropertyName("grangerStatistics")]
        public string GrangerStatistics { get; set; }
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }
}
