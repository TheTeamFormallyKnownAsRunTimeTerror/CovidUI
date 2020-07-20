using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    public class StaticCountryInformation
    {
        [JsonPropertyName("CountryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("Iso2")]
        public string Iso2 { get; set; }
        [JsonPropertyName("Population")]
        public double Population { get; set; }
        [JsonPropertyName("PopulationDensity")]
        public double PopulationDensity { get; set; }
        [JsonPropertyName("MedianAge")]
        public double MedianAge { get; set; }
        [JsonPropertyName("Aged65Older")]
        public double Aged65Older { get; set; }
        [JsonPropertyName("Aged70Older")]
        public double Aged70Older { get; set; }
        [JsonPropertyName("GdpPerCapita")]
        public double GdpPerCapita { get; set; }
        [JsonPropertyName("DiabetesPrevalence")]
        public double DiabetesPrevalence { get; set; }
        [JsonPropertyName("HandwashingFacilities")]
        public double HandwashingFacilities { get; set; }
        [JsonPropertyName("HospitalBedsPerThousand")]
        public double HospitalBedsPerThousand { get; set; }
        [JsonPropertyName("LifeExpectancy")]
        public double LifeExpectancy { get; set; }
    }
}