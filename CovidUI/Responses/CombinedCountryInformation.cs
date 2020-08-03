using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidUI.Responses
{
    public class CombinedCountryInformation
    {
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }
        [JsonPropertyName("iso2")]
        public string Iso2 { get; set; }
        [JsonPropertyName("population")]
        public double Population { get; set; }
        [JsonPropertyName("populationDensity")]
        public double PopulationDensity { get; set; }
        [JsonPropertyName("medianAge")]
        public double MedianAge { get; set; }
        [JsonPropertyName("aged65Older")]
        public double Aged65Older { get; set; }
        [JsonPropertyName("aged70Older")]
        public double Aged70Older { get; set; }
        [JsonPropertyName("gdpPerCapita")]
        public double GdpPerCapita { get; set; }
        [JsonPropertyName("diabetesPrevalence")]
        public double DiabetesPrevalence { get; set; }
        [JsonPropertyName("handwashingFacilities")]
        public double HandwashingFacilities { get; set; }
        [JsonPropertyName("hospitalBedsPerThousand")]
        public double HospitalBedsPerThousand { get; set; }
        [JsonPropertyName("lifeExpectancy")]
        public double LifeExpectancy { get; set; }
        [JsonPropertyName("activeCases")]
        public int Active { get; set; }
        [JsonPropertyName("confirmedCases")]
        public int Confirmed { get; set; }
        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }
        [JsonPropertyName("recovered")]
        public int Recovered { get; set; }
    }
}
